using BranchVersionLibrary;
using CECodeManager.Dialogs;
using CECodeManager.Models;
using CECodeManager.Properties;
using DbVersionLibrary;
using GitHubHelper;
using JiraHelper;
using Newtonsoft.Json;
using Octokit;
using PfsConnectMonitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamCityService;

namespace CECodeManager
{
    public partial class CodeManager : Form
    {
        #region fields
        private VersionFileMonitor _versionFileMonitor;
        private DbVersionHelper _advUpgradeHelper;
        private CEGitHubClient _gitHubRepoHelper;
        private IList<string> _repoNames;
        private List<WorkItemView> _workItems;
        private JiraIssueHelper _jiraHelper;
        #endregion

        #region ctor / load
        public CodeManager()
        {
            InitializeComponent();
        }

        private void CodeManager_Load(object sender, EventArgs e)
        {
            SetAppStatusDisplay("Loading...");

            if (null == _gitHubRepoHelper)
            {
                _gitHubRepoHelper = new CEGitHubClient(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken);
            }

            _jiraHelper = new JiraIssueHelper();

            _repoNames = JsonConvert.DeserializeObject<List<string>>(Settings.Default.ActiveRepoList);

            _advUpgradeHelper = new DbVersionHelper();
            _versionFileMonitor = new VersionFileMonitor();

            _versionFileMonitor.BranchMonitorException += _branchVersionMonitor_BranchMonitorException;
            _versionFileMonitor.BranchVersionChanged += _branchVersionMonitor_BranchVersionChanged;

            UpdateBranchMonitorState();

            SetGitHubGridFilterValues();

            SetAppStatusDisplay("Ready");
        }
        #endregion

