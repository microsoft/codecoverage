cd $PSScriptRoot/../../src/Calculator.Console
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage collect -f cobertura "dotnet run --no-build add 10 24"