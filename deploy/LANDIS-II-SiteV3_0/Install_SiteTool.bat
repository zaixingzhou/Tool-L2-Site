@echo off
REM Confirm action
echo This will delete all files and folders in the current directory.


REM Delete all files
echo Deleting all files...
del /q *.exe

REM Delete all folders
echo Deleting all folders...
for /d %%d in (*) do (
    rd /s /q "%%d"
)

echo Cleanup complete.


set  source=C:\Users\zzhou\Documents\GitHub\Tool-L2-Site-ZZ\src\bin\Debug\Input
REM Copy the folder to the current directory
xcopy "%source%" ".\Input" /s /e /i /h /y

set  source=C:\Users\zzhou\Documents\GitHub\Tool-L2-Site-ZZ\src\bin\Debug\Inter
REM Copy the folder to the current directory
xcopy "%source%" ".\Inter" /s /e /i /h /y

set  source=C:\Users\zzhou\Documents\GitHub\Tool-L2-Site-ZZ\src\bin\Debug\Output
REM Copy the folder to the current directory
xcopy "%source%" ".\Output" /s /e /i /h /y


set  source=C:\Users\zzhou\Documents\GitHub\Tool-L2-Site-ZZ\src\bin\Debug\*.exe
REM Copy the folder to the current directory
copy "%source%" ".\" 

echo Folder copied successfully to the current directory.


pause