using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DeepCleanPro
{
    public class DiskHealthChecker
    {
        public event Action<string>? OnLog;

        public async Task<string> RunHealthCheck()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**************************************************");
            sb.AppendLine("           HARD DISK HEALTH REPORT                ");
            sb.AppendLine("           DEEP CLEAN PRO DIAGNOSTICS             ");
            sb.AppendLine("**************************************************");
            sb.AppendLine($"Scan Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            // 1. Physical Disks (PowerShell)
            OnLog?.Invoke("Scanning Physical Disks...");
            sb.AppendLine(">>> PHYSICAL DISK INFORMATION:");
            sb.AppendLine("--------------------------------------------------");
            
            var disks = await GetPhysicalDisksInfo();
            if (disks.Count == 0)
            {
                sb.AppendLine("Could not retrieve disk info (Administrator privileges required?).");
            }
            
            foreach (var disk in disks)
            {
                sb.AppendLine($"[+] Disk: {disk.Model}");
                sb.AppendLine($"    - Media Type: {disk.MediaType}");
                sb.AppendLine($"    - Size: {FormatBytes(disk.Size)}");
                sb.AppendLine($"    - Health Status: {disk.HealthStatus}");
                sb.AppendLine($"    - Operational Status: {disk.OperationalStatus}");
                
                // Temperature Logic
                string tempDisplay = "N/A";
                
                // 1. Try PowerShell Reliability Counter first (Modern)
                if (disk.Temperature > 0)
                {
                    tempDisplay = $"{disk.Temperature} C (Modern API)";
                }
                else
                {
                    // 2. Try WMI MSStorageDriver_ATAPISmartData (Legacy/SATA)
                    // We try to match by model name loosely
                    int wmiTemp = await GetLegacySmartTemp();
                    if (wmiTemp > 0)
                    {
                        tempDisplay = $"{wmiTemp} C (SMART Attribute 194)";
                    }
                }

                sb.AppendLine($"    - Temperature: {tempDisplay}");
                sb.AppendLine($"    - Read Errors: {disk.ReadErrors}");
                sb.AppendLine($"    - Write Errors: {disk.WriteErrors}");
                sb.AppendLine("--------------------------------------------------");
            }
            sb.AppendLine();

            // 2. Volumes (PowerShell)
            OnLog?.Invoke("Scanning Disk Volumes...");
            sb.AppendLine(">>> VOLUME INFORMATION:");
            sb.AppendLine("--------------------------------------------------");
            var volumes = await GetVolumesInfo();
            foreach (var vol in volumes)
            {
                 sb.AppendLine($"[#] Volume ({vol.DriveLetter}): {vol.FileSystem}");
                 sb.AppendLine($"    - Total Size: {FormatBytes(vol.Size)}");
                 sb.AppendLine($"    - Free Space: {FormatBytes(vol.FreeSpace)} ({GetPercent(vol.FreeSpace, vol.Size)}%)");
                 sb.AppendLine("--------------------------------------------------");
            }
            sb.AppendLine();

            // 3. Performance Test (C#)
            OnLog?.Invoke("Running Performance Benchmark (Sequential I/O)...");
            sb.AppendLine(">>> PERFORMANCE BENCHMARK (System Temp Drive):");
            sb.AppendLine("--------------------------------------------------");
            
            await Task.Run(() => 
            {
                try 
                {
                    var perf = MeasureDiskSpeed();
                    sb.AppendLine($"[!] Write Speed: {perf.WriteSpeed:F2} MB/s");
                    sb.AppendLine($"[!] Read Speed:  {perf.ReadSpeed:F2} MB/s");
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"Benchmark Failed: {ex.Message}");
                }
            });
            
            sb.AppendLine("--------------------------------------------------");
            
            sb.AppendLine();
            sb.AppendLine("END OF REPORT.");
            return sb.ToString();
        }

        private struct DiskData {
            public string Model;
            public string MediaType;
            public string HealthStatus;
            public string OperationalStatus;
            public long Size;
            public int Temperature;
            public long ReadErrors;
            public long WriteErrors;
        }
        
        private struct VolumeData {
            public string DriveLetter;
            public string FileSystem;
            public long Size;
            public long FreeSpace;
        }

        private async Task<List<DiskData>> GetPhysicalDisksInfo()
        {
            var list = new List<DiskData>();
            // Script outputs fields separated by pipe '|'
            // Temp might be missing on some drives, handle carefully.
            string script = "[Console]::OutputEncoding = [System.Text.Encoding]::UTF8; Get-PhysicalDisk | ForEach-Object { $c = ($_ | Get-StorageReliabilityCounter -ErrorAction SilentlyContinue); \"$($_.FriendlyName)|$($_.MediaType)|$($_.HealthStatus)|$($_.OperationalStatus)|$($_.Size)|$($c.Temperature)|$($c.ReadErrorsTotal)|$($c.WriteErrorsTotal)\" }";
            
            string output = await RunPowerShell(script);
            
            using (StringReader sr = new StringReader(output))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length >= 5)
                    {
                        var d = new DiskData();
                        d.Model = parts[0];
                        d.MediaType = parts[1]; // SSD/HDD/Unspecified
                        d.HealthStatus = parts[2];
                        d.OperationalStatus = parts[3];
                        long.TryParse(parts[4], out d.Size);
                        
                        // Reliability counters might be empty if not supported
                        if (parts.Length > 5 && int.TryParse(parts[5], out int temp)) d.Temperature = temp;
                        if (parts.Length > 6 && long.TryParse(parts[6], out long rErr)) d.ReadErrors = rErr;
                        if (parts.Length > 7 && long.TryParse(parts[7], out long wErr)) d.WriteErrors = wErr;
                        
                        list.Add(d);
                    }
                }
            }
            return list;
        }

        private async Task<List<VolumeData>> GetVolumesInfo()
        {
            var list = new List<VolumeData>();
            // Get-Volume | Where-Object {$_.DriveLetter -ne $null}
            string script = "[Console]::OutputEncoding = [System.Text.Encoding]::UTF8; Get-Volume | Where-Object {$_.DriveLetter -ne $null} | ForEach-Object { \"$($_.DriveLetter):|$($_.FileSystem)|$($_.Size)|$($_.SizeRemaining)\" }";
            
            string output = await RunPowerShell(script);
            using (StringReader sr = new StringReader(output))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length >= 4)
                    {
                        var v = new VolumeData();
                        v.DriveLetter = parts[0];
                        v.FileSystem = parts[1];
                        long.TryParse(parts[2], out v.Size);
                        long.TryParse(parts[3], out v.FreeSpace);
                        list.Add(v);
                    }
                }
            }
            return list;
        }

        private async Task<string> RunPowerShell(string script)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // PowerShell -EncodedCommand expects UTF-16LE base64 string
                    string encodedScript = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));

                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "powershell.exe";
                    psi.Arguments = $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedScript}";
                    psi.RedirectStandardOutput = true;
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;
                    psi.StandardOutputEncoding = Encoding.UTF8;

                    using (Process p = new Process { StartInfo = psi })
                    {
                        p.Start();
                        string result = p.StandardOutput.ReadToEnd();
                        p.WaitForExit();
                        return result;
                    }
                }
                catch
                {
                    return "";
                }
            });
        }


        // Async wrapper for the WMI temperature fallback
        private async Task<int> GetLegacySmartTemp()
        {
             // Updated logic to find attribute 194 (Temperature) more robustly
             // The VendorSpecific byte array structure is:
             // Bytes 0-1: Protocol version
             // Bytes 2+: 12-byte attributes: [Index 1B] [Status 2B] [Value 1B] [Worst 1B] [Raw 6B] [Reserved 1B]
             // We look for Index 194 (0xC2). The Raw value (byte offset 5) is usually the Celsius temp.
             // Sometimes Current Value (byte offset 3) is also used. We'll prefer Raw (offset 5).
             string script = @"
$ErrorActionPreference = 'SilentlyContinue'
$foundTemp = 0
Get-WmiObject -Namespace root\wmi -Class MSStorageDriver_ATAPISmartData | ForEach-Object {
    $data = $_.VendorSpecific
    if ($data.Length -gt 2) {
        for ($i = 2; $i -lt ($data.Length - 12); $i += 12) {
            if ($data[$i] -eq 194) {
                $rawTemp = $data[$i + 5]
                if ($rawTemp -gt 0 -and $rawTemp -lt 100) {
                   $foundTemp = $rawTemp
                   break
                }
            }
        }
    }
    if ($foundTemp -gt 0) { break }
}
$foundTemp
";
            string res = await RunPowerShell(script);
            if (int.TryParse(res.Trim(), out int t)) return t;
            return 0;
        }

        private (double WriteSpeed, double ReadSpeed) MeasureDiskSpeed()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "deepclean_bench.tmp");
            int dataSizeMB = 64; 
            byte[] data = new byte[dataSizeMB * 1024 * 1024];
            new Random().NextBytes(data); // Fill with random data to avoid compression shortcuts

            Stopwatch sw = new Stopwatch();

            // Write Test
            sw.Start();
            using (FileStream fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.WriteThrough))
            {
                fs.Write(data, 0, data.Length);
            }
            sw.Stop();
            double writeSeconds = sw.Elapsed.TotalSeconds;
            double writeSpeed = (writeSeconds > 0) ? dataSizeMB / writeSeconds : 0;

            // Read Test
            sw.Reset();
            sw.Start();
            using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[data.Length];
                fs.Read(buffer, 0, buffer.Length);
            }
            sw.Stop();
            double readSeconds = sw.Elapsed.TotalSeconds;
            double readSpeed = (readSeconds > 0) ? dataSizeMB / readSeconds : 0;

            // Cleanup
            try { File.Delete(tempFile); } catch { }

            return (writeSpeed, readSpeed);
        }

        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.00} {sizes[order]}";
        }

        private string GetPercent(long free, long total)
        {
            if (total == 0) return "0";
            return ((double)free / total * 100).ToString("0.0");
        }
    }
}
