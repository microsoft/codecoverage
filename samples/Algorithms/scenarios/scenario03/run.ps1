cd $PSScriptRoot/../../tests/Algorithms.Core.Tests
dotnet build /p:MsCodeCoverageInstrumentation="true"
dotnet run --no-build --coverage --coverage-output report.cobertura.xml --coverage-output-format cobertura