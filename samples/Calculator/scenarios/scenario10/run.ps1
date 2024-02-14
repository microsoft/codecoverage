cd $PSScriptRoot/../../src/Calculator.Console
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage instrument --session-id TagScenario10 "./bin/Debug/net8.0/Calculator.Core.dll"
dotnet-coverage instrument --session-id TagScenario10 "./bin/Debug/net8.0/Calculator.Console.dll"
dotnet-coverage collect --session-id TagScenario10 --server-mode --background -f cobertura
dotnet run --no-build add 10 24
dotnet run --no-build multiply 10 24
dotnet-coverage shutdown TagScenario10