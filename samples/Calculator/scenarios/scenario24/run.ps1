cd $PSScriptRoot/../..
dotnet build
dotnet test --no-build --collect "Code Coverage"