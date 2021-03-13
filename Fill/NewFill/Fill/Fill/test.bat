@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

echo "Start program with valid input. Waited result - output for valid input file"
%MyProgram% ValidInputFile.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputForValidInputFile.txt" || goto err
echo Test 1 passed

echo "Start program with empty input. Waited result - empty matrix in output file"
%MyProgram% EmptyFile.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputForEmptyFile.txt" || goto err
echo Test 2 passed

echo "Start program with valid input. Waited result - empty matrix in output file"
%MyProgram% DifferentValidInputFile.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputForDifferentValidInputFile.txt" || goto err
echo Test 3 passed

echo "Start program with input with spillage. Waited result -  shaded matrix"
%MyProgram% InputWithSpillage.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputForInputWithSpillage.txt" || goto err
echo Test 4 passed

echo "Start program with input with a matrix larger than 100 by 100. Waited result - output"
%MyProgram% InputWithBigMatrix.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputForBigMatrix.txt" || goto err
echo Test 5 passed

echo "Start program with doesn't exist input file. Waited result - input file not found"
%MyProgram% NotExistedFile.txt Output.txt || goto err
fc "%~dp0Output.txt" "%~dp0OutputInputFileNotFoundError.txt" || goto err
echo Test 6 passed

echo "Start program with 1 argument. Waited result - Invalid count of parameters "
%MyProgram% || goto err
fc "%~dp0Output.txt" "%~dp0OutputForInvalidCountOfParameters.txt" || goto err
echo Test 7 passed

echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1