# Scenario Description

Collect code coverage for MSTest runner project in Native AOT mode.

> **_NOTE:_** MSTest runner project coverage extension by default is not collecting native code coverage. If you want to enable please set to `True` `EnableStaticNativeInstrumentation` or `EnableDynamicNativeInstrumentation` in configuration.

## Collect code coverage using command line

```shell
git clone https://github.com/microsoft/codecoverage.git
cd codecoverage/samples/Algorithms/tests/Algorithms.Core.NativeAot.Tests/
dotnet publish -r win-x64 -c Release /p:AotMsCodeCoverageInstrumentation="true"
.\bin\Release\net8.0\win-x64\publish\Algorithms.Core.NativeAot.Tests.exe --coverage --coverage-output-format cobertura --coverage-output report.cobertura.xml
```

You can also use [run.ps1](run.ps1) to collect code coverage.

## Collect code coverage inside github workflow

`reportgenerator` can be used to generate final github summary markdown.

```yml
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    - name: Publish
      run: dotnet publish -r linux-x64 -c Release /p:AotMsCodeCoverageInstrumentation="true"
    - name: Run
      run: ./bin/Release/net8.0/linux-x64/publish/Algorithms.Core.NativeAot.Tests --coverage --coverage-output $GITHUB_WORKSPACE/report.cobertura.xml --coverage-output-format cobertura
    - name: ReportGenerator
      uses: danielpalme/ReportGenerator-GitHub-Action@5.2.0
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
        path: ${{ github.workspace }}/report.cobertura.xml

```

[Full source example](../../../../.github/workflows/Algorithms_Scenario06.yml)

[Run example](../../../../../../actions/workflows/Algorithms_Scenario06.yml)

## Collect code coverage inside Azure DevOps Pipelines

```yml
steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: false
    zipAfterPublish: false
    arguments: '-r linux-x64 -c Release /p:AotMsCodeCoverageInstrumentation="true"'
    projects: '$(projectPath)' # this is specific to example - in most cases not needed
  displayName: 'publish'

- task: Bash@3
  inputs:
    targetType: 'inline'
    script: './samples/Algorithms/tests/Algorithms.Core.NativeAot.Tests/bin/Release/net8.0/linux-x64/publish/Algorithms.Core.NativeAot.Tests --coverage --coverage-output-format cobertura --coverage-output $(Agent.TempDirectory)/report.cobertura.xml --report-trx --results-directory $(Agent.TempDirectory)'
  displayName: 'test'

- task: PublishTestResults@2
  inputs:
    testResultsFormat: 'VSTest'
    testResultsFiles: '$(Agent.TempDirectory)/**/*.trx'
    publishRunAttachments: false

- task: PublishCodeCoverageResults@2
  inputs:
    summaryFileLocation: $(Agent.TempDirectory)/**/*.cobertura.xml
```

[Full source example](azure-pipelines.yml)

![alt text](azure-pipelines.jpg "Code Coverage tab in Azure DevOps pipelines")

## Report example

![alt text](example.report.jpg "Example report")

[Link](example.report.cobertura.xml)
