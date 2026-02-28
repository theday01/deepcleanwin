using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DeepCleanPro
{
    // Simple configuration object to pass to Cleaner
    public class CleanupConfig
    {
        public bool SimulationMode { get; set; }
        public bool SystemTemp { get; set; }
        public bool Prefetch { get; set; }
        public bool WindowsUpdate { get; set; }
        public bool Logs { get; set; }
        public bool RecycleBin { get; set; }
        public bool CrashDumps { get; set; }
        public bool DNS { get; set; }
        public bool Browsers { get; set; }
        public bool Apps { get; set; }
        public bool QuickAccess { get; set; }
        public bool Registry { get; set; }
        public bool Clipboard { get; set; }
        public bool DISM { get; set; }
        public bool DiskCleanup { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = SystemIcons.Shield; // Fallback icon
            LoadLogo();
            
            Cleaner.OnLog += LogToUi;
            
            // Wire up clipboard action
            Cleaner.ClearClipboardAction = () => {
                if (this.InvokeRequired) this.Invoke(new Action(() => Clipboard.Clear()));
                else Clipboard.Clear();
                LogToUi("System Clipboard Emptied.", LogLevel.SUCCESS);
            };

            LogToUi("DeepClean Pro Initialized", LogLevel.INFO);
            LogToUi("Developed by EagleShadow - HAMZASAADI 2026", LogLevel.INFO);
            LogToUi("WAITING FOR COMMAND ...", LogLevel.INFO);
        }

        private void LoadLogo()
        {
            try
            {
                // Look for logo.png in the same directory
                string logoPath = Path.Combine(Application.StartupPath, "logo.png");
                if (File.Exists(logoPath))
                {
                    Image img = Image.FromFile(logoPath);
                    _logoBox.Image = img;
                    _logoFooter.Image = img; // Set same image for footer
                }
                else
                {
                    // Draw a simple fallback logo
                    Bitmap bmp = new Bitmap(64, 64);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.FillEllipse(Brushes.Lime, 2, 2, 60, 60);
                        g.DrawString("DCP", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 8, 20);
                    }
                    _logoBox.Image = bmp;
                    _logoFooter.Image = bmp;
                }
            }
            catch { }
        }

        private void LogToUi(string message, LogLevel level)
        {
            if (_txtLogs.InvokeRequired)
            {
                _txtLogs.Invoke(new Action(() => LogToUi(message, level)));
                return;
            }

            Color color = Color.Lime; // Default
            switch (level)
            {
                case LogLevel.INFO: color = Color.Cyan; break;
                case LogLevel.SUCCESS: color = Color.Lime; break;
                case LogLevel.WARNING: color = Color.Yellow; break;
                case LogLevel.ERROR: color = Color.Red; break;
                case LogLevel.DEBUG: color = Color.Gray; break;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            _txtLogs.SelectionStart = _txtLogs.TextLength;
            _txtLogs.SelectionLength = 0;

            _txtLogs.SelectionColor = Color.White;
            _txtLogs.AppendText($"[{timestamp}] ");

            _txtLogs.SelectionColor = color;
            _txtLogs.AppendText($"[{level}] {message}{Environment.NewLine}");
            
            _txtLogs.ScrollToCaret();

            // Update status label
            if (message.Length > 40) _lblStatus.Text = message.Substring(0, 37) + "...";
            else _lblStatus.Text = message;
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            var config = new CleanupConfig
            {
                SimulationMode = _chkSim.Checked,
                SystemTemp = _chkTemp.Checked,
                Prefetch = _chkPrefetch.Checked,
                WindowsUpdate = _chkWinUpdate.Checked,
                Logs = _chkLogs.Checked,
                RecycleBin = _chkRecycleBin.Checked,
                CrashDumps = _chkCrashDumps.Checked,
                DNS = _chkDNS.Checked,
                Browsers = _chkBrowsers.Checked,
                Apps = _chkApps.Checked,
                QuickAccess = _chkQuickAccess.Checked,
                Registry = _chkRegistry.Checked,
                Clipboard = _chkClipboard.Checked,
                DISM = _chkDISM.Checked,
                DiskCleanup = _chkDiskCleanup.Checked
            };

            ToggleControls(false);
            
            if (config.SimulationMode)
                 LogToUi("Starting Simulation Mode. No files will be modified.", LogLevel.WARNING);
            else
                 LogToUi("Starting Live Mode. FILES WILL BE PERMANENTLY DELETED.", LogLevel.WARNING);

            _progressBar.Style = ProgressBarStyle.Marquee;
            
            await Cleaner.RunCleanup(config);

            _progressBar.Style = ProgressBarStyle.Continuous;
            _progressBar.Value = 100;
            ToggleControls(true);
            
            _lblStatus.Text = "Cleanup Complete.";
            MessageBox.Show("System Cleanup Completed Successfully!", "DeepClean Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToggleControls(bool enabled)
        {
            _btnStart.Enabled = enabled;
            _chkSim.Enabled = enabled;
            _grpOptions.Enabled = enabled;
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
             SetCheckboxes(true);
        }

        private void BtnSelectNone_Click(object sender, EventArgs e)
        {
             SetCheckboxes(false);
        }

        private void SetCheckboxes(bool state)
        {
            foreach (Control c in _grpOptions.Controls)
            {
                if (c is CheckBox cb && cb != _chkDISM) // Don't auto-select DISM as it is slow
                {
                    cb.Checked = state;
                }
            }
        }

        private async void BtnScanDisk_Click(object sender, EventArgs e)
        {
            _btnScanDisk.Enabled = false;
            _diskProgressBar.Style = ProgressBarStyle.Marquee;
            _txtDiskReport.Clear();
            _lblDiskStatus.Text = "Starting Comprehensive System Scan...";
            
            DiskHealthChecker checker = new DiskHealthChecker();
            
            checker.OnLog += (msg) => {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        _lblDiskStatus.Text = msg;
                        _txtDiskReport.AppendText($"[*] {msg}{Environment.NewLine}");
                        _txtDiskReport.ScrollToCaret();
                    }));
                }
                else
                {
                    _lblDiskStatus.Text = msg;
                    _txtDiskReport.AppendText($"[*] {msg}{Environment.NewLine}");
                    _txtDiskReport.ScrollToCaret();
                }
            };

            try
            {
                // Add a small delay to show the "Starting" state
                await Task.Delay(500);
                string report = await checker.RunHealthCheck();
                _txtDiskReport.Text = report; 
            }
            catch (Exception ex)
            {
                _txtDiskReport.AppendText($"{Environment.NewLine}[ERROR] {ex.Message}");
            }
            finally
            {
                _btnScanDisk.Enabled = true;
                _diskProgressBar.Style = ProgressBarStyle.Continuous;
                _diskProgressBar.Value = 100;
                _lblDiskStatus.Text = "Scan Complete.";
            }
        }
    }
}
