using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Win32;

namespace DeepCleanPro
{
    public enum LogLevel
    {
        INFO,
        SUCCESS,
        WARNING,
        ERROR,
        DEBUG
    }

    public class Cleaner
    {
        // Event to update UI
        public static event Action<string, LogLevel>? OnLog;

        // Clipboard clearing delegate
        public static Action? ClearClipboardAction;

        private static void Log(string message, LogLevel level)
        {
            OnLog?.Invoke(message, level);
        }

        // Updated signature to accept CleanupConfig
        public static async Task RunCleanup(CleanupConfig config)
        {
            bool simulationMode = config.SimulationMode;
            
            Log("========================================================", LogLevel.INFO);
            Log($"STARTING DEEP CLEANUP (SIMULATION: {simulationMode})", LogLevel.INFO);
            Log("========================================================", LogLevel.INFO);
            Log($"TARGET SYSTEM DRIVE: {Path.GetPathRoot(Environment.SystemDirectory)}", LogLevel.INFO);
            Log("========================================================", LogLevel.INFO);

            await Task.Run(() =>
            {
                try
                {
                    CreateRestorePoint(simulationMode);
                    
                    if (config.SystemTemp) CleanSystemTemp(simulationMode);
                    if (config.Prefetch) CleanPrefetch(simulationMode);
                    if (config.WindowsUpdate) CleanWindowsUpdate(simulationMode);
                    if (config.Logs) CleanLogs(simulationMode);
                    if (config.RecycleBin) CleanRecycleBin(simulationMode);
                    if (config.CrashDumps) CleanCrashDumps(simulationMode);
                    if (config.DNS) CleanDNS(simulationMode);
                    if (config.QuickAccess) CleanQuickAccess(simulationMode);
                    if (config.Browsers) CleanBrowsers(simulationMode);
                    if (config.Apps) CleanApplications(simulationMode);
                    if (config.Registry) CleanRegistryHistory(simulationMode);
                    if (config.Clipboard) CleanClipboard(simulationMode);
                    if (config.DISM) CleanSystemImage(simulationMode);
                    if (config.DiskCleanup) CleanDiskCleanup(simulationMode);
                    
                    // Always clean delivery optimization if update is cleaned, or make it separate? 
                    // Let's assume it's part of Update or Disk Cleanup generally, but here it's separate.
                    // For now, let's tie it to Windows Update for simplicity or add a hidden option.
                    // Or just run it if Windows Update is checked.
                    if (config.WindowsUpdate) CleanDeliveryOptimization(simulationMode);
                }
                catch (Exception ex)
                {
                    Log($"CRITICAL ERROR DURING CLEANUP: {ex.Message}", LogLevel.ERROR);
                }
            });

            Log("========================================================", LogLevel.SUCCESS);
            Log("DEEP CLEANUP COMPLETE", LogLevel.SUCCESS);
            Log("========================================================", LogLevel.SUCCESS);
        }

        private static void RemoveFileSafe(string path, bool recurse, string description, bool simulationMode)
        {
            if (simulationMode)
            {
                Log($"SIMULATION: Would delete {path} ({description})", LogLevel.INFO);
                return;
            }

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Log($"Deleted file: {description} ({path})", LogLevel.SUCCESS);
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path, recurse);
                    Log($"Deleted directory: {description} ({path})", LogLevel.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to delete {description} ({path}). Error: {ex.Message}", LogLevel.ERROR);
            }
        }

        private static void CleanDirectoryContents(string path, string description, bool simulationMode, bool recursive = true)
        {
            if (!Directory.Exists(path)) return;

            try
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    RemoveFileSafe(file, false, description, simulationMode);
                }

                if (recursive)
                {
                    var dirs = Directory.GetDirectories(path);
                    foreach (var dir in dirs)
                    {
                        RemoveFileSafe(dir, true, description, simulationMode);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error accessing directory {path}: {ex.Message}", LogLevel.WARNING);
            }
        }

