@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM Try to copy empty file. Waited result - emty output
%MyProgram% 1.txt 2.txt || goto err
fc "%~dp01.txt" "%~dp02.txt" || goto err
echo Test 1 passed

REM All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1