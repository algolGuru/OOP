@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

echo Try to invert 6 . Waited result - 96
%MyProgram% "6" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0OutputForInput6.txt" || goto err
echo Test 1 passed

echo Try to invert number that greater than byte . Waited result - error in output
%MyProgram% "260" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InputDataMoreThan1ByteError.txt" || goto err
echo Test 2 passed

echo Try to invert number that greater than byrt . Waited result - error in output
%MyProgram% "-5" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InputDataMoreThan1ByteError.txt" || goto err
echo Test 3 passed

echo Try to invert when program got zero arguments. Waited result - error in output
%MyProgram% > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0ArgumentCountError.txt" || goto err
echo Test 4 passed

echo Try to invert incorect data. Waited result - error in output 
%MyProgram% "260asd" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidInputDataError.txt" || goto err
echo Test 5 passed

echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1