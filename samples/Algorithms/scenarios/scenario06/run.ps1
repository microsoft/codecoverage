cd $PSScriptRoot/../../tests/Algorithms.Core.NativeAot.Tests
dotnet publish -c Release -r win-x64 /p:AotMsCodeCoverageInstrumentation="true"
.\bin\Release\net8.0\win-x64\publish\Algorithms.Core.NativeAot.Tests.exe --coverage --coverage-output-format cobertura --coverage-output report.cobertura.xml