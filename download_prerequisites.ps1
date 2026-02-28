# Downloads the .NET 8.0 Desktop Runtime installers (x86 and x64)

# Ensure the Prerequisites directory exists
$PrerequisitesDir = Join-Path $PSScriptRoot "Prerequisites"
if (-not (Test-Path -Path $PrerequisitesDir)) {
    New-Item -ItemType Directory -Path $PrerequisitesDir | Out-Null
}

# Use stable aka.ms links for the latest .NET 8.0 Desktop Runtime
$x64Url = "https://aka.ms/dotnet/8.0/windowsdesktop-runtime-win-x64.exe"
$x86Url = "https://aka.ms/dotnet/8.0/windowsdesktop-runtime-win-x86.exe"

$x64Path = Join-Path $PrerequisitesDir "windowsdesktop-runtime-8.0.0-win-x64.exe"
$x86Path = Join-Path $PrerequisitesDir "windowsdesktop-runtime-8.0.0-win-x86.exe"

Write-Host "Downloading .NET 8.0 Desktop Runtime (x64)..."
try {
    # -UseBasicParsing is safer for older PowerShell versions (Win 7/8)
    # Redirects are followed by default in Invoke-WebRequest
    Invoke-WebRequest -Uri $x64Url -OutFile $x64Path -UseBasicParsing
    Write-Host "Downloaded to $x64Path" -ForegroundColor Green
}
catch {
    Write-Host "Error downloading x64 runtime: $_" -ForegroundColor Red
}

Write-Host "Downloading .NET 8.0 Desktop Runtime (x86)..."
try {
    Invoke-WebRequest -Uri $x86Url -OutFile $x86Path -UseBasicParsing
    Write-Host "Downloaded to $x86Path" -ForegroundColor Green
}
catch {
    Write-Host "Error downloading x86 runtime: $_" -ForegroundColor Red
}

Write-Host "Done. You can now build the installer using Inno Setup."
