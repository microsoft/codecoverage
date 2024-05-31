Push-Location
cd $PSScriptRoot/../../src/Algorithms.Console
dotnet publish -r win-x64 -c Release /p:AotMsCodeCoverageInstrumentation="true"
dotnet tool install -g dotnet-coverage
dotnet-coverage collect --output report.cobertura.xml --output-format cobertura bin\Release\net8.0\win-x64\publish\Algorithms.Console.exe
Pop-Location