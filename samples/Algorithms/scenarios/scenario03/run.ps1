cd $PSScriptRoot/../../tests/Algorithms.Core.Tests
dotnet build /p:MsCodeCoverageInstrumentation="true"
dotnet run --no-build --ms-coverage --ms-coverage-output report.cobertura.xml --ms-coverage-output-format cobertura