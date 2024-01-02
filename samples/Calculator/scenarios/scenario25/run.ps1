cd $PSScriptRoot/../..
dotnet build
dotnet tool install -g dotnet-coverage
dotnet-coverage collect -f cobertura -o report.cobertura.xml "dotnet test --no-build"