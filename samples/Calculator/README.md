# Solution summary

Solution contains seven projects:

1. `Calculator.Core` - contains core logic for solution
2. `Calculator.Console` - console application, references `Calculator.Core`
3. `Calculator.Server` - ASP.NET Core service, references `Calculator.Core`
4. `Calculator.Core.Tests` - contains unit tests for `Calculator.Core`
5. `Calculator.Console.Tests` - contains tests for `Calculator.Console`, starts `Calculator.Console` as child process and verifies output
6. `Calculator.Server.Tests` - standard ASP.NET Core tests for `Calculator.Server` project
7. `Calculator.Server.IntegrationTests` - integration tests for `Calculator.Server` project. Before tests are executed `Calculator.Server` needs to be started locally

## Scenarios

1. [***Scenario 01*** Default settings (binary .coverage report)](scenarios/scenario01/README.md)
2. [***Scenario 02*** Cobertura format by command line](scenarios/scenario02/README.md)
3. [***Scenario 03*** Cobertura format by configuration](scenarios/scenario03/README.md)
4. [***Scenario 04*** XML format by command line](scenarios/scenario04/README.md)
5. [***Scenario 05*** Exclude project, method and source file](scenarios/scenario05/README.md)
6. [***Scenario 06*** Exclude tests projects and other libraries (xunit, moq)](scenarios/scenario06/README.md)
7. [***Scenario 07*** Static instrumentation](scenarios/scenario07/README.md)
8. [***Scenario 08*** Code coverage for console application](scenarios/scenario08/README.md)
9. [***Scenario 09*** Code coverage for console application - static instrumentation](scenarios/scenario09/README.md)
10. [***Scenario 10*** Code coverage for console application - static instrumentation with instrument command](scenarios/scenario10/README.md)
11. [***Scenario 11*** Code coverage for child processes enabled](scenarios/scenario11/README.md)
12. [***Scenario 12*** Code coverage for child processes disabled](scenarios/scenario12/README.md)
13. [***Scenario 13*** Code coverage for ASP.NET Core tests](scenarios/scenario13/README.md)
14. [***Scenario 14*** Code coverage for ASP.NET Core integration tests](scenarios/scenario14/README.md)
15. [***Scenario 15*** Code coverage for ASP.NET Core integration tests - coverage collection in server mode](scenarios/scenario15/README.md)
16. [***Scenario 16*** Code coverage for ASP.NET Core integration tests - code coverage report per test](scenarios/scenario16/README.md)
17. [***Scenario 17*** Code coverage for ASP.NET Core integration tests - snapshots without resetting counters](scenarios/scenario17/README.md)
18. [***Scenario 18*** Code coverage for whole solution](scenarios/scenario18/README.md)
19. [***Scenario 19*** Code coverage for whole solution with test projects excluded](scenarios/scenario19/README.md)
20. [***Scenario 20*** Code coverage for whole solution with logs](scenarios/scenario20/README.md)
21. [***Scenario 21*** Code coverage for whole solution with script to run tests](scenarios/scenario21/README.md)
22. [***Scenario 22*** Code coverage for child processes using static instrumentation without binaries restore](scenarios/scenario22/README.md)
23. [***Scenario 23*** Code coverage for child processes using static instrumentation with binaries restore](scenarios/scenario23/README.md)
24. [***Scenario 24*** Code coverage for whole solution (only unit tests)](scenarios/scenario24/README.md)
25. [***Scenario 25*** Code coverage for whole solution (only unit tests - using dotnet-coverage)](scenarios/scenario25/README.md)
