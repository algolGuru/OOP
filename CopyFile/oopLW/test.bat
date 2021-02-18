@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM Try to copy empty file. Waited result - emty output
%MyProgram% "EmptyFile.txt" "output.txt" || goto err
fc "%~dp0EmptyFile.txt" "%~dp0output.txt" || goto err
echo Test 1 passed

REM Try to copy non empty file. Waited result - non emty output
%MyProgram% "File.txt" "output.txt" || goto err
fc "%~dp0File.txt" "%~dp0output.txt" || goto err
echo Test 2 passed

REM Try to copy non existed file. Waited result - error
%MyProgram% "MissingFile.txt" "output.txt" && goto err
echo Test 3 passed

REM A single argument is passed to the parameters. Waited result - error
%MyProgram%  "File.txt" && goto err
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