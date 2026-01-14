@echo off


echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

REM rmdir /s /q output

call landis-ii-8 site_Scenario.txt

pause
