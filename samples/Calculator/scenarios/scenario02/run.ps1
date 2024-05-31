Push-Location
cd $PSScriptRoot/../../tests/Calculator.Core.Tests
dotnet test --collect "Code Coverage;Format=cobertura"
Pop-Location