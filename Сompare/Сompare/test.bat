@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM Try to compare equals files. Waited result - files are equals
%MyProgram% "1.txt" "2.txt" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0FilesAreEqualsOutput.txt" || goto err
echo Test 1 passed

REM Try to compare different files. Waited result - Files are different. Line number is 2
%MyProgram% "1.txt" "DifferentFile.txt" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0FilesNotEqualsOutput.txt" || goto err
echo Test 2 passed

REM Try to copy non existed file. Waited result - error
%MyProgram% "MissingFile.txt" "2.txt" && goto err
echo Test 3 passed

REM A single argument is passed to the parameters. Waited result - error
%MyProgram%  "1.txt" && goto err
echo Test 4 passed

REM A no arguments is passed to the parameters. Waited result - error
%MyProgram% && goto err
echo Test 5 passed

REM All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1