Push-Location
cd $PSScriptRoot/../../tests/Calculator.Core.Tests
dotnet test --collect "Code Coverage"
Pop-Location