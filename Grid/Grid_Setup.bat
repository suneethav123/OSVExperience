@ECHO OFF
set Relativepath=%~dp0%
echo %Relativepath%
pushd Grid_Setup_Resources
timeout /t 2
start /wait SetupHub.bat
timeout /t 3
start Setup_Chrome.bat
timeout /t 2
start Setup_Firefox.bat
timeout /t 2
start Setup_Ie.bat
exit
