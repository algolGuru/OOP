@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM Copy empty file
%MyProgram% "EmptyFile.txt" "output.txt" || goto err
fc "%~dp0EmptyFile.txt" "%~dp0output.txt" || goto err
echo Test 1 passed

REM Copy non empty file
%MyProgram% "File.txt" "output.txt" || goto err
fc "%~dp0File.txt" "%~dp0output.txt" || goto err
echo Test 2 passed

REM Copy missing file should fail
%MyProgram% "MissingFile.txt" "output.txt" && goto err
echo Test 3 passed

REM If	output file is not specified, program must fail
%MyProgram%  "MissingFile.txt" && goto err
echo Test 4 passed

REM If input and output files are not specified, program must fail
%MyProgram% && goto err
echo Test 5 passed

REM All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1