cd $PSScriptRoot/../../tests/Algorithms.Core.Tests
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage collect --output report.cobertura.xml --output-format cobertura "dotnet run --no-build"