@echo off

REM call landis-ii-7 EMS_scenario_pnet.txt
echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

REM rmdir /s /q output

REM landis-ii-8 site_Scenario.txt
dotnet C:\Users\zzhou\Documents\GitHub\ZZ_BiomassExtension\Extension-Biomass-Succession\src\bin\Debug\Landis.console.dll site_Scenario.txt

pause