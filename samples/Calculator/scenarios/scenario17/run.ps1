Push-Location
cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect --output-format cobertura --output ../../report.cobertura.xml --session-id TagScenario17 "dotnet run --no-build" &
cd $PSScriptRoot/../../tests/Calculator.Server.IntegrationTests
dotnet-coverage connect TagScenario17 "dotnet test --no-build --filter add"
dotnet-coverage snapshot --output ../../snapshot1.cobertura.xml TagScenario17
dotnet-coverage connect TagScenario17 "dotnet test --no-build --filter multiply"
dotnet-coverage snapshot --output ../../snapshot2.cobertura.xml TagScenario17
dotnet-coverage connect TagScenario17 "dotnet test --no-build --filter subtract"
dotnet-coverage snapshot --output ../../snapshot3.cobertura.xml TagScenario17
dotnet-coverage connect TagScenario17 "dotnet test --no-build --filter divide"
dotnet-coverage snapshot --output ../../snapshot4.cobertura.xml TagScenario17
dotnet-coverage shutdown TagScenario17
cd $PSScriptRoot/../..
Pop-Location