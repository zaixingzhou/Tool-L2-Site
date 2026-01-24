@echo off


echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

rmdir /s /q output
rmdir /s /q outputs

REM call landis-ii-8 site_Scenario.txt
dotnet C:\Users\zzhou\Documents\GitHub\ZZ_Extension-Density\Core-Model-v7\Tool-Console\src\bin\Debug\Landis.console.dll site_Scenario.txt


exit