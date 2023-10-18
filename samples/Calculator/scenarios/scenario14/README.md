# Scenario Description

Collect code coverage for ASP.NET Core integration tests. You can find here example how to collect coverage for server and tests if they are running in separate processes and server is started before tests execution. `dotnet-coverage` tool is used to collect code coverage for server. At the end code coverage results for server and tests are merged. Default format is binary (`.coverage` extension) which can be opened in Visual Studio Enterprise. In pipelines during merging final coverage report is converted into cobertura format and published.

# Collect code coverage using command line

```shell
git clone https://github.com/microsoft/codecoverage.git
cd codecoverage/samples/Calculator
dotnet build
dotnet tool install -g dotnet-coverage
cd src/Calculator.Server
dotnet-coverage collect --output report.coverage --session-id TagScenario14 "dotnet run --no-build" &
cd ../../tests/Calculator.Server.IntegrationTests
dotnet test --collect "Code Coverage"
dotnet-coverage shutdown TagScenario14
dotnet-coverage merge -r --output merged.coverage *.coverage ../../src/Calculator.Server/report.coverage
```

You can also use [run.ps1](run.ps1) to collect code coverage.

# Collect code coverage inside github workflow

To generate summary report `.coverage` report needs to be converted to `cobertura` report using `dotnet-coverage` tool. Then `reportgenerator` can be used to generate final github summary markdown.

```yml
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
    - name: Install dotnet-coverage
      run: dotnet tool install -g dotnet-coverage
    - name: Start server
      run: dotnet-coverage collect --output report.coverage --session-id TagScenario14 "dotnet run --no-build" &
      working-directory: ./samples/Calculator/src/Calculator.Server
    - name: Run tests
      run: dotnet test --collect "Code Coverage" --no-build --verbosity normal
      working-directory: ./samples/Calculator/tests/Calculator.Server.IntegrationTests
    - name: Stop server
      run: dotnet-coverage shutdown TagScenario14
    - name: Merge coverage reports
      run: dotnet-coverage merge -r -f cobertura -o $GITHUB_WORKSPACE/report.cobertura.xml *.coverage ../../src/Calculator.Server/report.coverage
      working-directory: ./samples/Calculator/tests/Calculator.Server.IntegrationTests
    - name: ReportGenerator
      uses: danielpalme/ReportGenerator-GitHub-Action@5.1.24
      with:
        reports: '${{ github.workspace }}/report.cobertura.xml'
        targetdir: '${{ github.workspace }}/coveragereport'
        reporttypes: 'MarkdownSummaryGithub'
    - name: Upload coverage into summary
      run: cat $GITHUB_WORKSPACE/coveragereport/SummaryGithub.md >> $GITHUB_STEP_SUMMARY
    - name: Archive code coverage results
      uses: actions/upload-artifact@v3
      with:
        name: code-coverage-report
        path: '${{ github.workspace }}/report.cobertura.xml'
```

[Full source example](../../../../.github/workflows/Calculator_Scenario13.yml)

[Run example](../../../../../../actions/workflows/Calculator_Scenario13.yml)

# Collect code coverage inside Azure DevOps Pipelines

```yml
steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'restore'
    projects: '$(projectPath)' # this is specific to example - in most cases not needed
  displayName: 'dotnet restore'

- task: DotNetCoreCLI@2
  inputs:
    command: 'restore'
    projects: '$(testProjectPath)' # this is specific to example - in most cases not needed
  displayName: 'dotnet restore (tests)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    arguments: '--no-restore --configuration $(buildConfiguration)'
    projects: '$(projectPath)' # this is specific to example - in most cases not needed
  displayName: 'dotnet build'

- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    arguments: '--no-restore --configuration $(buildConfiguration)'
    projects: '$(testProjectPath)' # this is specific to example - in most cases not needed
  displayName: 'dotnet build (tests)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'custom'
    custom: "tool"
    arguments: 'install -g dotnet-coverage'
  displayName: 'install dotnet-coverage'

- task: Bash@3
  inputs:
    targetType: 'inline'
    script: 'dotnet-coverage collect --output $(Agent.TempDirectory)/server.coverage --session-id TagScenario14 "dotnet run --project $(projectPath) --no-build" &'
  displayName: 'start server under coverage'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    arguments: '--no-build --configuration $(buildConfiguration) --collect "Code Coverage;CoverageFileName=tests.coverage" --logger trx --results-directory $(Agent.TempDirectory)'
    publishTestResults: false
    projects: '$(testProjectPath)' # this is specific to example - in most cases not needed
  displayName: 'execute integration tests'

- task: Bash@3
  inputs:
    targetType: 'inline'
    script: 'dotnet-coverage shutdown TagScenario14'
  displayName: 'stop server'

- task: Bash@3
  inputs:
    targetType: 'inline'
    script: 'dotnet-coverage merge -f cobertura -o merged.cobertura.xml --recursive "*.coverage"'
    workingDirectory: "$(Agent.TempDirectory)"
  displayName: 'merge coverage results'

- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'VSTest'
    testResultsFiles: '$(Agent.TempDirectory)/**/*.trx'
    publishRunAttachments: false

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: $(Agent.TempDirectory)/merged.cobertura.xml
```

> **_NOTE:_** To make sure that Code Coverage tab will be visible in Azure DevOps you need to make sure that previous steps will not publish test attachments (`publishRunAttachments: false` and `publishTestResults: false`).

[Full source example](azure-pipelines.yml)

![alt text](azure-pipelines.jpg "Code Coverage tab in Azure DevOps pipelines")

# Report example

![alt text](example.report.jpg "Example report")

[Link](example.report.cobertura.xml)