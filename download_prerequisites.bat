@echo off
echo Downloading .NET 8.0 Prerequisites...
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0download_prerequisites.ps1"
echo.
echo Downloads complete.
pause
