cd $PSScriptRoot/../../src/Calculator.Console
dotnet build
cd $PSScriptRoot/../../tests/Calculator.Console.Tests
dotnet test --settings ../../scenarios/scenario11/coverage.runsettings