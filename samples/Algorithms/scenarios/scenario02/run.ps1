Push-Location
cd $PSScriptRoot/../../tests/Algorithms.Core.Tests
dotnet run --coverage --coverage-output report.cobertura.xml --coverage-output-format cobertura --coverage-settings $PSScriptRoot/coverage.config
Pop-Location