@echo off

REM call landis-ii-7 EMS_scenario_pnet.txt
echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

rmdir /s /q output

call landis-ii-7 site_Scenario.txt

pause