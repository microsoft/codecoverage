Push-Location
cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
$env:LOGS_DIR="$PSScriptRoot/../../logs/"
cd $PSScriptRoot/../../src/Calculator.Server
dotnet-coverage collect -l $PSScriptRoot/../../logs/collect.log -ll Verbose --settings $PSScriptRoot/../../scenarios/scenario20/coverage.runsettings --output report.coverage --session-id TagScenario20 "dotnet run --no-build" &
cd $PSScriptRoot/../..
dotnet test --settings ./scenarios/scenario20/coverage.runsettings --results-directory "$PSScriptRoot/../../TestResults/" --diag $PSScriptRoot/../../logs/log.txt
dotnet-coverage shutdown -l $PSScriptRoot/../../logs/shutdown.log -ll Verbose TagScenario20
dotnet-coverage merge -l $PSScriptRoot/../../logs/merge.log -ll Verbose --output-format cobertura --output merged.cobertura.xml $PSScriptRoot/../../TestResults/**/*.coverage $PSScriptRoot/../../src/Calculator.Server/report.coverage
Pop-Location