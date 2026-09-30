# Solution summary

This sample contains a full-trust packaged WinUI 3 application. The application includes a small
`CoverageCalculator` class that can be exercised from the UI while `dotnet-coverage` collects
JIT/CLRIE code coverage.

The application uses single-project MSIX packaging and must be deployed before the coverage
scenario can activate it by Application User Model ID (AUMID).

## Scenarios

1. [***Scenario 01*** Code coverage for a packaged WinUI 3 application](scenarios/scenario01/README.md)
