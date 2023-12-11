cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect --output report.coverage --session-id TagScenario19 "dotnet run --no-build" &
cd $PSScriptRoot/../..
dotnet test --settings ./scenarios/scenario19/coverage.runsettings --results-directory "$PSScriptRoot/../../TestResults/"
dotnet-coverage shutdown TagScenario19
dotnet-coverage merge --output-format cobertura --output merged.cobertura.xml $PSScriptRoot/../../TestResults/**/*.coverage $PSScriptRoot/../../src/Calculator.Server/report.coverage