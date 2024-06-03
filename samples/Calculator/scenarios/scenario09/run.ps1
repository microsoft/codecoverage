Push-Location
cd $PSScriptRoot/../../src/Calculator.Console
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage collect -f cobertura -s ../../scenarios/scenario09/coverage.runsettings --include-files "./bin/Debug/**/*.dll" "dotnet run --no-build add 10 24"
Pop-Location