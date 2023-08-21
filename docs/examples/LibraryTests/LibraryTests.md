**Collect code coverage using command line**

```shell
dotnet test --collect "Code Coverage;Format=cobertura"
```

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
      run: dotnet test --collect "Code Coverage;Format=cobertura" --no-build --verbosity normal
    - name: Archive code coverage results
      uses: actions/upload-artifact@v3
      with:
        name: code-coverage-report
        path: ./**/*.cobertura.xml
```

[Full example](https://github.com/microsoft/codecoverage/blob/main/.github/workflows/LibraryTests.yml)

**Report example**

```shell
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<coverage line-rate="0.6666666666666666" branch-rate="1" complexity="3" version="1.9" timestamp="1692622242" lines-covered="6" lines-valid="9">
  <packages>
    <package line-rate="0.5" branch-rate="1" complexity="2" name="library">
      <classes>
        <class line-rate="0.5" branch-rate="1" complexity="2" name="library.Class1" filename="/home/runner/work/codecoverage/codecoverage/docs/examples/LibraryTests/library/Class1.cs">
          <methods>
            <method line-rate="1" branch-rate="1" complexity="1" name="Add" signature="(int, int)">
              <lines>
                <line number="6" hits="1" branch="False" />
                <line number="7" hits="1" branch="False" />
                <line number="8" hits="1" branch="False" />
              </lines>
            </method>
            <method line-rate="0" branch-rate="1" complexity="1" name="Multiple" signature="(int, int)">
              <lines>
                <line number="11" hits="0" branch="False" />
                <line number="12" hits="0" branch="False" />
                <line number="13" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
...
```

[Full report](https://github.com/microsoft/codecoverage/blob/main/docs/examples/LibraryTests/example.report.cobertura.xml)