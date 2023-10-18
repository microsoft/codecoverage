cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage collect --output-format cobertura --output report.cobertura.xml --session-id TagScenario15 --background --server-mode
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage connect --background TagScenario15 "dotnet run --no-build"
cd $PSScriptRoot/../../tests/Calculator.Server.IntegrationTests
dotnet-coverage connect TagScenario15 "dotnet test --no-build"
dotnet-coverage shutdown TagScenario15
cd $PSScriptRoot/../..