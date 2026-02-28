namespace DeepCleanPro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._txtLogs = new System.Windows.Forms.RichTextBox();
            this._btnStart = new System.Windows.Forms.Button();
            this._chkSim = new System.Windows.Forms.CheckBox();
            this._lblStatus = new System.Windows.Forms.Label();
            this._pnlHeader = new System.Windows.Forms.Panel();
            this._lblTitle = new System.Windows.Forms.Label();
            this._logoBox = new System.Windows.Forms.PictureBox();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabCleaner = new System.Windows.Forms.TabPage();
            this._tabDiskHealth = new System.Windows.Forms.TabPage();
            this._pnlDiskControls = new System.Windows.Forms.Panel();
            this._btnScanDisk = new System.Windows.Forms.Button();
            this._diskProgressBar = new System.Windows.Forms.ProgressBar();
            this._lblDiskStatus = new System.Windows.Forms.Label();
            this._txtDiskReport = new System.Windows.Forms.RichTextBox();
            this._pnlControls = new System.Windows.Forms.Panel();
            this._lblFooter = new System.Windows.Forms.Label();
            this._logoFooter = new System.Windows.Forms.PictureBox();
            this._grpOptions = new System.Windows.Forms.GroupBox();
            this._btnSelectNone = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._chkClipboard = new System.Windows.Forms.CheckBox();
            this._chkRegistry = new System.Windows.Forms.CheckBox();
            this._chkQuickAccess = new System.Windows.Forms.CheckBox();
            this._chkDiskCleanup = new System.Windows.Forms.CheckBox();
            this._chkDISM = new System.Windows.Forms.CheckBox();
            this._chkApps = new System.Windows.Forms.CheckBox();
            this._chkBrowsers = new System.Windows.Forms.CheckBox();
            this._chkDNS = new System.Windows.Forms.CheckBox();
            this._chkCrashDumps = new System.Windows.Forms.CheckBox();
            this._chkRecycleBin = new System.Windows.Forms.CheckBox();
            this._chkLogs = new System.Windows.Forms.CheckBox();
            this._chkWinUpdate = new System.Windows.Forms.CheckBox();
            this._chkPrefetch = new System.Windows.Forms.CheckBox();
            this._chkTemp = new System.Windows.Forms.CheckBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoBox)).BeginInit();
            this._tabControl.SuspendLayout();
            this._tabCleaner.SuspendLayout();
            this._tabDiskHealth.SuspendLayout();
            this._pnlDiskControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this._pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoFooter)).BeginInit();
            this._grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlHeader
            // 
            this._pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this._pnlHeader.Controls.Add(this._lblTitle);
            this._pnlHeader.Controls.Add(this._logoBox);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.Location = new System.Drawing.Point(0, 0);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(984, 80);
            this._pnlHeader.TabIndex = 4;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._lblTitle.ForeColor = System.Drawing.Color.Lime;
            this._lblTitle.Location = new System.Drawing.Point(90, 18);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(268, 45);
            this._lblTitle.TabIndex = 1;
            this._lblTitle.Text = "DEEP CLEAN PRO";
            // 
            // _logoBox
            // 
            this._logoBox.Location = new System.Drawing.Point(12, 8);
            this._logoBox.Name = "_logoBox";
            this._logoBox.Size = new System.Drawing.Size(64, 64);
            this._logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logoBox.TabIndex = 0;
            this._logoBox.TabStop = false;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabCleaner);
            this._tabControl.Controls.Add(this._tabDiskHealth);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 80);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(984, 720);
            this._tabControl.TabIndex = 5;
            // 
            // _tabCleaner
            // 
            this._tabCleaner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._tabCleaner.Controls.Add(this._splitContainer);
            this._tabCleaner.Location = new System.Drawing.Point(4, 24);
            this._tabCleaner.Name = "_tabCleaner";
            this._tabCleaner.Padding = new System.Windows.Forms.Padding(3);
            this._tabCleaner.Size = new System.Drawing.Size(976, 692);
            this._tabCleaner.TabIndex = 0;
            this._tabCleaner.Text = "System Cleaner";
            // 
            // _tabDiskHealth
            // 
            this._tabDiskHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this._tabDiskHealth.Controls.Add(this._txtDiskReport);
            this._tabDiskHealth.Controls.Add(this._pnlDiskControls);
            this._tabDiskHealth.Location = new System.Drawing.Point(4, 24);
            this._tabDiskHealth.Name = "_tabDiskHealth";
            this._tabDiskHealth.Padding = new System.Windows.Forms.Padding(3);
            this._tabDiskHealth.Size = new System.Drawing.Size(976, 692);
            this._tabDiskHealth.TabIndex = 1;
            this._tabDiskHealth.Text = "Hard Disk Health";
            // 
            // _pnlDiskControls
            // 
            this._pnlDiskControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this._pnlDiskControls.Controls.Add(this._lblDiskStatus);
            this._pnlDiskControls.Controls.Add(this._diskProgressBar);
            this._pnlDiskControls.Controls.Add(this._btnScanDisk);
            this._pnlDiskControls.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlDiskControls.Location = new System.Drawing.Point(3, 3);
            this._pnlDiskControls.Name = "_pnlDiskControls";
            this._pnlDiskControls.Size = new System.Drawing.Size(970, 100);
            this._pnlDiskControls.TabIndex = 0;
            // 
            // _btnScanDisk
            // 
            this._btnScanDisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._btnScanDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnScanDisk.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnScanDisk.ForeColor = System.Drawing.Color.Lime;
            this._btnScanDisk.Location = new System.Drawing.Point(348, 15);
            this._btnScanDisk.Name = "_btnScanDisk";
            this._btnScanDisk.Size = new System.Drawing.Size(280, 50);
            this._btnScanDisk.TabIndex = 0;
            this._btnScanDisk.Text = "Start Comprehensive Scan";
            this._btnScanDisk.UseVisualStyleBackColor = false;
            this._btnScanDisk.Click += new System.EventHandler(this.BtnScanDisk_Click);
            // 
            // _diskProgressBar
            // 
            this._diskProgressBar.Location = new System.Drawing.Point(50, 75);
            this._diskProgressBar.Name = "_diskProgressBar";
            this._diskProgressBar.Size = new System.Drawing.Size(870, 10);
            this._diskProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._diskProgressBar.TabIndex = 1;
            // 
            // _lblDiskStatus
            // 
            this._lblDiskStatus.AutoSize = true;
            this._lblDiskStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblDiskStatus.ForeColor = System.Drawing.Color.Lime;
            this._lblDiskStatus.Location = new System.Drawing.Point(50, 57);
            this._lblDiskStatus.Name = "_lblDiskStatus";
            this._lblDiskStatus.Size = new System.Drawing.Size(0, 15);
            this._lblDiskStatus.TabIndex = 2;
            // 
            // _txtDiskReport
            // 
            this._txtDiskReport.BackColor = System.Drawing.Color.Black;
            this._txtDiskReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtDiskReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtDiskReport.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._txtDiskReport.ForeColor = System.Drawing.Color.Lime;
            this._txtDiskReport.Location = new System.Drawing.Point(3, 103);
            this._txtDiskReport.Name = "_txtDiskReport";
            this._txtDiskReport.ReadOnly = true;
            this._txtDiskReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtDiskReport.Size = new System.Drawing.Size(970, 586);
            this._txtDiskReport.TabIndex = 1;
            this._txtDiskReport.Text = "";
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(3, 3);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._pnlControls);
            this._splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._txtLogs);
            this._splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this._splitContainer.Size = new System.Drawing.Size(976, 686);
            this._splitContainer.SplitterDistance = 300;
            this._splitContainer.TabIndex = 0;
            // 
            // _pnlControls
            // 
            this._pnlControls.Controls.Add(this._lblFooter);
            this._pnlControls.Controls.Add(this._logoFooter);
            this._pnlControls.Controls.Add(this._grpOptions);
            this._pnlControls.Controls.Add(this._chkSim);
            this._pnlControls.Controls.Add(this._btnStart);
            this._pnlControls.Controls.Add(this._progressBar);
            this._pnlControls.Controls.Add(this._lblStatus);
            this._pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlControls.Location = new System.Drawing.Point(10, 10);
            this._pnlControls.Name = "_pnlControls";
            this._pnlControls.Size = new System.Drawing.Size(280, 511);
            this._pnlControls.TabIndex = 0;
            // 
            // _lblFooter
            // 
            this._lblFooter.AutoSize = true;
            this._lblFooter.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblFooter.ForeColor = System.Drawing.Color.DarkGray;
            this._lblFooter.Location = new System.Drawing.Point(5, 495); // Just below progress bar
            this._lblFooter.Name = "_lblFooter";
            this._lblFooter.Size = new System.Drawing.Size(240, 12);
            this._lblFooter.TabIndex = 6;
            this._lblFooter.Text = "Designed & Developed by EagleShadow - Hamza Saadi (c) 2026";
            this._lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _logoFooter
            // 
            this._logoFooter.Location = new System.Drawing.Point(75, 512); // Re-centered (approx) and enlarged
            this._logoFooter.Name = "_logoFooter";
            this._logoFooter.Size = new System.Drawing.Size(150, 150); // Increased size
            this._logoFooter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logoFooter.TabIndex = 7;
            this._logoFooter.TabStop = false;
            // 
            // _grpOptions
            // 
            this._grpOptions.Controls.Add(this._btnSelectNone);
            this._grpOptions.Controls.Add(this._btnSelectAll);
            this._grpOptions.Controls.Add(this._chkClipboard);
            this._grpOptions.Controls.Add(this._chkRegistry);
            this._grpOptions.Controls.Add(this._chkQuickAccess);
            this._grpOptions.Controls.Add(this._chkDiskCleanup);
            this._grpOptions.Controls.Add(this._chkDISM);
            this._grpOptions.Controls.Add(this._chkApps);
            this._grpOptions.Controls.Add(this._chkBrowsers);
            this._grpOptions.Controls.Add(this._chkDNS);
            this._grpOptions.Controls.Add(this._chkCrashDumps);
            this._grpOptions.Controls.Add(this._chkRecycleBin);
            this._grpOptions.Controls.Add(this._chkLogs);
            this._grpOptions.Controls.Add(this._chkWinUpdate);
            this._grpOptions.Controls.Add(this._chkPrefetch);
            this._grpOptions.Controls.Add(this._chkTemp);
            this._grpOptions.ForeColor = System.Drawing.Color.Lime;
            this._grpOptions.Location = new System.Drawing.Point(3, 40);
            this._grpOptions.Name = "_grpOptions";
            this._grpOptions.Size = new System.Drawing.Size(274, 380);
            this._grpOptions.TabIndex = 5;
            this._grpOptions.TabStop = false;
            this._grpOptions.Text = "Cleanup Options";
            // 
            // _btnSelectNone
            // 
            this._btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSelectNone.Font = new System.Drawing.Font("Segoe UI", 7F);
            this._btnSelectNone.Location = new System.Drawing.Point(201, 0);
            this._btnSelectNone.Name = "_btnSelectNone";
            this._btnSelectNone.Size = new System.Drawing.Size(60, 20);
            this._btnSelectNone.TabIndex = 15;
            this._btnSelectNone.Text = "None";
            this._btnSelectNone.UseVisualStyleBackColor = true;
            this._btnSelectNone.Click += new System.EventHandler(this.BtnSelectNone_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 7F);
            this._btnSelectAll.Location = new System.Drawing.Point(135, 0);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(60, 20);
            this._btnSelectAll.TabIndex = 14;
            this._btnSelectAll.Text = "All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // _chkClipboard
            // 
            this._chkClipboard.AutoSize = true;
            this._chkClipboard.Checked = true;
            this._chkClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkClipboard.Location = new System.Drawing.Point(15, 300);
            this._chkClipboard.Name = "_chkClipboard";
            this._chkClipboard.Size = new System.Drawing.Size(150, 19);
            this._chkClipboard.TabIndex = 11;
            this._chkClipboard.Text = "Clipboard";
            this._chkClipboard.UseVisualStyleBackColor = true;
            // 
            // _chkRegistry
            // 
            this._chkRegistry.AutoSize = true;
            this._chkRegistry.Checked = true;
            this._chkRegistry.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkRegistry.Location = new System.Drawing.Point(15, 275);
            this._chkRegistry.Name = "_chkRegistry";
            this._chkRegistry.Size = new System.Drawing.Size(150, 19);
            this._chkRegistry.TabIndex = 10;
            this._chkRegistry.Text = "Registry History (MRU)";
            this._chkRegistry.UseVisualStyleBackColor = true;
            // 
            // _chkQuickAccess
            // 
            this._chkQuickAccess.AutoSize = true;
            this._chkQuickAccess.Checked = true;
            this._chkQuickAccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkQuickAccess.Location = new System.Drawing.Point(15, 250);
            this._chkQuickAccess.Name = "_chkQuickAccess";
            this._chkQuickAccess.Size = new System.Drawing.Size(150, 19);
            this._chkQuickAccess.TabIndex = 9;
            this._chkQuickAccess.Text = "Quick Access / Recent";
            this._chkQuickAccess.UseVisualStyleBackColor = true;
            // 
            // _chkDiskCleanup
            // 
            this._chkDiskCleanup.AutoSize = true;
            this._chkDiskCleanup.Checked = true;
            this._chkDiskCleanup.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkDiskCleanup.Location = new System.Drawing.Point(15, 350);
            this._chkDiskCleanup.Name = "_chkDiskCleanup";
            this._chkDiskCleanup.Size = new System.Drawing.Size(150, 19);
            this._chkDiskCleanup.TabIndex = 13;
            this._chkDiskCleanup.Text = "Windows Disk Cleanup";
            this._chkDiskCleanup.UseVisualStyleBackColor = true;
            // 
            // _chkDISM
            // 
            this._chkDISM.AutoSize = true;
            this._chkDISM.Checked = false;
            this._chkDISM.Location = new System.Drawing.Point(15, 325);
            this._chkDISM.Name = "_chkDISM";
            this._chkDISM.Size = new System.Drawing.Size(150, 19);
            this._chkDISM.TabIndex = 12;
            this._chkDISM.Text = "System Image (DISM) [Slow]";
            this._chkDISM.UseVisualStyleBackColor = true;
            // 
            // _chkApps
            // 
            this._chkApps.AutoSize = true;
            this._chkApps.Checked = true;
            this._chkApps.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkApps.Location = new System.Drawing.Point(15, 225);
            this._chkApps.Name = "_chkApps";
            this._chkApps.Size = new System.Drawing.Size(150, 19);
            this._chkApps.TabIndex = 8;
            this._chkApps.Text = "App Caches (Discord/etc)";
            this._chkApps.UseVisualStyleBackColor = true;
            // 
            // _chkBrowsers
            // 
            this._chkBrowsers.AutoSize = true;
            this._chkBrowsers.Checked = true;
            this._chkBrowsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkBrowsers.Location = new System.Drawing.Point(15, 200);
            this._chkBrowsers.Name = "_chkBrowsers";
            this._chkBrowsers.Size = new System.Drawing.Size(150, 19);
            this._chkBrowsers.TabIndex = 7;
            this._chkBrowsers.Text = "Browser Caches";
            this._chkBrowsers.UseVisualStyleBackColor = true;
            // 
            // _chkDNS
            // 
            this._chkDNS.AutoSize = true;
            this._chkDNS.Checked = true;
            this._chkDNS.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkDNS.Location = new System.Drawing.Point(15, 175);
            this._chkDNS.Name = "_chkDNS";
            this._chkDNS.Size = new System.Drawing.Size(150, 19);
            this._chkDNS.TabIndex = 6;
            this._chkDNS.Text = "DNS Cache";
            this._chkDNS.UseVisualStyleBackColor = true;
            // 
            // _chkCrashDumps
            // 
            this._chkCrashDumps.AutoSize = true;
            this._chkCrashDumps.Checked = true;
            this._chkCrashDumps.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkCrashDumps.Location = new System.Drawing.Point(15, 150);
            this._chkCrashDumps.Name = "_chkCrashDumps";
            this._chkCrashDumps.Size = new System.Drawing.Size(150, 19);
            this._chkCrashDumps.TabIndex = 5;
            this._chkCrashDumps.Text = "Crash Dumps";
            this._chkCrashDumps.UseVisualStyleBackColor = true;
            // 
            // _chkRecycleBin
            // 
            this._chkRecycleBin.AutoSize = true;
            this._chkRecycleBin.Checked = true;
            this._chkRecycleBin.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkRecycleBin.Location = new System.Drawing.Point(15, 125);
            this._chkRecycleBin.Name = "_chkRecycleBin";
            this._chkRecycleBin.Size = new System.Drawing.Size(150, 19);
            this._chkRecycleBin.TabIndex = 4;
            this._chkRecycleBin.Text = "Recycle Bin";
            this._chkRecycleBin.UseVisualStyleBackColor = true;
            // 
            // _chkLogs
            // 
            this._chkLogs.AutoSize = true;
            this._chkLogs.Checked = true;
            this._chkLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkLogs.Location = new System.Drawing.Point(15, 100);
            this._chkLogs.Name = "_chkLogs";
            this._chkLogs.Size = new System.Drawing.Size(150, 19);
            this._chkLogs.TabIndex = 3;
            this._chkLogs.Text = "System Logs (Event/File)";
            this._chkLogs.UseVisualStyleBackColor = true;
            // 
            // _chkWinUpdate
            // 
            this._chkWinUpdate.AutoSize = true;
            this._chkWinUpdate.Checked = true;
            this._chkWinUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkWinUpdate.Location = new System.Drawing.Point(15, 75);
            this._chkWinUpdate.Name = "_chkWinUpdate";
            this._chkWinUpdate.Size = new System.Drawing.Size(150, 19);
            this._chkWinUpdate.TabIndex = 2;
            this._chkWinUpdate.Text = "Windows Update Cache";
            this._chkWinUpdate.UseVisualStyleBackColor = true;
            // 
            // _chkPrefetch
            // 
            this._chkPrefetch.AutoSize = true;
            this._chkPrefetch.Checked = true;
            this._chkPrefetch.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkPrefetch.Location = new System.Drawing.Point(15, 50);
            this._chkPrefetch.Name = "_chkPrefetch";
            this._chkPrefetch.Size = new System.Drawing.Size(115, 19);
            this._chkPrefetch.TabIndex = 1;
            this._chkPrefetch.Text = "Prefetch";
            this._chkPrefetch.UseVisualStyleBackColor = true;
            // 
            // _chkTemp
            // 
            this._chkTemp.AutoSize = true;
            this._chkTemp.Checked = true;
            this._chkTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkTemp.Location = new System.Drawing.Point(15, 25);
            this._chkTemp.Name = "_chkTemp";
            this._chkTemp.Size = new System.Drawing.Size(115, 19);
            this._chkTemp.TabIndex = 0;
            this._chkTemp.Text = "System Temp";
            this._chkTemp.UseVisualStyleBackColor = true;
            // 
            // _chkSim
            // 
            this._chkSim.AutoSize = true;
            this._chkSim.Checked = true;
            this._chkSim.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkSim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._chkSim.ForeColor = System.Drawing.Color.Yellow;
            this._chkSim.Location = new System.Drawing.Point(10, 5);
            this._chkSim.Name = "_chkSim";
            this._chkSim.Size = new System.Drawing.Size(236, 23);
            this._chkSim.TabIndex = 2;
            this._chkSim.Text = "SIMULATION MODE (Dry Run)";
            this._chkSim.UseVisualStyleBackColor = true;
            // 
            // _btnStart
            // 
            this._btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnStart.ForeColor = System.Drawing.Color.Lime;
            this._btnStart.Location = new System.Drawing.Point(3, 425);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(274, 40);
            this._btnStart.TabIndex = 1;
            this._btnStart.Text = "INITIATE CLEANUP";
            this._btnStart.UseVisualStyleBackColor = false;
            this._btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(3, 470);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(274, 20);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progressBar.TabIndex = 4;
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Consolas", 8F);
            this._lblStatus.ForeColor = System.Drawing.Color.DarkGray;
            this._lblStatus.Location = new System.Drawing.Point(5, 510);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(43, 13);
            this._lblStatus.TabIndex = 3;
            this._lblStatus.Text = "Ready.";
            this._lblStatus.Visible = false; // Hiding to make space for footer
            // 
            // _txtLogs
            // 
            this._txtLogs.BackColor = System.Drawing.Color.Black;
            this._txtLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtLogs.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._txtLogs.ForeColor = System.Drawing.Color.Lime;
            this._txtLogs.Location = new System.Drawing.Point(10, 10);
            this._txtLogs.Name = "_txtLogs";
            this._txtLogs.ReadOnly = true;
            this._txtLogs.Size = new System.Drawing.Size(664, 511);
            this._txtLogs.TabIndex = 0;
            this._txtLogs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(984, 800); // Ensure form is tall enough
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._pnlHeader);
            this.Name = "Form1";
            this.Text = "DeepClean Pro - System Maintenance Utility";
            this._pnlHeader.ResumeLayout(false);
            this._pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoBox)).EndInit();
            this._tabControl.ResumeLayout(false);
            this._tabCleaner.ResumeLayout(false);
            this._tabDiskHealth.ResumeLayout(false);
            this._pnlDiskControls.ResumeLayout(false);
            this._pnlDiskControls.PerformLayout();
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this._pnlControls.ResumeLayout(false);
            this._pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoFooter)).EndInit();
            this._grpOptions.ResumeLayout(false);
            this._grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _txtLogs;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.CheckBox _chkSim;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Panel _pnlHeader;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.PictureBox _logoBox;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Panel _pnlControls;
        private System.Windows.Forms.GroupBox _grpOptions;
        
        // Granular Control Checkboxes
        public System.Windows.Forms.CheckBox _chkTemp;
        public System.Windows.Forms.CheckBox _chkPrefetch;
        public System.Windows.Forms.CheckBox _chkWinUpdate;
        public System.Windows.Forms.CheckBox _chkLogs;
        public System.Windows.Forms.CheckBox _chkRecycleBin;
        public System.Windows.Forms.CheckBox _chkCrashDumps;
        public System.Windows.Forms.CheckBox _chkDNS;
        public System.Windows.Forms.CheckBox _chkBrowsers;
        public System.Windows.Forms.CheckBox _chkApps;
        public System.Windows.Forms.CheckBox _chkQuickAccess;
        public System.Windows.Forms.CheckBox _chkRegistry;
        public System.Windows.Forms.CheckBox _chkClipboard;
        public System.Windows.Forms.CheckBox _chkDISM;
        public System.Windows.Forms.CheckBox _chkDiskCleanup;
        
        private System.Windows.Forms.Button _btnSelectAll;
        private System.Windows.Forms.Button _btnSelectNone;
        private System.Windows.Forms.Label _lblFooter; // New Footer Label
        private System.Windows.Forms.PictureBox _logoFooter; // New Footer Logo

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabCleaner;
        private System.Windows.Forms.TabPage _tabDiskHealth;
        
        private System.Windows.Forms.Panel _pnlDiskControls;
        private System.Windows.Forms.Button _btnScanDisk;
        private System.Windows.Forms.ProgressBar _diskProgressBar;
        private System.Windows.Forms.Label _lblDiskStatus;
        private System.Windows.Forms.RichTextBox _txtDiskReport;
    }
}
