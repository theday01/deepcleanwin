@echo off
TITLE DeepClean Pro - Build Utility
COLOR 0A

REM Ensure script always runs from its own directory
cd /d "%~dp0"

echo ========================================================
echo        DEEP CLEAN PRO - BUILD SYSTEM
echo ========================================================
echo.

REM Check if dotnet command is available
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR] The .NET SDK is not installed or not in your PATH.
    echo.
    echo Please install the .NET 8.0 SDK to build this project:
    echo https://dotnet.microsoft.com/en-us/download/dotnet/8.0
    echo.
    echo Once installed, restart this window and try again.
    echo.
    pause
    exit /b 1
)

echo [+] .NET SDK found. Building project in Release mode...
echo.

REM Explicitly specify project file to avoid ambiguity
dotnet build "DeepCleanPro.csproj" -c Release
if %errorlevel% neq 0 (
    echo.
    echo [ERROR] Build failed. Please check the errors above.
    pause
    exit /b 1
)

echo.
echo [SUCCESS] Build completed successfully!
echo.
echo The executable is located at:
echo bin\Release\net8.0-windows\DeepCleanPro.exe
echo.
echo You can now proceed to compile 'setup.iss' with Inno Setup.
echo.
pause
