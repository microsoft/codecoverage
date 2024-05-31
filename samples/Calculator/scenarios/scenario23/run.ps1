Push-Location
cd $PSScriptRoot/../../src/Calculator.Console
dotnet build
$env:STATIC_INSTRUMENTATION_DIR="$PSScriptRoot/../../src/Calculator.Console"
cd $PSScriptRoot/../../tests/Calculator.Console.Tests
dotnet test --settings ../../scenarios/scenario23/coverage.runsettings
Pop-Location