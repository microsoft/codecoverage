Push-Location
cd $PSScriptRoot/../../tests/Calculator.Core.Tests
dotnet test --settings ../../scenarios/scenario07/coverage.runsettings
Pop-Location