        private static void RunProcess(string fileName, string arguments, string description, bool simulationMode, bool waitForExit = true)
        {
            if (simulationMode)
            {
                Log($"SIMULATION: Would run {fileName} {arguments} ({description})", LogLevel.INFO);
                return;
            }

            try
            {
                Log($"Running: {description}...", LogLevel.INFO);
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process proc = new Process { StartInfo = psi })
                {
                    if (waitForExit)
                    {
                        proc.OutputDataReceived += (sender, e) => {
                            if (!string.IsNullOrWhiteSpace(e.Data)) Log($"{description} (OUT): {e.Data}", LogLevel.DEBUG);
                        };
                        proc.ErrorDataReceived += (sender, e) => {
                            if (!string.IsNullOrWhiteSpace(e.Data)) Log($"{description} (ERR): {e.Data}", LogLevel.WARNING);
                        };

                        proc.Start();
                        proc.BeginOutputReadLine();
                        proc.BeginErrorReadLine();
                        proc.WaitForExit();
                        
                        Log($"{description} completed.", LogLevel.SUCCESS);
                    }
                    else
                    {
                        proc.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to run {description}. Error: {ex.Message}", LogLevel.ERROR);
            }
        }

        private static void CreateRestorePoint(bool simulationMode)
        {
            Log("Initiating System Restore Point Creation...", LogLevel.INFO);
            if (simulationMode)
            {
                Log("SIMULATION: Would create Restore Point 'DeepCleanPro Auto-Backup'", LogLevel.INFO);
                return;
            }

            // Using PowerShell to create restore point as it's reliable
            RunProcess("powershell.exe", "-Command \"Checkpoint-Computer -Description 'DeepCleanPro Auto-Backup' -RestorePointType 'MODIFY_SETTINGS' -ErrorAction Stop\"", "Create System Restore Point", simulationMode);
        }

        private static void CleanSystemTemp(bool simulationMode)
        {
            Log("Cleaning Temporary Files...", LogLevel.INFO);
            string userTemp = Path.GetTempPath();
            CleanDirectoryContents(userTemp, "User Temp File", simulationMode);

            string winTemp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp");
            CleanDirectoryContents(winTemp, "Windows Temp File", simulationMode);
        }

        private static void CleanPrefetch(bool simulationMode)
        {
            Log("Cleaning Prefetch Cache...", LogLevel.INFO);
            string prefetch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");
            CleanDirectoryContents(prefetch, "Prefetch File", simulationMode);
        }

        private static void CleanWindowsUpdate(bool simulationMode)
        {
            Log("Cleaning Windows Update Cache...", LogLevel.INFO);
            
            // Stop services (mock implementation via net stop for simplicity and robust execution via CLI)
            if (!simulationMode)
            {
                RunProcess("net", "stop wuauserv", "Stop Windows Update Service", simulationMode);
                RunProcess("net", "stop bits", "Stop BITS Service", simulationMode);
            }

            string updateCache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution", "Download");
            CleanDirectoryContents(updateCache, "Windows Update Cache", simulationMode);

            if (!simulationMode)
            {
                RunProcess("net", "start wuauserv", "Start Windows Update Service", simulationMode);
                RunProcess("net", "start bits", "Start BITS Service", simulationMode);
            }
        }

        private static void CleanLogs(bool simulationMode)
        {
            Log("Cleaning System Logs...", LogLevel.INFO);
            
            if (simulationMode)
            {
                Log("SIMULATION: Would clear all Event Logs", LogLevel.INFO);
            }
            else
            {
                try
                {
                    Log("Scanning for Event Logs...", LogLevel.INFO);
                    EventLogSession session = new EventLogSession();
                    var logs = session.GetLogNames();
                    int successCount = 0;
                    int failCount = 0;

                    foreach (string logName in logs)
                    {
                        try
                        {
                            session.ClearLog(logName);
                            successCount++;
                            // Log every 10 logs to show progress without spamming
                            if (successCount % 10 == 0) 
                                Log($"Cleared {successCount} logs so far...", LogLevel.DEBUG);
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                    Log($"Event Log Cleanup: {successCount} cleared, {failCount} skipped/locked.", LogLevel.SUCCESS);
                }
                catch (Exception ex)
                {
                    Log($"Failed to enumerate/clear event logs: {ex.Message}", LogLevel.ERROR);
                }
            }

            // Generic Log Files
            string[] logPaths = {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Logs"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp")
            };

            foreach (var path in logPaths)
            {
                if (Directory.Exists(path))
                {
                    // Naive recursive search for .log files
                     try
                     {
                         var logFiles = Directory.GetFiles(path, "*.log", SearchOption.AllDirectories);
                         foreach (var file in logFiles) RemoveFileSafe(file, false, "System Log File", simulationMode);
                     }
                     catch {}
                }
            }
        }

        private static void CleanRecycleBin(bool simulationMode)
        {
            Log("Emptying Recycle Bin (System Drive Only)...", LogLevel.INFO);
            // Use PowerShell to clear recycle bin
            // Restrict to System Drive to avoid clearing USBs/External Drives accidentally
            RunProcess("powershell.exe", "-Command \"Clear-RecycleBin -DriveLetter $env:SystemDrive[0] -Force -ErrorAction SilentlyContinue\"", "Empty System Recycle Bin", simulationMode);
        }

        private static void CleanCrashDumps(bool simulationMode)
        {
            Log("Cleaning Crash Dumps...", LogLevel.INFO);
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            string[] dumpPaths = {
                Path.Combine(localAppData, "CrashDumps"),
                Path.Combine(programData, "Microsoft", "Windows", "WER", "ReportArchive"),
                Path.Combine(programData, "Microsoft", "Windows", "WER", "ReportQueue"),
                Path.Combine(localAppData, "Microsoft", "Windows", "WER", "ReportArchive"),
                Path.Combine(localAppData, "Microsoft", "Windows", "WER", "ReportQueue")
            };

            foreach (var path in dumpPaths) CleanDirectoryContents(path, "Crash Dump", simulationMode);
        }

        private static void CleanDNS(bool simulationMode)
        {
            Log("Flushing DNS Cache...", LogLevel.INFO);
            RunProcess("ipconfig", "/flushdns", "Flush DNS", simulationMode);
        }

        private static void CleanDeliveryOptimization(bool simulationMode)
        {
            Log("Cleaning Delivery Optimization Files...", LogLevel.INFO);
            string doPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution", "DeliveryOptimization");
            CleanDirectoryContents(doPath, "Delivery Optimization File", simulationMode);
        }

        private static void CleanQuickAccess(bool simulationMode)
        {
            Log("Cleaning Quick Access & Recent Files...", LogLevel.INFO);
            
            try
            {
                string recentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                
                // Clean standard Recent items
                CleanDirectoryContents(recentPath, "Recent Item", simulationMode, recursive: false);

                // Clean AutomaticDestinations (Jump Lists)
                string autoDest = Path.Combine(recentPath, "AutomaticDestinations");
                CleanDirectoryContents(autoDest, "Jump List (Auto)", simulationMode);

                // Clean CustomDestinations (Jump Lists)
                string customDest = Path.Combine(recentPath, "CustomDestinations");
                CleanDirectoryContents(customDest, "Jump List (Custom)", simulationMode);
            }
            catch (Exception ex)
            {
                 Log($"Error cleaning Quick Access: {ex.Message}", LogLevel.WARNING);
            }
        }

        private static void CleanBrowsers(bool simulationMode)
        {
            Log("Cleaning Browser Caches...", LogLevel.INFO);
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var browserPaths = new List<string>
            {
                Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Cache"),
                Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Code Cache"),
                Path.Combine(localAppData, "Microsoft", "Edge", "User Data", "Default", "Cache"),
                Path.Combine(localAppData, "BraveSoftware", "Brave-Browser", "User Data", "Default", "Cache"),
                Path.Combine(appData, "Opera Software", "Opera Stable", "Cache")
            };

            foreach (var path in browserPaths) CleanDirectoryContents(path, "Browser Cache", simulationMode);

            // Firefox special handling (Profiles)
            string firefoxProfiles = Path.Combine(appData, "Mozilla", "Firefox", "Profiles");
            if (Directory.Exists(firefoxProfiles))
            {
                try
                {
                    foreach (var profile in Directory.GetDirectories(firefoxProfiles))
                    {
                        string cachePath = Path.Combine(profile, "cache2", "entries");
                        CleanDirectoryContents(cachePath, "Firefox Cache", simulationMode);
                    }
                }
                catch {}
            }
        }

        private static void CleanApplications(bool simulationMode)
        {
            Log("Cleaning Application Caches...", LogLevel.INFO);
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var appPaths = new List<string>
            {
                Path.Combine(appData, "discord", "Cache"),
                Path.Combine(appData, "discord", "Code Cache"),
                Path.Combine(appData, "discord", "GPUCache"),
                Path.Combine(appData, "Slack", "Cache"),
                Path.Combine(appData, "Slack", "Code Cache"),
                Path.Combine(localAppData, "Spotify", "Storage"),
                Path.Combine(localAppData, "Steam", "htmlcache")
            };

            foreach (var path in appPaths) CleanDirectoryContents(path, "App Cache", simulationMode);
        }

        private static void CleanRegistryHistory(bool simulationMode)
        {
            Log("Cleaning Registry Histories (MRUs)...", LogLevel.INFO);
            
            var keysToClean = new Dictionary<string, string>
            {
                { @"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU", "Start Menu Run History" },
                { @"Software\Microsoft\Windows\CurrentVersion\Explorer\WordWheelQuery", "Find File History" },
                { @"Software\Microsoft\Windows\CurrentVersion\Applets\Paint\Recent File List", "MS Paint Recent Files" },
                { @"Software\Microsoft\Windows\CurrentVersion\Applets\Wordpad\Recent File List", "MS Wordpad Recent Files" },
                { @"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", "Regedit Last Key" }, // Special handling needed usually, but clearing works
                { @"Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\OpenSavePidlMRU", "Common Dialog Open/Save History" },
                { @"Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\LastVisitedPidlMRU", "Common Dialog Last Visited Folder" },
                { @"Software\Microsoft\Windows\CurrentVersion\Explorer\TypedPaths", "Explorer Typed Paths" }
            };

            if (simulationMode)
            {
                foreach (var item in keysToClean)
                {
                    Log($"SIMULATION: Would clear Registry Key HKCU\\{item.Key} ({item.Value})", LogLevel.INFO);
                }
                Log("SIMULATION: Would clear UserAssist (Start Menu Usage Logs)", LogLevel.INFO);
                return;
            }

            foreach (var item in keysToClean)
            {
                try
                {
                    using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(item.Key, true))
                    {
                        if (key != null)
                        {
                            // Clear all values except (Default)
                            foreach (var valueName in key.GetValueNames())
                            {
                                key.DeleteValue(valueName);
                            }
                            Log($"Cleared: {item.Value}", LogLevel.SUCCESS);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log($"Failed to clear {item.Value}: {ex.Message}", LogLevel.WARNING);
                }
            }

            // UserAssist (ROT13 encoded logs)
            try
            {
                string userAssistPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\UserAssist";
                using (RegistryKey? uaKey = Registry.CurrentUser.OpenSubKey(userAssistPath, true))
                {
                    if (uaKey != null)
                    {
                        foreach (var subKeyName in uaKey.GetSubKeyNames())
                        {
                            using (RegistryKey? subKey = uaKey.OpenSubKey(subKeyName, true))
                            {
                                if (subKey != null)
                                {
                                    using (RegistryKey? countKey = subKey.OpenSubKey("Count", true))
                                    {
                                        if (countKey != null)
                                        {
                                            foreach (var val in countKey.GetValueNames()) countKey.DeleteValue(val);
                                            Log($"Cleared UserAssist Log: {subKeyName}", LogLevel.SUCCESS);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to clear UserAssist: {ex.Message}", LogLevel.WARNING);
            }
        }

        private static void CleanClipboard(bool simulationMode)
        {
            Log("Emptying Clipboard...", LogLevel.INFO);
            if (simulationMode)
            {
                Log("SIMULATION: Would empty System Clipboard", LogLevel.INFO);
                return;
            }

            // Use the delegate to invoke back to UI thread where Clipboard is accessible
            if (ClearClipboardAction != null)
            {
                ClearClipboardAction.Invoke();
            }
            else
            {
                Log("Clipboard cleaning skipped (UI context missing).", LogLevel.WARNING);
            }
        }

        private static void CleanSystemImage(bool simulationMode)
        {
            Log("Running DISM Component Cleanup...", LogLevel.INFO);
            Log("NOTE: This step usually takes 10-30 minutes depending on system speed. Please be patient...", LogLevel.WARNING);
            RunProcess("dism.exe", "/Online /Cleanup-Image /StartComponentCleanup", "DISM Cleanup", simulationMode);
        }

        private static void CleanDiskCleanup(bool simulationMode)
        {
            Log("Running Windows Disk Cleanup...", LogLevel.INFO);
            // In a real scenario, we might want to set registry keys first like the script does.
            // For simplicity in C#, we'll just run it with default flags or sagerun if configured.
            // The script sets registry keys. Let's try to mimic that via PowerShell or just run cleanmgr.
            
            if (simulationMode)
            {
                Log("SIMULATION: Would run cleanmgr.exe /sagerun:1", LogLevel.INFO);
                return;
            }

            // Setting registry keys requires Registry access which is platform specific.
            // To be safe and keep it simple, we'll invoke the PowerShell snippet to set the keys if possible, 
            // or just rely on the user having run it before.
            // Better yet, just run cleanmgr /sagerun:1 and assume the best, or use PowerShell to set keys.
            
            string setKeysScript = @"
$RegPath = 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches';
$Keys = @('Temporary Files', 'Recycle Bin', 'Thumbnail Cache', 'Downloaded Program Files', 'Internet Cache Files', 'Old ChkDsk Files', 'Windows Error Reporting Files', 'Delivery Optimization Files');
foreach ($Key in $Keys) {
    $FullPath = Join-Path $RegPath $Key;
    if (Test-Path $FullPath) { Set-ItemProperty -Path $FullPath -Name 'StateFlags0001' -Value 2 -Type DWord -ErrorAction SilentlyContinue }
}";
            
            RunProcess("powershell.exe", $"-Command \"{setKeysScript}\"", "Configure Disk Cleanup", simulationMode);
            RunProcess("cleanmgr.exe", "/sagerun:1", "Disk Cleanup Utility", simulationMode, waitForExit: true);
        }
    }
}
