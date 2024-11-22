@echo off

REM call landis-ii-7 EMS_scenario_pnet.txt
echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

rmdir /s /q output

dotnet C:\Users\zzhou\Documents\GitHub\Core-Model-v7\Tool-Console\src\bin\Debug\Landis.console.dll EMS_scenario_pnet.txt

pause