**Scenario Description**

Collect code coverage using default settings. Default format is binary (`.coverage` extension) which can be opened in Visual Studio Enterprise.

**Collect code coverage using command line**

```shell
cd tests/Calculator.Core.Tests/
dotnet test --collect "Code Coverage"
```

You can also use [run.ps1](run.ps1) to collect code coverage.

**Collect code coverage inside github workflow**

```shell
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 7.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --collect "Code Coverage" --no-build --verbosity normal
    - name: Archive code coverage results
      uses: actions/upload-artifact@v3
      with:
        name: code-coverage-report
        path: ./**/*.coverage
```

[Full example](https://github.com/microsoft/codecoverage/blob/main/.github/workflows/Calculator_Scenario01.yml)

**Report example**

![alt text](example.report.jpg "Example report")

[Full report](example.report.coverage)