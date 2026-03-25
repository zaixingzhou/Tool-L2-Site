@echo off


echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed to Batch File Directory: %CD%

rmdir /s /q output

REM call landis-ii-8 site_Scenario.txt
dotnet C:\Users\zzhou\Documents\GitHub\PnET_CN_Succession\Brian_version\Core-Model-v7\Tool-Console\src\bin\Debug\Landis.console.dll site_Scenario.txt


exit