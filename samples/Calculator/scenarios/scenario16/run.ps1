cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect --output-format cobertura --output ../../final.cobertura.xml --session-id TagScenario16 "dotnet run --no-build" &
cd $PSScriptRoot/../../tests/Calculator.Server.IntegrationTests
dotnet-coverage connect TagScenario16 "dotnet test --no-build --filter add"
dotnet-coverage snapshot --reset --output ../../snapshot1.cobertura.xml TagScenario16
dotnet-coverage connect TagScenario16 "dotnet test --no-build --filter multiply"
dotnet-coverage snapshot --reset --output ../../snapshot2.cobertura.xml TagScenario16
dotnet-coverage connect TagScenario16 "dotnet test --no-build --filter subtract"
dotnet-coverage snapshot --reset --output ../../snapshot3.cobertura.xml TagScenario16
dotnet-coverage connect TagScenario16 "dotnet test --no-build --filter divide"
dotnet-coverage snapshot --reset --output ../../snapshot4.cobertura.xml TagScenario16
dotnet-coverage shutdown TagScenario16
cd $PSScriptRoot/../..
dotnet-coverage merge --output-format cobertura --output report.cobertura.xml *.cobertura.xml