Push-Location
cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect --output report.coverage --session-id TagScenario18 "dotnet run --no-build" &
cd $PSScriptRoot/../..
dotnet test --collect "Code Coverage" --results-directory "$PSScriptRoot/../../TestResults/"
dotnet-coverage shutdown TagScenario18
dotnet-coverage merge --output-format cobertura --output merged.cobertura.xml $PSScriptRoot/../../TestResults/**/*.coverage $PSScriptRoot/../../src/Calculator.Server/report.coverage
Pop-Location