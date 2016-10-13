using BranchVersionLibrary;
using CECodeManager.Dialogs;
using CECodeManager.Models;
using CECodeManager.Properties;
using static CETools.Common;
using DbVersionLibrary;
using GitHubHelper;
using JiraHelper;
using Newtonsoft.Json;
using Octokit;
using PfsConnectMonitor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
        private IList<WorkItemView> _filteredWorkItems;
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
                // 48cccb2fd69207ed82b239288d7256a1b9713990 

                //_gitHubRepoHelper = new CEGitHubClient(Settings.Default.GitHubRepoOwner, Settings.Default.GitHubUserName, Settings.Default.GitHubToken);

                var gitHubAccount = CETools.Identities.AccountProfileHelper.GetGitHubAccountInfo();
                _gitHubRepoHelper = new CEGitHubClient(gitHubAccount.Owner, gitHubAccount.Login, gitHubAccount.Token);
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

        #region changed files and assemblies
        private void btnHideChangedFilesAndAssemblies_Click(object sender, EventArgs e)
        {
            changedFilesToolStripMenuItem.Checked = false;
        }
        #endregion

        #region TeamCity
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

        #region running builds
        // get running builds button
        private void btnRunningBuilds_Click(object sender, EventArgs e)
        {
            ShowRunningBuilds();
        }
        private void ShowRunningBuilds()
        {
            var runningBuilds = GetRunningBuilds(null);
            DisplayRunningBuilds(runningBuilds, true);
        }

        private List<RunningBuild.Build> GetRunningBuilds(string branchName)
        {
            List<RunningBuild.Build> filteredRunningBuilds = new List<RunningBuild.Build>();
            try
            {
                SetAppStatusDisplay("Reading running builds from TeamCity...");
                var runningBuilds = GetAllRunningBuilds();
                filteredRunningBuilds = new List<RunningBuild.Build>();

                if (null != runningBuilds && runningBuilds.Count > 0)
                {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return filteredRunningBuilds;
        }
        private IList<RunningBuild.Build> GetAllRunningBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetRunningBuilds();
            return builds;
        }

        // display running builds
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
        #endregion

        #region completed builds
        #region build history
        // get build history button
        private void btnBuildHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetBuilds();

                UpdateWorkItemBuilds(builds);

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
        #endregion

        #region patch build history
        // get patch builds button
        private void btnPatchBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetPatchBuilds();

                UpdateWorkItemBuilds(builds);

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetPatchBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetPatchBuilds();
            return builds;
        }
        #endregion

        #region advantage build history
        private void btnAdvantageBuilds_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetAdvantageBuilds();

                UpdateWorkItemBuilds(builds);

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetAdvantageBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetAdvantageBuilds();
            return builds;
        }
        #endregion

        #region security scan build history
        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                var builds = GetSecurityScanBuilds();

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetSecurityScanBuilds()
        {
            var tc = new TeamCity();
            var builds = tc.GetSecurityScanBuilds();
            return builds;
        }
        #endregion

        private void UpdateWorkItemBuilds(IList<Build> builds)
        {
            foreach (var build in builds)
            {

                IList<BuildChange> changes = GetBuildChangeList(build.id);

                //BuildDetails buildDetails = GetBuildDetails(build.id);

                //// parse commit:
                //// https://api.github.com/repos/CenterEdge/Advantage/git/commits/b952a1f6d474d4f18d0a6a347627ef966d3fe07d
                //var urlSections = commitTask.Url.Split('/');
                //var commitId = urlSections[urlSections.Length - 1];

                if (null != changes && changes.Count > 0)
                {
                    var buildCommits = changes.Select(r => r.version).ToList();

                    foreach (var workItem in _workItems)
                    {
                        foreach (var commit in workItem.Commits)
                        {
                            var urlSections = commit.Url.Split('/');
                            var commitId = urlSections[urlSections.Length - 1];
                            if (buildCommits.Contains(commitId))
                            {
                                if (!workItem.Builds.Any(b => b.id == build.id))
                                    workItem.Builds.Add(build);
                            }
                        }
                    }
                }
            }
        }

        #region search builds
        // search builds button
        private void btnSearchBuilds_Click(object sender, EventArgs e)
        {
            SearchBuilds();
        }
        private void SearchBuilds()
        {
            try
            {
                var builds = GetBuildsByBranch(txtPullRequestNumber.Text);

                UpdateWorkItemBuilds(builds);

                DisplayBuilds(builds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private IList<Build> GetBuildsByBranch(string branch)
        {
            var tc = new TeamCity();
            var builds = tc.GetBranchBuilds(branch);
            return builds;
        }
        #endregion

        // display completed builds
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

                //var changes = GetBuildChanges(Convert.ToInt32(item.id));
                //if (null != changes && null != changes.files && null != changes.files.file)
                //{
                //    foreach (var changedFile in changes.files.file)
                //    {
                //        var lvi2 = new ListViewItem(System.IO.Path.GetFileName(changedFile.file));
                //        lvi2.SubItems.Add(changedFile.file);
                //        lvChangedFiles.Items.Add(lvi2);
                //    }
                //}
            }
        }
        #endregion

        #region build details
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

                int selectedBuildId = -1;

                if (selected is Build)
                {
                    selectedBuildId = ((Build)selected).id;
                }
                else if (selected is RunningBuild.Build)
                {
                    selectedBuildId = ((RunningBuild.Build)selected).id;
                }

                BuildDetails buildDetails = GetBuildDetails(selectedBuildId);

                DisplayBuildDetails(buildDetails);

                //if (null != changes && null != changes.files && null != changes.files.file)
                //{
                //    foreach (var changedFile in changes.files.file)
                //    {
                //        Console.WriteLine(changedFile.ToString());
                //        var lvi2 = new ListViewItem(System.IO.Path.GetFileName(changedFile.file));
                //        lvi2.SubItems.Add(changedFile.file);
                //        lvChangedFiles.Items.Add(lvi2);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private BuildDetails GetBuildDetails(int buildId)
        {
            var tc = new TeamCity();
            var buildDetails = tc.GetBuildDetails(buildId);
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

            string dateQueued = buildDetails.queuedDate.ToString();
            DateTimeOffset dtoQueued = DateTimeOffset.ParseExact(dateQueued, pattern, CultureInfo.InvariantCulture);
            DateTime queuedTimestamp = DateTime.Parse(dtoStart.LocalDateTime.ToString());
            txtBuildDetailQueued.Text = queuedTimestamp.ToString();

            txtBuildDetailStatus.Text = buildDetails.status;
            var statusMessage = string.IsNullOrEmpty(buildDetails.statusText) ? "" : buildDetails.statusText;
            txtBuildDetailStatusText.Text = statusMessage;
            txtBuildDetailState.Text = buildDetails.state;
            txtBuildDetailPlan.Text = buildDetails.buildTypeId;

            lvChangedFiles.Items.Clear();

            if (null != buildDetails.lastChanges && buildDetails.lastChanges.count > 0)
            {
                Console.WriteLine("Read {0} changes...", buildDetails.lastChanges.count);

                txtChangeId.Text = buildDetails.lastChanges.change[0].id.ToString();
                txtChangeVersion.Text = buildDetails.lastChanges.change[0].version;
                txtChangeDev.Text = buildDetails.lastChanges.change[0].username;

                // TODO: GetBuildFiles method
                //foreach (var change in buildDetails.lastChanges.change)
                //{
                //    // changed files and assemblies
                //    var changes = GetBuildChangeList(Convert.ToInt32(change.id));

                //    if (null != changes && null != changes.files && null != changes.files.file)
                //    {
                //        Console.WriteLine("Read {0} changed files...", changes.files.file.Count);

                //        foreach (var changedFile in changes.files.file)
                //        {
                //            var lvi = new ListViewItem(System.IO.Path.GetFileName(changedFile.file));
                //            lvi.SubItems.Add(changedFile.file);
                //            lvi.Tag = changedFile;
                //            lvChangedFiles.Items.Add(lvi);
                //        }
                //    }
                //}
            }
            else
            {
                txtChangeId.Text = "-";
                txtChangeVersion.Text = "-";
                txtChangeDev.Text = "-";
            }
        }

        // get build changes
        // https://teamcity.pfestore.com/httpAuth/app/rest/changes/id:492
        /*
        {
    "id": 492,
    "version": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
    "username": "rroberts",
    "date": "20160624T205455+0000",
    "href": "/httpAuth/app/rest/changes/id:492",
    "webUrl": "https://teamcity.pfestore.com/viewModification.html?modId=492&personal=false",
    "comment": "Correct version number on sql script.\n",
    "user": {
        "username": "rroberts",
        "name": "Rob Roberts",
        "id": 2,
        "href": "/httpAuth/app/rest/users/id:2"
    },
    "files": {
        "file": [
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.100.sql",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.100.sql"
            },
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.26.sql",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.26.sql"
            },
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/AdvUpgrade.vbproj",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/AdvUpgrade.vbproj"
            }
        ]
    },
    "vcsRootInstance": {
        "id": "3",
        "vcs-root-id": "Advantage_HttpsGithubComCenterEdgeAdvantageGitRefsHeadsDevelop",
        "name": "https://github.com/CenterEdge/Advantage.git#refs/heads/develop",
        "href": "/httpAuth/app/rest/vcs-root-instances/id:3"
    }
}
    */
        //private BuildChanges GetBuildChanges(int changeId)
        //{
        //    var tc = new TeamCity();
        //    var buildChanges = tc.GetBuildChanges(changeId);
        //    return buildChanges;
        //}

        private IList<BuildChange> GetBuildChangeList(int changeId)
        {
            var tc = new TeamCity();
            var buildChanges = tc.GetBuildChangeList(changeId);
            return buildChanges;
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
        #endregion

        #region GitHub             
        private void changedFilesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlChangesDisplay.Visible = changedFilesToolStripMenuItem.Checked;
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
        private async void UpdateCommitDetails(WorkItemView workItem)
        {
            await UpdateCommits(workItem);
        }
        private async Task UpdateCommits(WorkItemView workItem)
        {
            try
            {
                SetAppStatusDisplay("Reading commits from GitHub...");
                var pullRequestTask = await _gitHubRepoHelper.GetPullRequestDetails(workItem.GitHubIssue.Number);

                if (null == pullRequestTask) return;

                var commitTask = await _gitHubRepoHelper.GetCommits("ADVANTAGE", pullRequestTask.Head.Sha);




                if (null != commitTask)
                {
                    if (!workItem.Commits.Any(c => c.Sha == commitTask.Sha))
                    {
                        workItem.Commits.Add(commitTask);

                        workItem.HasDbUpgrade = commitTask.Files.Any(f => f.Filename.Contains("AdvUpgrade"));
                        workItem.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));

                        workItem.FilesChanged = commitTask.Files.Select(f => f.Filename).ToList();

                        var advantagePatchBuilder = new ChangedAssembyHelper(workItem.FilesChanged, "ADVANTAGE", "rroberts");
                        workItem.AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
                    }
                }

                Console.WriteLine("Read {0} commits", workItem.Commits.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void DisplayCommitDetails(IList<Octokit.GitHubCommit> commits)
        {
            lvCommits.Items.Clear();
            txtCommitDescription.Clear();

            foreach (var commit in commits)
            {
                DisplayCommitDetails(commit);
            }
            if (commits.Count > 0)
            {
                lvCommits.SelectedIndices.Clear();
                lvCommits.SelectedIndices.Add(0);
            }
        }
        private void DisplayCommitDetails(Octokit.GitHubCommit commitTask)
        {
            var lvi = new ListViewItem(
                  new string[] {
                            commitTask.Sha.Substring(0,8),
                            commitTask.Commit.Message
                      });
            lvi.Tag = commitTask;
            lvCommits.Items.Add(lvi);
        }
        private void lvCommits_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCommitDescription.Clear();
            if (lvCommits.SelectedItems.Count == 0) return;
            var selectedCommit = (Octokit.GitHubCommit)lvCommits.SelectedItems[0].Tag;
            txtCommitDescription.Text = selectedCommit.Commit.Message;
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
                var lvi2 = new ListViewItem(System.IO.Path.GetFileName(fileName));
                lvi2.SubItems.Add(fileName);
                lvChangedFiles.Items.Add(lvi2);
            }
        }

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
                SetAppStatusDisplay("Updating pull requests...");
                UpdateWorkItemGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                SetAppStatusDisplay("Ready");
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

            UpdateJIRAPropertiesOnWorkItems(_workItems);

            _filteredWorkItems = FilterWorkItems(_workItems);

            RefreshWorkItemsDisplay(_filteredWorkItems);
        }

        private void RefreshWorkItemsDisplay()
        {
            _filteredWorkItems = FilterWorkItems(_workItems);
            DisplayWorkItems(_filteredWorkItems, _pullRequestFilter, _pullRequestGroup, _pullRequestSort);
        }

        private void RefreshWorkItemsDisplay(IList<WorkItemView> workItems)
        {
            DisplayWorkItems(workItems, _pullRequestFilter, _pullRequestGroup, _pullRequestSort);
        }

        private IList<WorkItemView> FilterWorkItems(IList<WorkItemView> workItems)
        {
            var filteredRequests = new List<WorkItemView>();

            if (null != workItems && workItems.Count > 0)
            {
                var pullRequestStatusDisplayList = new List<ItemState>();
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowPullOpen))
                    pullRequestStatusDisplayList.Add(ItemState.Open);
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowPullClosed))
                    pullRequestStatusDisplayList.Add(ItemState.Closed);

                var teamDisplayList = new List<string>();
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowAMS))
                    teamDisplayList.Add("AMS");
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowRD))
                    teamDisplayList.Add("R&D");

                var jiraStatusDisplayList = new List<string>();
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowInProgress))
                    jiraStatusDisplayList.Add("In Progress");
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowQA))
                    jiraStatusDisplayList.Add("QA");
                if (_pullRequestFilter.HasFlag(PullRequestFilter.ShowApproved))
                    jiraStatusDisplayList.Add("QA Approved");

                filteredRequests = workItems.Where(w =>
                    pullRequestStatusDisplayList.Contains(w.GitHubIssue.State) &&
                    teamDisplayList.Contains(w.CETeam) &&
                    jiraStatusDisplayList.Contains(w.JiraStatus.ToString())).ToList();
            }

            return filteredRequests;
        }

        // MAIN DISPLAY ROUTINE
        private void DisplayWorkItems(IList<WorkItemView> workItems, PullRequestFilter filter, PullRequestGroupBy groupBy, PullRequestSort sortBy)
        {
            try
            {
                lvWork.Items.Clear();
                lvWork.Groups.Clear();

                if (null == workItems) return;

                lvWork.ShowGroups = (groupBy != PullRequestGroupBy.None);

                IOrderedEnumerable<WorkItemView> sortedRequests = null;
                switch (sortBy)
                {
                    case PullRequestSort.Status:
                        {
                            sortedRequests = _filteredWorkItems.OrderBy(w => w.GitHubIssue.State.ToString()).ThenBy(w => w.GitHubIssue.Number);
                            break;
                        }
                    case PullRequestSort.Developer:
                        {
                            sortedRequests = _filteredWorkItems.OrderBy(w => w.GitHubIssue.User.Login).ThenBy(w => w.GitHubIssue.Number);
                            break;
                        }
                    case PullRequestSort.Team:
                        {
                            sortedRequests = _filteredWorkItems.OrderBy(w => w.CETeam);
                            break;
                        }
                    case PullRequestSort.Id:
                        {
                            sortedRequests = _filteredWorkItems.OrderBy(w => w.GitHubIssue.Number);
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

                        UpdateCommitDetails(item);
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
            try
            {
                if (lvWork.SelectedItems.Count == 0) return;

                WorkItemView workItem = (WorkItemView)lvWork.SelectedItems[0].Tag;

                SetAppStatusDisplay("Updating status...");
                UpdateWorkItem(workItem);

                SetAppStatusDisplay("Updating display...");
                DisplayWorkItem(workItem);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                SetAppStatusDisplay("Ready");
            }

        }

        private void UpdateWorkItem(WorkItemView workItem)
        {
            UpdateJIRAPropertiesOnWorkItem(workItem);
            UpdateCommitDetails(workItem);
            UpdateWorkItemBuilds(workItem);
        }

        private void DisplayWorkItem(WorkItemView workItem)
        {
            DisplayJIRAIssue(workItem, true);
            DisplayCommitDetails(workItem.Commits);
            DisplayRunningBuilds(workItem.RunningBuilds, true);
            DisplayBuilds(workItem.Builds, false);
            DisplayFilesAndAssembliesChanged(workItem);
        }

        private void UpdateWorkItemBuilds(WorkItemView workItem)
        {
            try
            {
                var branchName = string.Format("{0}/merge", workItem.GitHubIssue.Number);
                workItem.RunningBuilds = GetRunningBuilds(branchName);
                Console.WriteLine("Read {0} running builds", workItem.RunningBuilds.Count);
                workItem.Builds = GetBuildsByBranch(branchName);
                var buildCount = null != workItem.Builds ? workItem.Builds.Count : 0;
                Console.WriteLine("Read {0} completed builds", buildCount);
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

                    RefreshWorkItemsDisplay(_filteredWorkItems);
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

                    RefreshWorkItemsDisplay(_filteredWorkItems);
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
        #endregion

        #region JIRA    
        private void UpdateJIRAPropertiesOnWorkItems(IList<WorkItemView> workItems)
        {
            foreach (var workItem in workItems)
            {
                UpdateJIRAPropertiesOnWorkItem(workItem);
            }
        }
        private void UpdateJIRAPropertiesOnWorkItem(WorkItemView workItem)
        {
            try
            {
                SetAppStatusDisplay("Reading issue from Jira...");
                workItem.JiraIssues = GetJiraIssues(workItem.GitHubIssue, workItem.RepositoryName);
                Console.WriteLine("Read {0} JIRA issues", workItem.JiraIssues.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                SetAppStatusDisplay("JIRA update complete");

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
            var jiraIssueNumbers = JiraIssueHelper.GetJiraIssueNumbers(titleAndBody);
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

        // Display JIRA issues
        //private void DisplayJIRAIssues(IList<WorkItemView> workItems)
        //{
        //    lvJira.Items.Clear();

        //    foreach (var workItem in workItems)
        //    {
        //        DisplayJIRAIssue(workItem);
        //    }
        //}
        private void DisplayJIRAIssue(WorkItemView workItem)
        {
            DisplayJIRAIssue(workItem, true);
        }
        private void DisplayJIRAIssue(WorkItemView workItem, bool clearGrid)
        {
            try
            {
                if (clearGrid) lvJira.Items.Clear();

                foreach (var jiraIssue in workItem.JiraIssues)
                {
                    var epicName = "";
                    if (null != jiraIssue.Components && jiraIssue.Components.Count > 0)
                    {
                        epicName = jiraIssue.Components[0].Name;
                    }

                    var lvi = new ListViewItem(
                        new string[] {
                            jiraIssue.Key.ToString() ,
                            workItem.CETeam,
                            jiraIssue.Summary,
                            jiraIssue.Status.ToString(),
                            workItem.FixVersions,
                            jiraIssue.Priority.Name,
                            jiraIssue.Type.Name, // issue type
                            epicName // epic
                            });
                    lvi.Tag = jiraIssue;
                    lvJira.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

                var gitHubAccount = CETools.Identities.AccountProfileHelper.GetGitHubAccountInfo();
                _gitHubRepoHelper = new CEGitHubClient(gitHubAccount.Owner, gitHubAccount.Login, gitHubAccount.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        #endregion

        private async void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var t = await _gitHubRepoHelper.GetTree("ADVANTAGE", "b952a1f6d474d4f18d0a6a347627ef966d3fe07d");

            //var c = await _gitHubRepoHelper.Compare("ADVANTAGE", "b952a1f6d474d4f18d0a6a347627ef966d3fe07d", "develop");
           // var m = await _gitHubRepoHelper.Compare("ADVANTAGE", "e6684f89a0f806a7722650f789b0668ca9d546cd", "master");
            var c = await _gitHubRepoHelper.Compare("ADVANTAGE", "e6684f89a0f806a7722650f789b0668ca9d546cd", "develop");
            // e6684f89a0f806a7722650f789b0668ca9d546cd
        }
    }
}
