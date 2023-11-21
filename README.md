# Microsoft code coverage tools

Microsoft code coverage functionality is closed source. This repository contains documentation and samples. You can also use it to report any issues related to `Microsoft.CodeCoverage` NuGet package, `dotnet-coverage` NuGet package or Visual Studio code coverage functionality.

## Get started

To collect code coverage for .NET test project you can simply execute:
```shell
dotnet new mstest -o mstests
cd mstests
dotnet test --collect "Code Coverage;Format=cobertura"
```
You should see output:
```shell
Determining projects to restore...
  All projects are up-to-date for restore.
  mstests -> D:\mstests\bin\Debug\net8.0\mstests.dll
Test run for D:\mstests\bin\Debug\net8.0\mstests.dll (.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.8.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 16 ms - mstests.dll (net8.0)

Attachments:
  D:\mstests\TestResults\caf685fa-04ce-4858-9feb-ae472f1a71e1\dd166e58-6e19-4741-931a-816d025fcb32.cobertura.xml
```

For any .NET application you can collect code coverage in this way:
```shell
dotnet new console -o sample1
cd sample1
dotnet tool install -g dotnet-coverage
dotnet-coverage collect "dotnet run"
```

You should see output:
```shell
Microsoft (R) Code Coverage Command Line Tool (x64)
Copyright (c) Microsoft Corporation. All rights reserved.

SessionId: d1bf31db-f634-4b2c-a627-c708ac93d85b
Hello, World!
Code coverage results: output.coverage.
```

## Documentation 

* Documentation for `dotnet-coverage` tool is available at https://aka.ms/dotnet-coverage.
* Documentation for `Microsoft.CodeCoverage` is available at https://learn.microsoft.com/visualstudio/test/customizing-code-coverage-analysis.
* [Supported OS versions](docs/supported-os.md)

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
