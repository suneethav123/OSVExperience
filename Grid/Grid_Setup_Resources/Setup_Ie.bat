@ECHO OFF
set Relativepath=%~dp0%
echo %Relativepath%
cd..
cd..
set relativeIEDriverPath=\SpecFlowSharp\Drivers
set absolutePathToIEDriver=%CD%%relativeIEDriverPath%
echo %absolutePathToIEDriver%
set IeFile=\IEDriverServer.exe
set absoluteIEFilePath=%absolutePathToIEDriver%%IeFile%
echo %absoluteIEFilePath%
pushd "Grid"
pushd "Grid_Setup_Resources"
java -jar selenium-server-standalone-2.53.0.jar -port 8888 -role node -hub http://localhost:4444/grid/register -Dwebdriver.ie.driver=%absoluteIEFilePath% -browser "browserName=internet explorer,version=10,maxInstances=2,platform=WINDOWS"
exit