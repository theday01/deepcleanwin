# DeepClean Pro (C# Edition)

DeepClean Pro is a system maintenance utility ported from PowerShell to a C# Windows Forms application. It provides a hacker-style UI with detailed logging and a safe simulation mode.

## Features
- **Simulation Mode (Default)**: Dry run to preview what would be cleaned without modifying files.
- **Admin Privileges**: Automatically requests elevation to perform system tasks.
- **Deep Cleaning**:
  - System Temp & Prefetch
  - Windows Update Cache
  - Logs (Event Logs & Files)
  - Recycle Bin
  - Browser Caches (Chrome, Edge, Firefox, etc.)
  - Application Caches (Discord, Slack, Spotify, Steam)
  - DISM Component Cleanup & Disk Cleanup

## Prerequisites
**To Run the App:**
- Windows 10 or later
- [.NET 8.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/runtime)

**To Build (Compile) the App:**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## How to Build
1. **Double-click `build.bat`** to automatically compile the project.
   - If it says ".NET SDK not found", please install the .NET 8.0 SDK from the link above.
2. The executable will be created in `bin\Release\net8.0-windows`.

## Building the Installer (EXE)
To create a standalone installer for DeepClean Pro:
1. Ensure you have [Inno Setup](https://jrsoftware.org/isinfo.php) installed.
2. **Download Prerequisites**: Double-click `download_prerequisites.bat` to download the .NET 8.0 Desktop Runtime installers into the `Prerequisites` folder.
   * This script works on Windows 7+ and requires no special setup.
3. **Run `build.bat`**.
   * *Note: The Inno Setup script expects `DeepCleanPro.exe` to exist in `bin\Release\net8.0-windows\`.*
4. Open `setup.iss` with Inno Setup Compiler.
5. Click "Compile" (or press Ctrl+F9).
6. The installer (`DeepCleanPro_Setup_v2.0.exe`) will be generated in the `Output` folder. It will now bundle the .NET Runtime and install it automatically if needed.

## Usage
1. Run `DeepCleanPro.exe` as Administrator (it will prompt automatically).
2. Review the logs in the console window.
3. Uncheck "Simulation Mode" to perform actual cleanup.
4. Click "INITIATE CLEANUP".

## Safety
- Always creates a System Restore Point before modification (in Live Mode).
- Errors are logged explicitly.
