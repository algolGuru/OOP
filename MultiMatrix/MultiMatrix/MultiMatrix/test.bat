@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

echo Try to multiplicate matrixes . Waited result - valid output matrix
%MyProgram% matrixFile1.txt matrixFile2.txt > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0ValidOutput.txt" || goto err
echo Test 1 passed

echo Try to multiplicate matrixes. Waited result - another valid output matrix
%MyProgram% FloatNumbersInput.txt FloatNumbersInput.txt > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0AnoutherValidOutput.txt" || goto err
echo Test 2 passed

echo Try to multiplicate matrixes with invalid data. Waited result - invalid data output
%MyProgram% matrixFile1.txt matrixFileInvalid.txt > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidOutput.txt" || goto err
echo Test 3 passed

echo Invalid count of parameters. Waited result - invalid count of params in output
%MyProgram% matrixFile1.txt > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidCountOfParamsOutput.txt" || goto err
echo Test 4 passed

echo Not existed files. Waited result - error in output
%MyProgram% notExist.txt notExist2.txt > "%~dp0Output.txt" || goto err
fc "%~dp0Output.txt" "%~dp0InvalidOutput.txt" || goto err
echo Test 5 passed


%MyProgram% FloatNumbersInput.txt FloatNumbersInput.txt > "%~dp0Output.txt" || goto err

echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1