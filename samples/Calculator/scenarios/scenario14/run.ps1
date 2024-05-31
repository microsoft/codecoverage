Push-Location
cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect --output report.coverage --session-id TagScenario14 "dotnet run --no-build" &
cd $PSScriptRoot/../../tests/Calculator.Server.IntegrationTests
dotnet test --collect "Code Coverage"
dotnet-coverage shutdown TagScenario14
dotnet-coverage merge --output merged.coverage **/*.coverage $PSScriptRoot/../../src/Calculator.Server/report.coverage
Pop-Location