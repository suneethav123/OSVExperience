@ECHO OFF
set Relativepath=%~dp0%
echo %Relativepath%
cd..
cd..
set relativeChromeDriverPath=\SpecFlowSharp\Drivers
set absolutePathToChromeDriver=%CD%%relativeChromeDriverPath%
echo %absolutePathToChromeDriver%
set chromeFile=\chromedriver.exe
set absoluteChromeFilePath=%absolutePathToChromeDriver%%chromeFile%
echo %absoluteChromeFilePath%
pushd "Grid"
pushd "Grid_Setup_Resources"
java -jar selenium-server-standalone-2.53.0.jar -port 5555 -role node -hub http://localhost:4444/grid/register -Dwebdriver.chrome.driver=%absoluteChromeFilePath% -browser browserName=chrome,maxInstances=3,version=36,platform=WINDOWS 
exit
