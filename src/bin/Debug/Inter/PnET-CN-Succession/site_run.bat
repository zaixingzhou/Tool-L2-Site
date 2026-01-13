@echo off

REM call landis-ii-7 EMS_scenario_pnet.txt
echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

rmdir /s /q output

dotnet C:\Users\zzhou\Documents\GitHub\PnET_CN_Succession\aruzicka555\Extension-PnET-Succession\src\bin\Debug\Landis.console.dll site_Scenario.txt

exit