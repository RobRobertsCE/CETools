namespace CECodeManager
{
    partial class CodeManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.pullRequestGridOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.teamCityBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.changedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblBranch = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBranchVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersionFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAdvUpgradeVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPfsConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBranchMonitorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvWork = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gitHubGridImages = new System.Windows.Forms.ImageList(this.components);
            this.pnlGitHub = new System.Windows.Forms.Panel();
            this.btnShowHideGridOptions = new System.Windows.Forms.Button();
            this.pnlGridOptions = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbSortTeam = new System.Windows.Forms.RadioButton();
            this.rbSortId = new System.Windows.Forms.RadioButton();
            this.rbSortStatus = new System.Windows.Forms.RadioButton();
            this.rbSortDeveloper = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbGroupNone = new System.Windows.Forms.RadioButton();
            this.rbGroupStatus = new System.Windows.Forms.RadioButton();
            this.rbGroupDeveloper = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFilterApproved = new System.Windows.Forms.CheckBox();
            this.chkFilterQA = new System.Windows.Forms.CheckBox();
            this.chkFilterInProgress = new System.Windows.Forms.CheckBox();
            this.chkFilterCloud = new System.Windows.Forms.CheckBox();
            this.chkFilterAMS = new System.Windows.Forms.CheckBox();
            this.chkFilterRD = new System.Windows.Forms.CheckBox();
            this.chkFilterClosed = new System.Windows.Forms.CheckBox();
            this.chkFilterOpen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTeamCity = new System.Windows.Forms.Panel();
            this.btnHideBuildsPanel = new System.Windows.Forms.Button();
            this.pnlBuildGridAndDetails = new System.Windows.Forms.Panel();
            this.pnlBuildDetails = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBuildDetailStatusText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBuildDetailQueued = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtChangeDev = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtChangeVersion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtChangeId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuildDetailPlan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuildDetailDuration = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuildDetailState = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuildDetailFinished = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuildDetailStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHideBuildDetails = new System.Windows.Forms.Button();
            this.txtBuildDetailStarted = new System.Windows.Forms.TextBox();
            this.lblBuildDetails = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.lvBuilds = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBuildGridButtons = new System.Windows.Forms.Panel();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnAdvantageBuilds = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPatchBuilds = new System.Windows.Forms.Button();
            this.txtPullRequestNumber = new System.Windows.Forms.TextBox();
            this.btnSearchBuilds = new System.Windows.Forms.Button();
            this.btnRunningBuilds = new System.Windows.Forms.Button();
            this.btnBuildHistory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTeamCity = new System.Windows.Forms.TabPage();
            this.tabJIRA = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvJira = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.pnlTabControl = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlCommitAndDescription = new System.Windows.Forms.Panel();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.pnlCommits = new System.Windows.Forms.Panel();
            this.lvCommits = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.txtCommitDescription = new System.Windows.Forms.TextBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pnlChangesDisplay = new System.Windows.Forms.Panel();
            this.btnHideChangedFilesAndAssemblies = new System.Windows.Forms.Button();
            this.pnlChangedFilesAndAssemblies = new System.Windows.Forms.Panel();
            this.pnlChangedFiles = new System.Windows.Forms.Panel();
            this.lvChangedFiles = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.pnlChangedAssemblies = new System.Windows.Forms.Panel();
            this.lvChangedAssemblies = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.lblChanges = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlGitHub.SuspendLayout();
            this.pnlGridOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlTeamCity.SuspendLayout();
            this.pnlBuildGridAndDetails.SuspendLayout();
            this.pnlBuildDetails.SuspendLayout();
            this.pnlBuildGridButtons.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTeamCity.SuspendLayout();
            this.tabJIRA.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.pnlCommitAndDescription.SuspendLayout();
            this.pnlCommits.SuspendLayout();
            this.pnlChangesDisplay.SuspendLayout();
            this.pnlChangedFilesAndAssemblies.SuspendLayout();
            this.pnlChangedFiles.SuspendLayout();
            this.pnlChangedAssemblies.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1336, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem2,
            this.pullRequestGridOptionsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.teamCityBuildsToolStripMenuItem,
            this.buildDetailsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.changedFilesToolStripMenuItem,
            this.toolStripMenuItem5});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.refreshToolStripMenuItem.Text = "Refresh Pull Requests";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(206, 6);
            // 
            // pullRequestGridOptionsToolStripMenuItem
            // 
            this.pullRequestGridOptionsToolStripMenuItem.Checked = true;
            this.pullRequestGridOptionsToolStripMenuItem.CheckOnClick = true;
            this.pullRequestGridOptionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pullRequestGridOptionsToolStripMenuItem.Name = "pullRequestGridOptionsToolStripMenuItem";
            this.pullRequestGridOptionsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.pullRequestGridOptionsToolStripMenuItem.Text = "Pull Request Grid Options";
            this.pullRequestGridOptionsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.pullRequestGridOptionsToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(206, 6);
            // 
            // teamCityBuildsToolStripMenuItem
            // 
            this.teamCityBuildsToolStripMenuItem.Checked = true;
            this.teamCityBuildsToolStripMenuItem.CheckOnClick = true;
            this.teamCityBuildsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.teamCityBuildsToolStripMenuItem.Name = "teamCityBuildsToolStripMenuItem";
            this.teamCityBuildsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.teamCityBuildsToolStripMenuItem.Text = "Team City Builds";
            this.teamCityBuildsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.teamCityBuildsToolStripMenuItem_CheckedChanged);
            // 
            // buildDetailsToolStripMenuItem
            // 
            this.buildDetailsToolStripMenuItem.Checked = true;
            this.buildDetailsToolStripMenuItem.CheckOnClick = true;
            this.buildDetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buildDetailsToolStripMenuItem.Name = "buildDetailsToolStripMenuItem";
            this.buildDetailsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.buildDetailsToolStripMenuItem.Text = "Build Details";
            this.buildDetailsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.buildDetailsToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(206, 6);
            // 
            // changedFilesToolStripMenuItem
            // 
            this.changedFilesToolStripMenuItem.Checked = true;
            this.changedFilesToolStripMenuItem.CheckOnClick = true;
            this.changedFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changedFilesToolStripMenuItem.Name = "changedFilesToolStripMenuItem";
            this.changedFilesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.changedFilesToolStripMenuItem.Text = "Changed Files";
            this.changedFilesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.changedFilesToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(206, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.branchMonitorToolStripMenuItem,
            this.toolStripMenuItem6,
            this.accountsToolStripMenuItem,
            this.treeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // branchMonitorToolStripMenuItem
            // 
            this.branchMonitorToolStripMenuItem.Checked = true;
            this.branchMonitorToolStripMenuItem.CheckOnClick = true;
            this.branchMonitorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.branchMonitorToolStripMenuItem.Name = "branchMonitorToolStripMenuItem";
            this.branchMonitorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.branchMonitorToolStripMenuItem.Text = "Branch Monitor";
            this.branchMonitorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.branchMonitorToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(154, 6);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1336, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBranch,
            this.lblBranchVersion,
            this.lblVersionFile,
            this.lblAdvUpgradeVersion,
            this.lblPfsConnection,
            this.lblStatus,
            this.lblBranchMonitorStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1336, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = false;
            this.lblBranch.BackColor = System.Drawing.Color.LightBlue;
            this.lblBranch.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(190, 19);
            this.lblBranch.Text = "Branch Name: -";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBranchVersion
            // 
            this.lblBranchVersion.AutoSize = false;
            this.lblBranchVersion.BackColor = System.Drawing.Color.LightBlue;
            this.lblBranchVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblBranchVersion.Name = "lblBranchVersion";
            this.lblBranchVersion.Size = new System.Drawing.Size(165, 19);
            this.lblBranchVersion.Text = "Branch Version: 0.0.0.0";
            this.lblBranchVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersionFile
            // 
            this.lblVersionFile.AutoSize = false;
            this.lblVersionFile.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblVersionFile.Name = "lblVersionFile";
            this.lblVersionFile.Size = new System.Drawing.Size(165, 19);
            this.lblVersionFile.Text = "Version File: 0.0.0.0";
            this.lblVersionFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdvUpgradeVersion
            // 
            this.lblAdvUpgradeVersion.AutoSize = false;
            this.lblAdvUpgradeVersion.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAdvUpgradeVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblAdvUpgradeVersion.Name = "lblAdvUpgradeVersion";
            this.lblAdvUpgradeVersion.Size = new System.Drawing.Size(175, 19);
            this.lblAdvUpgradeVersion.Text = "AdvUpgrade Version: 0.0.0.0";
            this.lblAdvUpgradeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPfsConnection
            // 
            this.lblPfsConnection.AutoSize = false;
            this.lblPfsConnection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblPfsConnection.Name = "lblPfsConnection";
            this.lblPfsConnection.Size = new System.Drawing.Size(250, 19);
            this.lblPfsConnection.Text = "PFS Connection: -";
            this.lblPfsConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(359, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready";
            // 
            // lblBranchMonitorStatus
            // 
            this.lblBranchMonitorStatus.AutoSize = false;
            this.lblBranchMonitorStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblBranchMonitorStatus.Name = "lblBranchMonitorStatus";
            this.lblBranchMonitorStatus.Size = new System.Drawing.Size(17, 19);
            this.lblBranchMonitorStatus.Text = " ";
            this.lblBranchMonitorStatus.ToolTipText = "Branch Monitor Status";
            // 
            // lvWork
            // 
            this.lvWork.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27});
            this.lvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWork.FullRowSelect = true;
            this.lvWork.HideSelection = false;
            this.lvWork.Location = new System.Drawing.Point(1, 75);
            this.lvWork.Name = "lvWork";
            this.lvWork.Size = new System.Drawing.Size(1332, 194);
            this.lvWork.SmallImageList = this.gitHubGridImages;
            this.lvWork.TabIndex = 3;
            this.lvWork.UseCompatibleStateImageBehavior = false;
            this.lvWork.View = System.Windows.Forms.View.Details;
            this.lvWork.DoubleClick += new System.EventHandler(this.lvWork_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Developer";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pull Request";
            this.columnHeader4.Width = 88;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Team";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Fix Version";
            this.columnHeader24.Width = 100;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "JIRA Status";
            this.columnHeader25.Width = 100;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "DB Script";
            this.columnHeader26.Width = 80;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Build Script";
            this.columnHeader27.Width = 75;
            // 
            // gitHubGridImages
            // 
            this.gitHubGridImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("gitHubGridImages.ImageStream")));
            this.gitHubGridImages.TransparentColor = System.Drawing.Color.Transparent;
            this.gitHubGridImages.Images.SetKeyName(0, "BreakpointEnabled_6584_16x.png");
            this.gitHubGridImages.Images.SetKeyName(1, "Security_Shields_Critical_32xSM_color.png");
            this.gitHubGridImages.Images.SetKeyName(2, "Security_Shields_Alert_32xSM_color.png");
            this.gitHubGridImages.Images.SetKeyName(3, "StatusAnnotations_Alert_32xSM_color.png");
            this.gitHubGridImages.Images.SetKeyName(4, "StatusAnnotations_Warning_32xSM_color.png");
            this.gitHubGridImages.Images.SetKeyName(5, "Security_Shields_Complete_and_ok_32xSM_color.png");
            // 
            // pnlGitHub
            // 
            this.pnlGitHub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGitHub.Controls.Add(this.btnShowHideGridOptions);
            this.pnlGitHub.Controls.Add(this.lvWork);
            this.pnlGitHub.Controls.Add(this.pnlGridOptions);
            this.pnlGitHub.Controls.Add(this.label1);
            this.pnlGitHub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGitHub.Location = new System.Drawing.Point(0, 49);
            this.pnlGitHub.Name = "pnlGitHub";
            this.pnlGitHub.Padding = new System.Windows.Forms.Padding(1);
            this.pnlGitHub.Size = new System.Drawing.Size(1336, 272);
            this.pnlGitHub.TabIndex = 4;
            // 
            // btnShowHideGridOptions
            // 
            this.btnShowHideGridOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHideGridOptions.Location = new System.Drawing.Point(1312, 2);
            this.btnShowHideGridOptions.Name = "btnShowHideGridOptions";
            this.btnShowHideGridOptions.Size = new System.Drawing.Size(19, 20);
            this.btnShowHideGridOptions.TabIndex = 12;
            this.btnShowHideGridOptions.Text = "X";
            this.btnShowHideGridOptions.UseVisualStyleBackColor = true;
            this.btnShowHideGridOptions.Click += new System.EventHandler(this.btnShowHideGridOptions_Click);
            // 
            // pnlGridOptions
            // 
            this.pnlGridOptions.Controls.Add(this.groupBox3);
            this.pnlGridOptions.Controls.Add(this.groupBox1);
            this.pnlGridOptions.Controls.Add(this.groupBox2);
            this.pnlGridOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridOptions.Location = new System.Drawing.Point(1, 23);
            this.pnlGridOptions.Name = "pnlGridOptions";
            this.pnlGridOptions.Padding = new System.Windows.Forms.Padding(2);
            this.pnlGridOptions.Size = new System.Drawing.Size(1332, 52);
            this.pnlGridOptions.TabIndex = 6;
            this.pnlGridOptions.VisibleChanged += new System.EventHandler(this.pnlGridOptions_VisibleChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSortTeam);
            this.groupBox3.Controls.Add(this.rbSortId);
            this.groupBox3.Controls.Add(this.rbSortStatus);
            this.groupBox3.Controls.Add(this.rbSortDeveloper);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(819, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort By";
            // 
            // rbSortTeam
            // 
            this.rbSortTeam.AutoSize = true;
            this.rbSortTeam.Location = new System.Drawing.Point(239, 19);
            this.rbSortTeam.Name = "rbSortTeam";
            this.rbSortTeam.Size = new System.Drawing.Size(52, 17);
            this.rbSortTeam.TabIndex = 6;
            this.rbSortTeam.Tag = "3";
            this.rbSortTeam.Text = "Team";
            this.rbSortTeam.UseVisualStyleBackColor = true;
            this.rbSortTeam.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortId
            // 
            this.rbSortId.AutoSize = true;
            this.rbSortId.Checked = true;
            this.rbSortId.Location = new System.Drawing.Point(15, 18);
            this.rbSortId.Name = "rbSortId";
            this.rbSortId.Size = new System.Drawing.Size(77, 17);
            this.rbSortId.TabIndex = 5;
            this.rbSortId.TabStop = true;
            this.rbSortId.Tag = "0";
            this.rbSortId.Text = "Request Id";
            this.rbSortId.UseVisualStyleBackColor = true;
            this.rbSortId.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortStatus
            // 
            this.rbSortStatus.AutoSize = true;
            this.rbSortStatus.Location = new System.Drawing.Point(178, 19);
            this.rbSortStatus.Name = "rbSortStatus";
            this.rbSortStatus.Size = new System.Drawing.Size(55, 17);
            this.rbSortStatus.TabIndex = 4;
            this.rbSortStatus.Tag = "2";
            this.rbSortStatus.Text = "Status";
            this.rbSortStatus.UseVisualStyleBackColor = true;
            this.rbSortStatus.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortDeveloper
            // 
            this.rbSortDeveloper.AutoSize = true;
            this.rbSortDeveloper.Location = new System.Drawing.Point(98, 19);
            this.rbSortDeveloper.Name = "rbSortDeveloper";
            this.rbSortDeveloper.Size = new System.Drawing.Size(74, 17);
            this.rbSortDeveloper.TabIndex = 3;
            this.rbSortDeveloper.Tag = "1";
            this.rbSortDeveloper.Text = "Developer";
            this.rbSortDeveloper.UseVisualStyleBackColor = true;
            this.rbSortDeveloper.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rbGroupNone);
            this.groupBox1.Controls.Add(this.rbGroupStatus);
            this.groupBox1.Controls.Add(this.rbGroupDeveloper);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(561, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group By";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(204, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Tag = "3";
            this.radioButton1.Text = "Team";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // rbGroupNone
            // 
            this.rbGroupNone.AutoSize = true;
            this.rbGroupNone.Checked = true;
            this.rbGroupNone.Location = new System.Drawing.Point(6, 19);
            this.rbGroupNone.Name = "rbGroupNone";
            this.rbGroupNone.Size = new System.Drawing.Size(51, 17);
            this.rbGroupNone.TabIndex = 2;
            this.rbGroupNone.TabStop = true;
            this.rbGroupNone.Tag = "0";
            this.rbGroupNone.Text = "None";
            this.rbGroupNone.UseVisualStyleBackColor = true;
            this.rbGroupNone.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // rbGroupStatus
            // 
            this.rbGroupStatus.AutoSize = true;
            this.rbGroupStatus.Location = new System.Drawing.Point(143, 19);
            this.rbGroupStatus.Name = "rbGroupStatus";
            this.rbGroupStatus.Size = new System.Drawing.Size(55, 17);
            this.rbGroupStatus.TabIndex = 1;
            this.rbGroupStatus.Tag = "2";
            this.rbGroupStatus.Text = "Status";
            this.rbGroupStatus.UseVisualStyleBackColor = true;
            this.rbGroupStatus.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // rbGroupDeveloper
            // 
            this.rbGroupDeveloper.AutoSize = true;
            this.rbGroupDeveloper.Location = new System.Drawing.Point(63, 19);
            this.rbGroupDeveloper.Name = "rbGroupDeveloper";
            this.rbGroupDeveloper.Size = new System.Drawing.Size(74, 17);
            this.rbGroupDeveloper.TabIndex = 0;
            this.rbGroupDeveloper.Tag = "1";
            this.rbGroupDeveloper.Text = "Developer";
            this.rbGroupDeveloper.UseVisualStyleBackColor = true;
            this.rbGroupDeveloper.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFilterApproved);
            this.groupBox2.Controls.Add(this.chkFilterQA);
            this.groupBox2.Controls.Add(this.chkFilterInProgress);
            this.groupBox2.Controls.Add(this.chkFilterCloud);
            this.groupBox2.Controls.Add(this.chkFilterAMS);
            this.groupBox2.Controls.Add(this.chkFilterRD);
            this.groupBox2.Controls.Add(this.chkFilterClosed);
            this.groupBox2.Controls.Add(this.chkFilterOpen);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter On";
            // 
            // chkFilterApproved
            // 
            this.chkFilterApproved.AutoSize = true;
            this.chkFilterApproved.Location = new System.Drawing.Point(482, 18);
            this.chkFilterApproved.Name = "chkFilterApproved";
            this.chkFilterApproved.Size = new System.Drawing.Size(72, 17);
            this.chkFilterApproved.TabIndex = 7;
            this.chkFilterApproved.Text = "Approved";
            this.chkFilterApproved.UseVisualStyleBackColor = true;
            this.chkFilterApproved.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterQA
            // 
            this.chkFilterQA.AutoSize = true;
            this.chkFilterQA.Checked = true;
            this.chkFilterQA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterQA.Location = new System.Drawing.Point(435, 18);
            this.chkFilterQA.Name = "chkFilterQA";
            this.chkFilterQA.Size = new System.Drawing.Size(41, 17);
            this.chkFilterQA.TabIndex = 6;
            this.chkFilterQA.Text = "QA";
            this.chkFilterQA.UseVisualStyleBackColor = true;
            this.chkFilterQA.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterInProgress
            // 
            this.chkFilterInProgress.AutoSize = true;
            this.chkFilterInProgress.Checked = true;
            this.chkFilterInProgress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterInProgress.Location = new System.Drawing.Point(350, 18);
            this.chkFilterInProgress.Name = "chkFilterInProgress";
            this.chkFilterInProgress.Size = new System.Drawing.Size(79, 17);
            this.chkFilterInProgress.TabIndex = 5;
            this.chkFilterInProgress.Text = "In Progress";
            this.chkFilterInProgress.UseVisualStyleBackColor = true;
            this.chkFilterInProgress.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterCloud
            // 
            this.chkFilterCloud.AutoSize = true;
            this.chkFilterCloud.Location = new System.Drawing.Point(267, 18);
            this.chkFilterCloud.Name = "chkFilterCloud";
            this.chkFilterCloud.Size = new System.Drawing.Size(53, 17);
            this.chkFilterCloud.TabIndex = 4;
            this.chkFilterCloud.Text = "Cloud";
            this.chkFilterCloud.UseVisualStyleBackColor = true;
            this.chkFilterCloud.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterAMS
            // 
            this.chkFilterAMS.AutoSize = true;
            this.chkFilterAMS.Checked = true;
            this.chkFilterAMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAMS.Location = new System.Drawing.Point(212, 18);
            this.chkFilterAMS.Name = "chkFilterAMS";
            this.chkFilterAMS.Size = new System.Drawing.Size(49, 17);
            this.chkFilterAMS.TabIndex = 3;
            this.chkFilterAMS.Text = "AMS";
            this.chkFilterAMS.UseVisualStyleBackColor = true;
            this.chkFilterAMS.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterRD
            // 
            this.chkFilterRD.AutoSize = true;
            this.chkFilterRD.Checked = true;
            this.chkFilterRD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterRD.Location = new System.Drawing.Point(152, 18);
            this.chkFilterRD.Name = "chkFilterRD";
            this.chkFilterRD.Size = new System.Drawing.Size(54, 17);
            this.chkFilterRD.TabIndex = 2;
            this.chkFilterRD.Text = "R && D";
            this.chkFilterRD.UseVisualStyleBackColor = true;
            this.chkFilterRD.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterClosed
            // 
            this.chkFilterClosed.AutoSize = true;
            this.chkFilterClosed.Location = new System.Drawing.Point(70, 19);
            this.chkFilterClosed.Name = "chkFilterClosed";
            this.chkFilterClosed.Size = new System.Drawing.Size(58, 17);
            this.chkFilterClosed.TabIndex = 1;
            this.chkFilterClosed.Text = "Closed";
            this.chkFilterClosed.UseVisualStyleBackColor = true;
            this.chkFilterClosed.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // chkFilterOpen
            // 
            this.chkFilterOpen.AutoSize = true;
            this.chkFilterOpen.Checked = true;
            this.chkFilterOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterOpen.Location = new System.Drawing.Point(12, 19);
            this.chkFilterOpen.Name = "chkFilterOpen";
            this.chkFilterOpen.Size = new System.Drawing.Size(52, 17);
            this.chkFilterOpen.TabIndex = 0;
            this.chkFilterOpen.Text = "Open";
            this.chkFilterOpen.UseVisualStyleBackColor = true;
            this.chkFilterOpen.CheckedChanged += new System.EventHandler(this.chkPullRequestFilter_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1332, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pull Requests";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTeamCity
            // 
            this.pnlTeamCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeamCity.Controls.Add(this.btnHideBuildsPanel);
            this.pnlTeamCity.Controls.Add(this.pnlBuildGridAndDetails);
            this.pnlTeamCity.Controls.Add(this.pnlBuildGridButtons);
            this.pnlTeamCity.Controls.Add(this.label2);
            this.pnlTeamCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeamCity.Location = new System.Drawing.Point(3, 3);
            this.pnlTeamCity.Name = "pnlTeamCity";
            this.pnlTeamCity.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTeamCity.Size = new System.Drawing.Size(666, 263);
            this.pnlTeamCity.TabIndex = 6;
            // 
            // btnHideBuildsPanel
            // 
            this.btnHideBuildsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideBuildsPanel.Location = new System.Drawing.Point(641, 4);
            this.btnHideBuildsPanel.Name = "btnHideBuildsPanel";
            this.btnHideBuildsPanel.Size = new System.Drawing.Size(15, 15);
            this.btnHideBuildsPanel.TabIndex = 11;
            this.btnHideBuildsPanel.Text = "^";
            this.btnHideBuildsPanel.UseVisualStyleBackColor = true;
            this.btnHideBuildsPanel.Click += new System.EventHandler(this.btnHideBuildsPanel_Click);
            // 
            // pnlBuildGridAndDetails
            // 
            this.pnlBuildGridAndDetails.Controls.Add(this.pnlBuildDetails);
            this.pnlBuildGridAndDetails.Controls.Add(this.splitter3);
            this.pnlBuildGridAndDetails.Controls.Add(this.lvBuilds);
            this.pnlBuildGridAndDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuildGridAndDetails.Location = new System.Drawing.Point(1, 56);
            this.pnlBuildGridAndDetails.Name = "pnlBuildGridAndDetails";
            this.pnlBuildGridAndDetails.Size = new System.Drawing.Size(662, 204);
            this.pnlBuildGridAndDetails.TabIndex = 10;
            // 
            // pnlBuildDetails
            // 
            this.pnlBuildDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBuildDetails.Controls.Add(this.label18);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailStatusText);
            this.pnlBuildDetails.Controls.Add(this.label17);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailQueued);
            this.pnlBuildDetails.Controls.Add(this.label16);
            this.pnlBuildDetails.Controls.Add(this.txtChangeDev);
            this.pnlBuildDetails.Controls.Add(this.label15);
            this.pnlBuildDetails.Controls.Add(this.txtChangeVersion);
            this.pnlBuildDetails.Controls.Add(this.label14);
            this.pnlBuildDetails.Controls.Add(this.txtChangeId);
            this.pnlBuildDetails.Controls.Add(this.label9);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailPlan);
            this.pnlBuildDetails.Controls.Add(this.label8);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailDuration);
            this.pnlBuildDetails.Controls.Add(this.label7);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailState);
            this.pnlBuildDetails.Controls.Add(this.label6);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailFinished);
            this.pnlBuildDetails.Controls.Add(this.label5);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailStatus);
            this.pnlBuildDetails.Controls.Add(this.label4);
            this.pnlBuildDetails.Controls.Add(this.btnHideBuildDetails);
            this.pnlBuildDetails.Controls.Add(this.txtBuildDetailStarted);
            this.pnlBuildDetails.Controls.Add(this.lblBuildDetails);
            this.pnlBuildDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuildDetails.Location = new System.Drawing.Point(0, 158);
            this.pnlBuildDetails.Name = "pnlBuildDetails";
            this.pnlBuildDetails.Size = new System.Drawing.Size(662, 46);
            this.pnlBuildDetails.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(199, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "Message:";
            // 
            // txtBuildDetailStatusText
            // 
            this.txtBuildDetailStatusText.Location = new System.Drawing.Point(258, 51);
            this.txtBuildDetailStatusText.Name = "txtBuildDetailStatusText";
            this.txtBuildDetailStatusText.Size = new System.Drawing.Size(153, 20);
            this.txtBuildDetailStatusText.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Queued:";
            // 
            // txtBuildDetailQueued
            // 
            this.txtBuildDetailQueued.Location = new System.Drawing.Point(64, 25);
            this.txtBuildDetailQueued.Name = "txtBuildDetailQueued";
            this.txtBuildDetailQueued.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailQueued.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(605, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Dev:";
            // 
            // txtChangeDev
            // 
            this.txtChangeDev.Location = new System.Drawing.Point(641, 76);
            this.txtChangeDev.Name = "txtChangeDev";
            this.txtChangeDev.Size = new System.Drawing.Size(131, 20);
            this.txtChangeDev.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Commit:";
            // 
            // txtChangeVersion
            // 
            this.txtChangeVersion.Location = new System.Drawing.Point(258, 76);
            this.txtChangeVersion.Name = "txtChangeVersion";
            this.txtChangeVersion.Size = new System.Drawing.Size(325, 20);
            this.txtChangeVersion.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Change Id:";
            // 
            // txtChangeId
            // 
            this.txtChangeId.Location = new System.Drawing.Point(64, 76);
            this.txtChangeId.Name = "txtChangeId";
            this.txtChangeId.Size = new System.Drawing.Size(131, 20);
            this.txtChangeId.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Plan:";
            // 
            // txtBuildDetailPlan
            // 
            this.txtBuildDetailPlan.Location = new System.Drawing.Point(641, 51);
            this.txtBuildDetailPlan.Name = "txtBuildDetailPlan";
            this.txtBuildDetailPlan.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailPlan.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Duration:";
            // 
            // txtBuildDetailDuration
            // 
            this.txtBuildDetailDuration.Location = new System.Drawing.Point(641, 25);
            this.txtBuildDetailDuration.Name = "txtBuildDetailDuration";
            this.txtBuildDetailDuration.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailDuration.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "State:";
            // 
            // txtBuildDetailState
            // 
            this.txtBuildDetailState.Location = new System.Drawing.Point(452, 51);
            this.txtBuildDetailState.Name = "txtBuildDetailState";
            this.txtBuildDetailState.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailState.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Finished:";
            // 
            // txtBuildDetailFinished
            // 
            this.txtBuildDetailFinished.Location = new System.Drawing.Point(452, 25);
            this.txtBuildDetailFinished.Name = "txtBuildDetailFinished";
            this.txtBuildDetailFinished.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailFinished.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Status:";
            // 
            // txtBuildDetailStatus
            // 
            this.txtBuildDetailStatus.Location = new System.Drawing.Point(64, 51);
            this.txtBuildDetailStatus.Name = "txtBuildDetailStatus";
            this.txtBuildDetailStatus.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailStatus.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Started:";
            // 
            // btnHideBuildDetails
            // 
            this.btnHideBuildDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideBuildDetails.Location = new System.Drawing.Point(638, 3);
            this.btnHideBuildDetails.Name = "btnHideBuildDetails";
            this.btnHideBuildDetails.Size = new System.Drawing.Size(15, 15);
            this.btnHideBuildDetails.TabIndex = 9;
            this.btnHideBuildDetails.Text = "^";
            this.btnHideBuildDetails.UseVisualStyleBackColor = true;
            this.btnHideBuildDetails.Click += new System.EventHandler(this.btnHideBuildDetails_Click);
            // 
            // txtBuildDetailStarted
            // 
            this.txtBuildDetailStarted.Location = new System.Drawing.Point(258, 25);
            this.txtBuildDetailStarted.Name = "txtBuildDetailStarted";
            this.txtBuildDetailStarted.Size = new System.Drawing.Size(131, 20);
            this.txtBuildDetailStarted.TabIndex = 8;
            // 
            // lblBuildDetails
            // 
            this.lblBuildDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.lblBuildDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBuildDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBuildDetails.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBuildDetails.Location = new System.Drawing.Point(0, 0);
            this.lblBuildDetails.Name = "lblBuildDetails";
            this.lblBuildDetails.Size = new System.Drawing.Size(658, 20);
            this.lblBuildDetails.TabIndex = 7;
            this.lblBuildDetails.Text = "Build Details";
            this.lblBuildDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 155);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(662, 3);
            this.splitter3.TabIndex = 10;
            this.splitter3.TabStop = false;
            // 
            // lvBuilds
            // 
            this.lvBuilds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader11});
            this.lvBuilds.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvBuilds.FullRowSelect = true;
            this.lvBuilds.HideSelection = false;
            this.lvBuilds.Location = new System.Drawing.Point(0, 0);
            this.lvBuilds.Name = "lvBuilds";
            this.lvBuilds.Size = new System.Drawing.Size(662, 155);
            this.lvBuilds.TabIndex = 8;
            this.lvBuilds.UseCompatibleStateImageBehavior = false;
            this.lvBuilds.View = System.Windows.Forms.View.Details;
            this.lvBuilds.DoubleClick += new System.EventHandler(this.lvBuilds_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "%";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Build #";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Branch";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "State";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Plan";
            this.columnHeader11.Width = 150;
            // 
            // pnlBuildGridButtons
            // 
            this.pnlBuildGridButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuildGridButtons.Controls.Add(this.btnScan);
            this.pnlBuildGridButtons.Controls.Add(this.btnAdvantageBuilds);
            this.pnlBuildGridButtons.Controls.Add(this.label3);
            this.pnlBuildGridButtons.Controls.Add(this.btnPatchBuilds);
            this.pnlBuildGridButtons.Controls.Add(this.txtPullRequestNumber);
            this.pnlBuildGridButtons.Controls.Add(this.btnSearchBuilds);
            this.pnlBuildGridButtons.Controls.Add(this.btnRunningBuilds);
            this.pnlBuildGridButtons.Controls.Add(this.btnBuildHistory);
            this.pnlBuildGridButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuildGridButtons.Location = new System.Drawing.Point(1, 21);
            this.pnlBuildGridButtons.Name = "pnlBuildGridButtons";
            this.pnlBuildGridButtons.Size = new System.Drawing.Size(662, 35);
            this.pnlBuildGridButtons.TabIndex = 7;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(329, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 7;
            this.btnScan.Text = "Sec. Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnAdvantageBuilds
            // 
            this.btnAdvantageBuilds.Location = new System.Drawing.Point(248, 4);
            this.btnAdvantageBuilds.Name = "btnAdvantageBuilds";
            this.btnAdvantageBuilds.Size = new System.Drawing.Size(75, 23);
            this.btnAdvantageBuilds.TabIndex = 6;
            this.btnAdvantageBuilds.Text = "Advantage";
            this.btnAdvantageBuilds.UseVisualStyleBackColor = true;
            this.btnAdvantageBuilds.Click += new System.EventHandler(this.btnAdvantageBuilds_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Branch Name:";
            // 
            // btnPatchBuilds
            // 
            this.btnPatchBuilds.Location = new System.Drawing.Point(167, 4);
            this.btnPatchBuilds.Name = "btnPatchBuilds";
            this.btnPatchBuilds.Size = new System.Drawing.Size(75, 23);
            this.btnPatchBuilds.TabIndex = 4;
            this.btnPatchBuilds.Text = "Patches";
            this.btnPatchBuilds.UseVisualStyleBackColor = true;
            this.btnPatchBuilds.Click += new System.EventHandler(this.btnPatchBuilds_Click);
            // 
            // txtPullRequestNumber
            // 
            this.txtPullRequestNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPullRequestNumber.Location = new System.Drawing.Point(458, 5);
            this.txtPullRequestNumber.Name = "txtPullRequestNumber";
            this.txtPullRequestNumber.Size = new System.Drawing.Size(131, 20);
            this.txtPullRequestNumber.TabIndex = 3;
            // 
            // btnSearchBuilds
            // 
            this.btnSearchBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchBuilds.Location = new System.Drawing.Point(597, 4);
            this.btnSearchBuilds.Name = "btnSearchBuilds";
            this.btnSearchBuilds.Size = new System.Drawing.Size(55, 23);
            this.btnSearchBuilds.TabIndex = 2;
            this.btnSearchBuilds.Text = "Search";
            this.btnSearchBuilds.UseVisualStyleBackColor = true;
            this.btnSearchBuilds.Click += new System.EventHandler(this.btnSearchBuilds_Click);
            // 
            // btnRunningBuilds
            // 
            this.btnRunningBuilds.Location = new System.Drawing.Point(86, 4);
            this.btnRunningBuilds.Name = "btnRunningBuilds";
            this.btnRunningBuilds.Size = new System.Drawing.Size(75, 23);
            this.btnRunningBuilds.TabIndex = 1;
            this.btnRunningBuilds.Text = "Running";
            this.btnRunningBuilds.UseVisualStyleBackColor = true;
            this.btnRunningBuilds.Click += new System.EventHandler(this.btnRunningBuilds_Click);
            // 
            // btnBuildHistory
            // 
            this.btnBuildHistory.Location = new System.Drawing.Point(5, 4);
            this.btnBuildHistory.Name = "btnBuildHistory";
            this.btnBuildHistory.Size = new System.Drawing.Size(75, 23);
            this.btnBuildHistory.TabIndex = 0;
            this.btnBuildHistory.Text = "All";
            this.btnBuildHistory.UseVisualStyleBackColor = true;
            this.btnBuildHistory.Click += new System.EventHandler(this.btnBuildHistory_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(662, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Builds";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTeamCity);
            this.tabControl1.Controls.Add(this.tabJIRA);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(656, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 295);
            this.tabControl1.TabIndex = 7;
            // 
            // tabTeamCity
            // 
            this.tabTeamCity.Controls.Add(this.pnlTeamCity);
            this.tabTeamCity.Location = new System.Drawing.Point(4, 22);
            this.tabTeamCity.Name = "tabTeamCity";
            this.tabTeamCity.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeamCity.Size = new System.Drawing.Size(672, 269);
            this.tabTeamCity.TabIndex = 0;
            this.tabTeamCity.Text = "Builds";
            this.tabTeamCity.UseVisualStyleBackColor = true;
            // 
            // tabJIRA
            // 
            this.tabJIRA.Controls.Add(this.panel4);
            this.tabJIRA.Location = new System.Drawing.Point(4, 22);
            this.tabJIRA.Name = "tabJIRA";
            this.tabJIRA.Padding = new System.Windows.Forms.Padding(3);
            this.tabJIRA.Size = new System.Drawing.Size(672, 269);
            this.tabJIRA.TabIndex = 1;
            this.tabJIRA.Text = "JIRA";
            this.tabJIRA.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.lvJira);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(666, 263);
            this.panel4.TabIndex = 6;
            // 
            // lvJira
            // 
            this.lvJira.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader12,
            this.columnHeader28});
            this.lvJira.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvJira.FullRowSelect = true;
            this.lvJira.Location = new System.Drawing.Point(4, 23);
            this.lvJira.Name = "lvJira";
            this.lvJira.Size = new System.Drawing.Size(658, 236);
            this.lvJira.TabIndex = 0;
            this.lvJira.UseCompatibleStateImageBehavior = false;
            this.lvJira.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "JIRA #";
            this.columnHeader17.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Team";
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Title";
            this.columnHeader19.Width = 450;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Status";
            this.columnHeader20.Width = 80;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Fix Version";
            this.columnHeader21.Width = 80;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Priority";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Issue Type";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Epic";
            this.columnHeader28.Width = 125;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(4, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(658, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "JIRA Issues";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Controls.Add(this.tabControl1);
            this.pnlTabControl.Controls.Add(this.splitter2);
            this.pnlTabControl.Controls.Add(this.pnlCommitAndDescription);
            this.pnlTabControl.Controls.Add(this.splitter4);
            this.pnlTabControl.Controls.Add(this.pnlChangesDisplay);
            this.pnlTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabControl.Location = new System.Drawing.Point(0, 321);
            this.pnlTabControl.Name = "pnlTabControl";
            this.pnlTabControl.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlTabControl.Size = new System.Drawing.Size(1336, 303);
            this.pnlTabControl.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(653, 8);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 295);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // pnlCommitAndDescription
            // 
            this.pnlCommitAndDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommitAndDescription.Controls.Add(this.splitter5);
            this.pnlCommitAndDescription.Controls.Add(this.pnlCommits);
            this.pnlCommitAndDescription.Controls.Add(this.txtCommitDescription);
            this.pnlCommitAndDescription.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCommitAndDescription.Location = new System.Drawing.Point(357, 8);
            this.pnlCommitAndDescription.Name = "pnlCommitAndDescription";
            this.pnlCommitAndDescription.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCommitAndDescription.Size = new System.Drawing.Size(296, 295);
            this.pnlCommitAndDescription.TabIndex = 7;
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter5.Location = new System.Drawing.Point(4, 144);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(286, 3);
            this.splitter5.TabIndex = 7;
            this.splitter5.TabStop = false;
            // 
            // pnlCommits
            // 
            this.pnlCommits.BackColor = System.Drawing.Color.SlateGray;
            this.pnlCommits.Controls.Add(this.lvCommits);
            this.pnlCommits.Controls.Add(this.label12);
            this.pnlCommits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommits.Location = new System.Drawing.Point(4, 4);
            this.pnlCommits.Name = "pnlCommits";
            this.pnlCommits.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCommits.Size = new System.Drawing.Size(286, 143);
            this.pnlCommits.TabIndex = 5;
            // 
            // lvCommits
            // 
            this.lvCommits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader16});
            this.lvCommits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCommits.FullRowSelect = true;
            this.lvCommits.Location = new System.Drawing.Point(4, 23);
            this.lvCommits.Name = "lvCommits";
            this.lvCommits.Size = new System.Drawing.Size(278, 116);
            this.lvCommits.TabIndex = 0;
            this.lvCommits.UseCompatibleStateImageBehavior = false;
            this.lvCommits.View = System.Windows.Forms.View.Details;
            this.lvCommits.SelectedIndexChanged += new System.EventHandler(this.lvCommits_SelectedIndexChanged);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Commit #";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Description";
            this.columnHeader16.Width = 250;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightSlateGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(4, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Commits";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCommitDescription
            // 
            this.txtCommitDescription.AcceptsReturn = true;
            this.txtCommitDescription.AcceptsTab = true;
            this.txtCommitDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCommitDescription.Location = new System.Drawing.Point(4, 147);
            this.txtCommitDescription.Multiline = true;
            this.txtCommitDescription.Name = "txtCommitDescription";
            this.txtCommitDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommitDescription.Size = new System.Drawing.Size(286, 142);
            this.txtCommitDescription.TabIndex = 6;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(354, 8);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 295);
            this.splitter4.TabIndex = 9;
            this.splitter4.TabStop = false;
            // 
            // pnlChangesDisplay
            // 
            this.pnlChangesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChangesDisplay.Controls.Add(this.btnHideChangedFilesAndAssemblies);
            this.pnlChangesDisplay.Controls.Add(this.pnlChangedFilesAndAssemblies);
            this.pnlChangesDisplay.Controls.Add(this.lblChanges);
            this.pnlChangesDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChangesDisplay.Location = new System.Drawing.Point(0, 8);
            this.pnlChangesDisplay.Name = "pnlChangesDisplay";
            this.pnlChangesDisplay.Size = new System.Drawing.Size(354, 295);
            this.pnlChangesDisplay.TabIndex = 8;
            // 
            // btnHideChangedFilesAndAssemblies
            // 
            this.btnHideChangedFilesAndAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideChangedFilesAndAssemblies.Location = new System.Drawing.Point(327, 1);
            this.btnHideChangedFilesAndAssemblies.Name = "btnHideChangedFilesAndAssemblies";
            this.btnHideChangedFilesAndAssemblies.Size = new System.Drawing.Size(22, 23);
            this.btnHideChangedFilesAndAssemblies.TabIndex = 6;
            this.btnHideChangedFilesAndAssemblies.Text = "<";
            this.btnHideChangedFilesAndAssemblies.UseVisualStyleBackColor = true;
            this.btnHideChangedFilesAndAssemblies.Click += new System.EventHandler(this.btnHideChangedFilesAndAssemblies_Click);
            // 
            // pnlChangedFilesAndAssemblies
            // 
            this.pnlChangedFilesAndAssemblies.Controls.Add(this.pnlChangedFiles);
            this.pnlChangedFilesAndAssemblies.Controls.Add(this.pnlChangedAssemblies);
            this.pnlChangedFilesAndAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChangedFilesAndAssemblies.Location = new System.Drawing.Point(0, 26);
            this.pnlChangedFilesAndAssemblies.Name = "pnlChangedFilesAndAssemblies";
            this.pnlChangedFilesAndAssemblies.Padding = new System.Windows.Forms.Padding(2);
            this.pnlChangedFilesAndAssemblies.Size = new System.Drawing.Size(352, 267);
            this.pnlChangedFilesAndAssemblies.TabIndex = 4;
            // 
            // pnlChangedFiles
            // 
            this.pnlChangedFiles.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnlChangedFiles.Controls.Add(this.lvChangedFiles);
            this.pnlChangedFiles.Controls.Add(this.label10);
            this.pnlChangedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChangedFiles.Location = new System.Drawing.Point(2, 117);
            this.pnlChangedFiles.Name = "pnlChangedFiles";
            this.pnlChangedFiles.Padding = new System.Windows.Forms.Padding(4);
            this.pnlChangedFiles.Size = new System.Drawing.Size(348, 148);
            this.pnlChangedFiles.TabIndex = 1;
            // 
            // lvChangedFiles
            // 
            this.lvChangedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13});
            this.lvChangedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChangedFiles.FullRowSelect = true;
            this.lvChangedFiles.Location = new System.Drawing.Point(4, 23);
            this.lvChangedFiles.Name = "lvChangedFiles";
            this.lvChangedFiles.Size = new System.Drawing.Size(340, 121);
            this.lvChangedFiles.TabIndex = 0;
            this.lvChangedFiles.UseCompatibleStateImageBehavior = false;
            this.lvChangedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "File";
            this.columnHeader13.Width = 450;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Khaki;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(340, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Files";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChangedAssemblies
            // 
            this.pnlChangedAssemblies.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlChangedAssemblies.Controls.Add(this.lvChangedAssemblies);
            this.pnlChangedAssemblies.Controls.Add(this.label11);
            this.pnlChangedAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChangedAssemblies.Location = new System.Drawing.Point(2, 2);
            this.pnlChangedAssemblies.Name = "pnlChangedAssemblies";
            this.pnlChangedAssemblies.Padding = new System.Windows.Forms.Padding(4);
            this.pnlChangedAssemblies.Size = new System.Drawing.Size(348, 115);
            this.pnlChangedAssemblies.TabIndex = 2;
            // 
            // lvChangedAssemblies
            // 
            this.lvChangedAssemblies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15});
            this.lvChangedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChangedAssemblies.FullRowSelect = true;
            this.lvChangedAssemblies.Location = new System.Drawing.Point(4, 23);
            this.lvChangedAssemblies.Name = "lvChangedAssemblies";
            this.lvChangedAssemblies.Size = new System.Drawing.Size(340, 88);
            this.lvChangedAssemblies.TabIndex = 0;
            this.lvChangedAssemblies.UseCompatibleStateImageBehavior = false;
            this.lvChangedAssemblies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Assembly";
            this.columnHeader15.Width = 450;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(340, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Assemblies";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChanges
            // 
            this.lblChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChanges.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChanges.Location = new System.Drawing.Point(0, 0);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(352, 26);
            this.lblChanges.TabIndex = 5;
            this.lblChanges.Text = "Changed Files and Assemblies";
            this.lblChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 321);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1336, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // treeToolStripMenuItem
            // 
            this.treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            this.treeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.treeToolStripMenuItem.Text = "tree";
            this.treeToolStripMenuItem.Click += new System.EventHandler(this.treeToolStripMenuItem_Click);
            // 
            // CodeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 648);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTabControl);
            this.Controls.Add(this.pnlGitHub);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CodeManager";
            this.Text = "CE Pull Requests";
            this.Load += new System.EventHandler(this.CodeManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlGitHub.ResumeLayout(false);
            this.pnlGridOptions.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlTeamCity.ResumeLayout(false);
            this.pnlBuildGridAndDetails.ResumeLayout(false);
            this.pnlBuildDetails.ResumeLayout(false);
            this.pnlBuildDetails.PerformLayout();
            this.pnlBuildGridButtons.ResumeLayout(false);
            this.pnlBuildGridButtons.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTeamCity.ResumeLayout(false);
            this.tabJIRA.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.pnlCommitAndDescription.ResumeLayout(false);
            this.pnlCommitAndDescription.PerformLayout();
            this.pnlCommits.ResumeLayout(false);
            this.pnlChangesDisplay.ResumeLayout(false);
            this.pnlChangedFilesAndAssemblies.ResumeLayout(false);
            this.pnlChangedFiles.ResumeLayout(false);
            this.pnlChangedAssemblies.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblBranch;
        private System.Windows.Forms.ToolStripStatusLabel lblVersionFile;
        private System.Windows.Forms.ToolStripStatusLabel lblBranchVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblAdvUpgradeVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblPfsConnection;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblBranchMonitorStatus;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ListView lvWork;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel pnlGitHub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlGridOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbSortId;
        private System.Windows.Forms.RadioButton rbSortStatus;
        private System.Windows.Forms.RadioButton rbSortDeveloper;
        private System.Windows.Forms.RadioButton rbGroupNone;
        private System.Windows.Forms.RadioButton rbGroupStatus;
        private System.Windows.Forms.RadioButton rbGroupDeveloper;
        private System.Windows.Forms.CheckBox chkFilterClosed;
        private System.Windows.Forms.CheckBox chkFilterOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem teamCityBuildsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTeamCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBuildGridButtons;
        private System.Windows.Forms.Button btnBuildHistory;
        private System.Windows.Forms.ListView lvBuilds;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnRunningBuilds;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TextBox txtPullRequestNumber;
        private System.Windows.Forms.Button btnSearchBuilds;
        private System.Windows.Forms.Button btnPatchBuilds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBuildGridAndDetails;
        private System.Windows.Forms.Panel pnlBuildDetails;
        private System.Windows.Forms.Label lblBuildDetails;
        private System.Windows.Forms.TextBox txtBuildDetailStarted;
        private System.Windows.Forms.Button btnHideBuildDetails;
        private System.Windows.Forms.ToolStripMenuItem buildDetailsToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuildDetailState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuildDetailFinished;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuildDetailStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBuildDetailDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBuildDetailPlan;
        private System.Windows.Forms.Button btnHideBuildsPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTeamCity;
        private System.Windows.Forms.TabPage tabJIRA;
        private System.Windows.Forms.Panel pnlTabControl;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox chkFilterCloud;
        private System.Windows.Forms.CheckBox chkFilterAMS;
        private System.Windows.Forms.CheckBox chkFilterRD;
        private System.Windows.Forms.CheckBox chkFilterQA;
        private System.Windows.Forms.CheckBox chkFilterInProgress;
        private System.Windows.Forms.Button btnShowHideGridOptions;
        private System.Windows.Forms.ToolStripMenuItem pullRequestGridOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem changedFilesToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvJira;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.CheckBox chkFilterApproved;
        private System.Windows.Forms.RadioButton rbSortTeam;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ImageList gitHubGridImages;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.Button btnAdvantageBuilds;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtChangeVersion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtChangeId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBuildDetailQueued;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtChangeDev;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBuildDetailStatusText;
        private System.Windows.Forms.Panel pnlChangesDisplay;
        private System.Windows.Forms.Label lblChanges;
        private System.Windows.Forms.Panel pnlChangedFilesAndAssemblies;
        private System.Windows.Forms.Panel pnlChangedFiles;
        private System.Windows.Forms.ListView lvChangedFiles;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlChangedAssemblies;
        private System.Windows.Forms.ListView lvChangedAssemblies;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHideChangedFilesAndAssemblies;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel pnlCommitAndDescription;
        private System.Windows.Forms.Panel pnlCommits;
        private System.Windows.Forms.ListView lvCommits;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCommitDescription;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.ToolStripMenuItem treeToolStripMenuItem;
    }
}

