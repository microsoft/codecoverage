Push-Location
cd $PSScriptRoot/../../tests/Algorithms.Core.MSTest.Sdk.Tests
dotnet run --coverage --coverage-output report.cobertura.xml --coverage-output-format cobertura
Pop-Location