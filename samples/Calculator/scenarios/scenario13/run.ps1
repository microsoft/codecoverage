Push-Location
cd $PSScriptRoot/../../tests/Calculator.Server.Tests
dotnet test --collect "Code Coverage"
Pop-Location