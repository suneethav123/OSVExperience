@pushd %~dp0
@echo OFF
set Relativepath=%~dp0%
if not exist "%Relativepath%\Automation_Report" mkdir "%Relativepath%Automation_Report"
REM if exist "%Relativepath%\Automation_Report\SpecRun_Report" rmdir /Q /S "%Relativepath%\Automation_Report\SpecRun_Report"
if not exist "%Relativepath%\Automation_Report\SpecRun_Report" mkdir "%Relativepath%\Automation_Report\SpecRun_Report"
if not exist "C:\Program Files (x86)" set pathTo_devenv="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE"
if exist "C:\Program Files (x86)" set pathTo_devenv="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE"

echo current date is:%date%
pushd %pathTo_devenv%
echo %pathTo_devenv%
set pathToSln=OneAtmosphere\OneAtmosTestLibrary.sln
set AbsoultePathToSln=%Relativepath%%pathToSln%
echo %AbsoultePathToSln% 
call devenv.exe %AbsoultePathToSln% /rebuild 
echo devenv
popd
set dd=%date%
set Date=%dd:/=-%
set Date=%Date: =_%
set Date=%Date: =_%_%time:~0,2%%time:~3,2%%time:~6,2%
echo current date after replacement is:%Date%
set pathToDll=OneAtmosphere\bin\Debug
set FullPathToDll=%Relativepath%%pathToDll%
set PathToRunner=OneAtmosphere\bin\Debug\SpecFlowPlusRunner
pushd %Relativepath%%PathToRunner%
set Reports=Automation_Report\SpecRun_Report	
set PathToRunnerProfile=OneAtmosphere\Default.srprofile

SpecRun run %Relativepath%%PathToRunnerProfile% "/baseFolder:%FullPathToDll%" /outputfolder:%Relativepath%%Reports% /log:SpecRunLog_%Date%.log /report:Report_%date%.html /filter:@yyy

popd


set PathToReportFile=Automation_Report\SpecRun_Report\Report_%Date%.html
set AbsolutePathToReportFile=%Relativepath%%PathToReportFile%
pause
timeout /t 1
call %AbsolutePathToReportFile% open

exit