        #region exception handlers
        private void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ExceptionHandler(string caption, Exception ex)
        {
            Console.WriteLine(ex.ToString());
            MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region exit menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region version file monitor
        private void branchMonitorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateBranchMonitorState();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void UpdateBranchMonitorState()
        {
            if (branchMonitorToolStripMenuItem.Checked)
            {
                _versionFileMonitor.StartMonitor();
                lblBranchMonitorStatus.BackColor = Color.LimeGreen;
            }
            else
            {
                _versionFileMonitor.StopMonitor();
                lblBranchMonitorStatus.BackColor = Color.DimGray;
            }
        }

        private void _branchVersionMonitor_BranchVersionChanged(object sender, Version e)
        {
            try
            {
                HandleVersionFileChange();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void _branchVersionMonitor_BranchMonitorException(object sender, Exception e)
        {
            try
            {
                ExceptionHandler("Branch Monitor Exception", e);
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }
        private void updateStatusInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HandleVersionFileChange();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void HandleVersionFileChange()
        {
            // Version.txt file
            SetVersionFileDisplay(_versionFileMonitor.GetVersionFileVersion());

            // AdvUpgrade Version
            UpdateAdvUpgradeVersion();

            // PfsConnect settings
            SetPfsConnectionDisplay(_versionFileMonitor.GetTestDatabase());

            // current GitHub branch
            SetBranchNameDisplay(BranchVersionHelper.CurrentBranch.Name);
            SetBranchVersionDisplay(BranchVersionHelper.CurrentBranch.Version);
        }
        #endregion

        #region advupgrade
        private void UpdateAdvUpgradeVersion()
        {
            var currentMinor = _advUpgradeHelper.GetLatestMinorVersion();
            SetUpgradeVersionDisplay(currentMinor.CurrentBuildVersion.VersionNumber);
        }
        #endregion

        #region status bar 
        private void SetBranchNameDisplay(string branchName)
        {
            lblBranch.Text = String.Format("Branch Name: {0}", branchName);
        }
        private void SetBranchVersionDisplay(Version newVersion)
        {
            lblBranchVersion.Text = String.Format("Branch Version: {0}", newVersion.ToString());
        }
        private void SetVersionFileDisplay()
        {
            SetVersionFileDisplay(_versionFileMonitor.GetVersionFileVersion());
        }
        private void SetVersionFileDisplay(Version newVersion)
        {
            lblVersionFile.Text = String.Format("Version File: {0}", newVersion.ToString());
        }
        private void SetUpgradeVersionDisplay(Version newVersion)
        {
            lblAdvUpgradeVersion.Text = String.Format("AdvUpgrade Version: {0}", newVersion.ToString());
        }
        private void SetPfsConnectionDisplay(string connection)
        {
            lblPfsConnection.Text = String.Format("PFS Connection: {0}", connection);
        }
        private void SetAppStatusDisplay(string newStatus)
        {
            lblStatus.Text = newStatus;
        }
        #endregion

        #region pull requests
        #region pull request grid
        private void pnlGridOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlGridOptions.Visible)
            {
                btnShowHideGridOptions.Text = "X";
            }
            else
            {
                btnShowHideGridOptions.Text = "v";
            }
        }
        private void pullRequestGridOptionsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlGridOptions.Visible = pullRequestGridOptionsToolStripMenuItem.Checked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void btnShowHideGridOptions_Click(object sender, EventArgs e)
        {
            try
            {
                pullRequestGridOptionsToolStripMenuItem.Checked = !pullRequestGridOptionsToolStripMenuItem.Checked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateWorkItemGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void UpdateWorkItemGrid()
        {
            Task<SearchIssuesResult> issueRequestTask = _gitHubRepoHelper.GetIssues(null, 2, _repoNames);

            var issues = await issueRequestTask;

            _workItems = new List<WorkItemView>();

            foreach (var issue in issues.Items)
            {
                var workItem = new WorkItemView()
                {
                    GitHubIssue = issue
                };
                _workItems.Add(workItem);
            }

            //foreach (var item in _workItems)
            //{
            //    UpdateCommits(item);
            //}

            UpdateWorkItemsFromJira(_workItems);

            RefreshWorkItemsDisplay();
        }

        private void RefreshWorkItemsDisplay()
        {
            DisplayWorkItems(_workItems, _pullRequestFilter, _pullRequestGroup, _pullRequestSort);
        }

        private void DisplayWorkItems(IList<WorkItemView> workItems, PullRequestFilter filter, PullRequestGroupBy groupBy, PullRequestSort sortBy)
        {
            try
            {
                lvWork.Items.Clear();
                lvWork.Groups.Clear();

                if (null == workItems) return;

                lvWork.ShowGroups = (groupBy != PullRequestGroupBy.None);

                var pullRequestStatusDisplayList = new List<ItemState>();
                if (filter.HasFlag(PullRequestFilter.ShowPullOpen))
                    pullRequestStatusDisplayList.Add(ItemState.Open);
                if (filter.HasFlag(PullRequestFilter.ShowPullClosed))
                    pullRequestStatusDisplayList.Add(ItemState.Closed);

                var teamDisplayList = new List<string>();
                if (filter.HasFlag(PullRequestFilter.ShowAMS))
                    teamDisplayList.Add("AMS");
                if (filter.HasFlag(PullRequestFilter.ShowRD))
                    teamDisplayList.Add("R&D");

                var jiraStatusDisplayList = new List<string>();
                if (filter.HasFlag(PullRequestFilter.ShowInProgress))
                    jiraStatusDisplayList.Add("In Progress");
                if (filter.HasFlag(PullRequestFilter.ShowQA))
                    jiraStatusDisplayList.Add("QA");
                if (filter.HasFlag(PullRequestFilter.ShowApproved))
                    jiraStatusDisplayList.Add("QA Approved");

                var filteredRequests = workItems.Where(w =>
                    pullRequestStatusDisplayList.Contains(w.GitHubIssue.State) &&
                    teamDisplayList.Contains(w.CETeam) &&
                    jiraStatusDisplayList.Contains(w.JiraStatus.ToString()));

                IOrderedEnumerable<WorkItemView> sortedRequests = null;
                switch (sortBy)
                {
                    case PullRequestSort.Status:
                        {
                            sortedRequests = filteredRequests.OrderBy(w => w.GitHubIssue.State.ToString()).ThenBy(w => w.GitHubIssue.Number);
                            break;
                        }
                    case PullRequestSort.Developer:
                        {
                            sortedRequests = filteredRequests.OrderBy(w => w.GitHubIssue.User.Login).ThenBy(w => w.GitHubIssue.Number);
                            break;
                        }
                    case PullRequestSort.Team:
                        {
                            sortedRequests = filteredRequests.OrderBy(w => w.CETeam);
                            break;
                        }
                    case PullRequestSort.Id:
                        {
                            sortedRequests = filteredRequests.OrderBy(w => w.GitHubIssue.Number);
                            break;
                        }
                }

                foreach (var item in sortedRequests)
                {
                    var hasDbUpdate = item.HasDbUpgrade ? "DB UPDATE" : "";
                    var hasBuildScriptWarning = item.HasBuildScriptChange ? "BUILD SCRIPT CHANGED!" : "";

                    var lvi = new ListViewItem(
                        new string[] {
                            item.GitHubIssue.Number.ToString() ,
                            item.GitHubIssue.Title,
                            item.GitHubIssue.User.Login,
                            item.GitHubIssue.State.ToString(),
                            item.CETeam,
                            item.FixVersions,
                            item.JiraStatus.ToString(),
                            hasDbUpdate,
                            hasBuildScriptWarning
                            });

                    if (item.HasDbUpgrade)
                    {
                        lvi.ImageIndex = 4;
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems[7].BackColor = Color.Orange;
                    }

                    if (item.HasBuildScriptChange)
                    {
                        lvi.ImageIndex = 0;
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems[8].BackColor = Color.Red;
                    }

                    lvi.Tag = item;

                    // grouping
                    if (lvWork.ShowGroups)
                    {
                        string groupName = String.Empty;
                        switch (groupBy)
                        {
                            case PullRequestGroupBy.Status:
                                {
                                    groupName = item.GitHubIssue.State.ToString();
                                    break;
                                }
                            case PullRequestGroupBy.Developer:
                                {
                                    groupName = item.GitHubIssue.User.Login;
                                    break;
                                }
                            case PullRequestGroupBy.Team:
                                {
                                    groupName = item.CETeam;
                                    break;
                                }
                        }
                        bool foundGroup = false;
                        foreach (ListViewGroup group in lvWork.Groups)
                        {
                            if (group.Header == groupName)
                            {
                                lvi.Group = group;
                                foundGroup = true;
                                break;
                            }
                        }
                        if (!foundGroup)
                        {
                            // add the group
                            var newGroup = new ListViewGroup(groupName);
                            lvi.Group = newGroup;
                            lvWork.Groups.Add(newGroup);
                        }

                    }

                    lvWork.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void lvWork_DoubleClick(object sender, EventArgs e)
        {
            ShowWorkItemBuilds();
            UpdateCommitDetails();
        }

        private void ShowWorkItemBuilds()
        {
            try
            {
                if (lvWork.SelectedItems.Count == 0) return;

                WorkItemView workItem = (WorkItemView)lvWork.SelectedItems[0].Tag;

                var branchName = string.Format("{0}/merge", workItem.GitHubIssue.Number);

                ShowRunningBuilds(branchName, true);

                var completedBuilds = GetBuildsByBranch(branchName);
                DisplayBuilds(completedBuilds, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region pull request grid filter/group/sort
        #region filter on
        [Flags()]
        private enum PullRequestFilter
        {
            ShowPullOpen = 1,
            ShowPullClosed = 2,
            ShowInProgress = 4,
            ShowQA = 8,
            ShowApproved = 16,
            ShowRD = 32,
            ShowAMS = 64,
            ShowCloud = 128
        }
        private PullRequestFilter _pullRequestFilter = PullRequestFilter.ShowPullOpen;
        private void chkPullRequestFilter_CheckedChanged(object sender, EventArgs e)
        {
            SetGitHubGridFilterValues();
        }
        private void SetGitHubGridFilterValues()
        {
            try
            {
                _pullRequestFilter = 0;

                if (chkFilterOpen.Checked)
                    _pullRequestFilter = PullRequestFilter.ShowPullOpen;
                if (chkFilterClosed.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowPullClosed;

                if (chkFilterInProgress.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowInProgress;
                if (this.chkFilterQA.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowQA;
                if (this.chkFilterApproved.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowApproved;

                if (this.chkFilterRD.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowRD;
                if (this.chkFilterAMS.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowAMS;
                if (this.chkFilterCloud.Checked)
                    _pullRequestFilter = _pullRequestFilter | PullRequestFilter.ShowCloud;

                Console.WriteLine(_pullRequestFilter.ToString());

                RefreshWorkItemsDisplay();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region group by
        private enum PullRequestGroupBy
        {
            None,
            Developer,
            Status,
            Team
        }
        private PullRequestGroupBy _pullRequestGroup = PullRequestGroupBy.None;
        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton selected = ((RadioButton)sender);
                if (selected.Checked)
                {
                    int tagValue = Convert.ToInt32(selected.Tag.ToString());
                    _pullRequestGroup = (PullRequestGroupBy)tagValue;

                    RefreshWorkItemsDisplay();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region sort by
        private enum PullRequestSort
        {
            Id,
            Developer,
            Status,
            Team
        }
        private PullRequestSort _pullRequestSort = PullRequestSort.Id;
        private void rbSort_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton selected = ((RadioButton)sender);
                if (selected.Checked)
                {
                    int tagValue = Convert.ToInt32(selected.Tag.ToString());
                    _pullRequestSort = (PullRequestSort)tagValue;

                    RefreshWorkItemsDisplay();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
        #endregion
        #endregion

        #region builds
        private void btnHideBuildsPanel_Click(object sender, EventArgs e)
        {
            try
            {
                buildDetailsToolStripMenuItem.Checked = false;
                teamCityBuildsToolStripMenuItem.Checked = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void teamCityBuildsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = ((ToolStripMenuItem)sender).Checked;
                this.pnlTeamCity.Visible = isChecked;
                buildDetailsToolStripMenuItem.Checked = isChecked;
                buildDetailsToolStripMenuItem.Enabled = isChecked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        // get running builds button
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void ShowRunningBuilds()
        {
            ShowRunningBuilds(null, true);
        }
        private void ShowRunningBuilds(string branchName, bool clearGrid)
        {
            try
            {
                var runningBuilds = GetRunningBuilds();

                List<RunningBuild.Build> filteredRunningBuilds = new List<RunningBuild.Build>();

                if (String.IsNullOrEmpty(branchName))
                {
                    filteredRunningBuilds.AddRange(runningBuilds);
                }
                else
                {
                    foreach (var build in runningBuilds)
                    {
                        if (build.branchName == branchName)
                            filteredRunningBuilds.Add(build);
                    }
                }

                DisplayRunningBuilds(filteredRunningBuilds, clearGrid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<RunningBuild.Build> GetRunningBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetRunningBuilds();
            return builds;
        }
        private void DisplayRunningBuilds(IList<RunningBuild.Build> builds)
        {
            DisplayRunningBuilds(builds, true);
        }
        private void DisplayRunningBuilds(IList<RunningBuild.Build> builds, bool clearGrid)
        {
            if (clearGrid) lvBuilds.Items.Clear();

            if (null == builds || builds.Count == 0) return;

            foreach (var item in builds)
            {
                var lvi = new ListViewItem(
                    new string[] {
                            item.id.ToString() ,
                            item.percentageComplete.ToString(),
                            item.number,
                            item.branchName,
                            item.status,
                            item.state,
                            item.buildTypeId
                        });
                lvi.Tag = item;
                lvBuilds.Items.Add(lvi);
            }

            lvBuilds.SelectedIndices.Add(0);
            ShowBuildDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetBuilds();

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetBuilds();
            return builds;
        }
        private void DisplayBuilds(IList<Build> builds)
        {
            DisplayBuilds(builds, true);
        }
        private void DisplayBuilds(IList<Build> builds, bool clearGrid)
        {
            if (clearGrid) lvBuilds.Items.Clear();

            if (null == builds || builds.Count == 0) return;

            foreach (var item in builds)
            {
                var lvi = new ListViewItem(
                    new string[] {
                            item.id.ToString() ,
                            "Done",
                            item.number,
                            item.branchName,
                            item.status,
                            item.state,
                            item.buildTypeId,
                        });
                lvi.Tag = item;
                lvBuilds.Items.Add(lvi);
            }

            lvBuilds.SelectedIndices.Add(0);
            ShowBuildDetails();
        }

        // get builds by branch button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetBuildsByBranch();

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetBuildsByBranch()
        {
            var builds = GetBuildsByBranch(txtPullRequestNumber.Text);
            return builds;
        }
        private IList<Build> GetBuildsByBranch(string branch)
        {
            var tc = new TeamCity();
            var builds = tc.GetBranchBuilds(branch);
            return builds;
        }

        // get patch builds by branch button
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetPatchBuildsByBranch();

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetPatchBuildsByBranch()
        {
            return GetPatchBuildsByBranch(txtPullRequestNumber.Text);
        }
        private IList<Build> GetPatchBuildsByBranch(string branch)
        {
            var tc = new TeamCity();
            var builds = tc.GetPatchBuilds(branch);
            return builds;
        }

        // show build details
        private void lvBuilds_DoubleClick(object sender, EventArgs e)
        {
            ShowBuildDetails();
        }
        private void ShowBuildDetails()
        {
            try
            {
                pnlBuildDetails.Visible = true;

                if (lvBuilds.SelectedItems.Count == 0) return;

                var selected = lvBuilds.SelectedItems[0].Tag;

                string selectedBuildId = string.Empty;

                if (selected is Build)
                {
                    selectedBuildId = ((Build)selected).id.ToString();
                }
                else if (selected is RunningBuild.Build)
                {
                    selectedBuildId = ((RunningBuild.Build)selected).id.ToString();
                }

                BuildDetails buildDetails = GetBuildDetails(selectedBuildId);

                DisplayBuildDetails(buildDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private BuildDetails GetBuildDetails(string buildNumber)
        {
            var tc = new TeamCity();
            var buildDetails = tc.GetPatchBuildDetails(buildNumber);
            return buildDetails;
        }
        private void DisplayBuildDetails(BuildDetails buildDetails)
        {
            string dateStart = buildDetails.startDate;
            string pattern = "yyyyMMdd'T'HHmmsszzz";
            DateTimeOffset dtoStart = DateTimeOffset.ParseExact(dateStart, pattern, CultureInfo.InvariantCulture);
            DateTime startTimestamp = DateTime.Parse(dtoStart.LocalDateTime.ToString());
            txtBuildDetailStarted.Text = startTimestamp.ToString();

            if (!string.IsNullOrEmpty(buildDetails.finishDate))
            {
                string dateEnd = buildDetails.finishDate;
                DateTimeOffset dtoEnd = DateTimeOffset.ParseExact(dateEnd, pattern, CultureInfo.InvariantCulture);
                DateTime endTimestamp = DateTime.Parse(dtoEnd.LocalDateTime.ToString());
                txtBuildDetailFinished.Text = endTimestamp.ToString();
                txtBuildDetailDuration.Text = dtoEnd.Subtract(dtoStart).ToString();
            }
            else
            {
                txtBuildDetailFinished.Text = "-";
                txtBuildDetailDuration.Text = "-";
            }

            txtBuildDetailStatus.Text = buildDetails.status;
            txtBuildDetailState.Text = buildDetails.state;
            txtBuildDetailPlan.Text = buildDetails.buildTypeId;
        }

        // hide build details
        private void btnHideBuildDetails_Click(object sender, EventArgs e)
        {
            HideBuildDetails();
        }
        private void buildDetailsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlBuildDetails.Visible = buildDetailsToolStripMenuItem.Checked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void HideBuildDetails()
        {
            try
            {
                buildDetailsToolStripMenuItem.Checked = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        #endregion

        #region commits
        private void updateCommitPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvWork.SelectedItems.Count > 0)
                {
                    var selected = ((WorkItemView)lvWork.SelectedItems[0].Tag);
                    UpdateCommits(selected);
                }
                else
                {
                    foreach (var item in _workItems)
                    {
                        UpdateCommits(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void btnHideChangedFiles_Click(object sender, EventArgs e)
        {
            try
            {
                changedFilesToolStripMenuItem.Checked = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void changedFilesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlChangedFiles.Visible = changedFilesToolStripMenuItem.Checked;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async void UpdateCommitDetails()
        {
            if (lvWork.SelectedItems.Count == 0) return;

            WorkItemView workItem = (WorkItemView)lvWork.SelectedItems[0].Tag;

            await UpdateCommits(workItem);
        }
        private async Task UpdateCommits(WorkItemView workItem)
        {
            var pullRequestTask = await _gitHubRepoHelper.GetPullRequestDetails(workItem.GitHubIssue.Number);

            if (null == pullRequestTask) return;

            var commitTask = await _gitHubRepoHelper.GetCommits("ADVANTAGE", pullRequestTask.Head.Sha);

            if (null != commitTask)
            {
                workItem.Commits.Add(commitTask);

                workItem.HasDbUpgrade = commitTask.Files.Any(f => f.Filename.Contains("AdvUpgrade"));
                workItem.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));

                workItem.FilesChanged = commitTask.Files.Select(f => f.Filename).ToList();

                var advantagePatchBuilder = new ChangedAssembyHelper(workItem.FilesChanged, "ADVANTAGE", "rroberts");
                workItem.AssembliesChanged = advantagePatchBuilder.AssemblyFiles;

                DisplayCommitDetails(commitTask);
            }

            DisplayFilesAndAssembliesChanged(workItem);
        }

        private void DisplayCommitDetails(Octokit.GitHubCommit commitTask)
        {
            lvCommits.Items.Clear();

            var lvi = new ListViewItem(
                  new string[] {
                            commitTask.Sha.Substring(0,8),
                            commitTask.Commit.Message
                      });

            lvCommits.Items.Add(lvi);

        }

        private void DisplayFilesAndAssembliesChanged(WorkItemView workItem)
        {
            lvChangedAssemblies.Items.Clear();

            foreach (var assemblyName in workItem.AssembliesChanged)
            {
                var lvi = new ListViewItem(assemblyName);
                lvChangedAssemblies.Items.Add(lvi);
            }

            lvChangedFiles.Items.Clear();

            foreach (var fileName in workItem.FilesChanged)
            {
                var lvi = new ListViewItem(fileName);
                lvChangedFiles.Items.Add(lvi);
            }
        }
        #endregion

        #region JIRA
        private void updateJIRAPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateWorkItemsFromJira(_workItems);
        }
        private void UpdateWorkItemsFromJira(IList<WorkItemView> workItems)
        {
            try
            {
                foreach (var workItem in workItems)
                {
                    UpdateWorkItemFromJira(workItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void UpdateWorkItemFromJira(WorkItemView workItem)
        {
            try
            {
                workItem.JiraIssues = GetJiraIssues(workItem.GitHubIssue, workItem.RepositoryName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        IList<Atlassian.Jira.Issue> GetJiraIssues(Octokit.Issue request, string repoName)
        {
            var jiraIssues = new List<Atlassian.Jira.Issue>();
            string titleAndBody = String.Empty;
            if (request.Title.Contains("…"))
            {
                titleAndBody = request.Title.Replace("…", "");
            }
            else
            {
                titleAndBody = request.Title;
            }
            if (request.Body.Contains("…"))
            {
                titleAndBody += request.Body.Replace("…", "");
            }
            else
            {
                titleAndBody += request.Body;
            }
            var jiraIssueNumbers = GetJiraIssueNumbers(titleAndBody);
            foreach (var jiraIssueNumber in jiraIssueNumbers)
            {
                try
                {
                    var jiraIssue = _jiraHelper.GetJiraIssueByKey(jiraIssueNumber);
                    if (null != jiraIssue)
                    {
                        jiraIssues.Add(jiraIssue);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception reading JIRA issue with key " + jiraIssueNumber + ": " + ex.ToString());
                }

            }
            return jiraIssues;
        }

        IList<string> _jiraIssuePrefixes = new List<string>() { "ADVANTAGE", "WEB", "SITEINFO", "ONLINE", "MOBILEINV", "MOBILETIK" };
        IList<string> GetJiraIssueNumbers(string body)
        {
            var issueNumbers = new List<string>();

            foreach (var repoName in _jiraIssuePrefixes)
            {
                var tokenLength = repoName.Length;

                body = body.ToUpper();

                if (body.Contains(repoName))
                {
                    for (int i = 0; i < body.Length - tokenLength; i++)
                    {
                        if (body.Substring(i, tokenLength) == repoName)
                        {
                            var issueNumberBuffer = String.Empty;
                            var nextIdx = 0;
                            // add 1 for the '-' character. (Sometimes it is a different character, so we don't hard-code it.)
                            var textSection = body.Substring(i + tokenLength + 1);
                            while (GetNumberValue(textSection, ref issueNumberBuffer, ref nextIdx))
                            {
                                if (!issueNumbers.Contains(issueNumberBuffer) && !String.IsNullOrEmpty(issueNumberBuffer))
                                {
                                    //issueNumbers.Add(issueNumberBuffer);
                                    issueNumbers.Add(String.Format("{0}-{1}", repoName, issueNumberBuffer));
                                }

                                if ("," == body.Substring(nextIdx + i + tokenLength - 1, 1))
                                {
                                    textSection = body.Substring(nextIdx + i + tokenLength);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return issueNumbers.Where(i => !String.IsNullOrEmpty(i)).ToList();
        }

        bool GetNumberValue(string buffer, ref string numberValue, ref int nextIdx)
        {
            int digitLength = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                var digitBuffer = buffer.Substring(i, 1);
                if (digitBuffer != " ")
                {
                    if (!digitBuffer.All(Char.IsDigit))
                    {
                        numberValue = buffer.Substring(i - digitLength, digitLength).Trim();
                        nextIdx = i + 1;
                        return true;
                    }
                }
                digitLength++;
            }
            return false;
        }


        #endregion

        #region accounts
        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAccountsForm();
        }

        private void DisplayAccountsForm()
        {
            try
            {
                var dialog = new AccountsDialog();
                var result = dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        #endregion
    }
}
