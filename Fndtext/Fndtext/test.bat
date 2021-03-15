@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

echo Try to find the contained text. Waited result - 2 and 4 line
%MyProgram% "File.txt" "my name" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0TextIsFindedAt2And4Line.txt" || goto err
echo Test 1 passed

echo Try to find the missing text. Waited result - text not found
%MyProgram% "File.txt" "some text" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0TextNotFoundFile.txt" || goto err
echo Test 2 passed

echo Try to find text in non existed file. Waited result - error
%MyProgram% "MissingFile.txt" "my name" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0FileDoesNotExistError.txt" || goto err
echo Test 3 passed

echo A single argument is passed to the parameters. Waited result - error
%MyProgram% "File.txt" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidCountOfParamsError.txt" || goto err
echo Test 4 passed

echo A no arguments is passed to the parameters. Waited result - error
%MyProgram% > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidCountOfParamsError.txt" || goto err
echo Test 5 passed

echo Try to find text from example. Waited result - text found at 1 line
%MyProgram% "ExampleFromTask.txt" "1231234" > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0OutputForExampleFromTask.txt" || goto err
echo Test 6 passed

echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1