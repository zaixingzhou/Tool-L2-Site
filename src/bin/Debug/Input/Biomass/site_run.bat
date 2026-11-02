@echo off

echo Current Directory: %CD%

cd /d "%~dp0"
echo Changed Directory: %CD%

echo Checking LANDIS-II command...
where landis-ii-8

echo Running LANDIS-II...
call landis-ii-8 site_Scenario.txt

set LANDIS_EXIT=%ERRORLEVEL%

echo LANDIS-II Exit Code: %LANDIS_EXIT%

if not "%LANDIS_EXIT%"=="0" (
    echo LANDIS-II simulation failed!
) else (
    echo LANDIS-II simulation completed successfully.
)

exit /b %LANDIS_EXIT%