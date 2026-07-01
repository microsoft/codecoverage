# Code Coverage configuration

This page is the reference for configuring Microsoft code coverage. It explains the
configuration files you can use, lists every supported setting (with values, defaults,
and the version each became available), and provides complete XML and JSON examples you
can copy from.

If you are not sure where to start, read [Which configuration file should I
use?](#which-configuration-file-should-i-use), then look up individual options in the
[Settings](#settings) and [Settings under CodeCoverage tag](#settings-under-codecoverage-tag)
tables.

## Contents

- [Code Coverage configuration files](#code-coverage-configuration-files)
  - [Runsettings](#runsettings)
  - [Coverage settings](#coverage-settings)
  - [testconfig.json](#testconfigjson)
  - [Which configuration file should I use?](#which-configuration-file-should-i-use)
- [Settings](#settings)
- [Settings under CodeCoverage tag](#settings-under-codecoverage-tag)
- [Example](#example)
  - [Runsettings file](#runsettings-file)
  - [Coverage config file](#coverage-config-file)
  - [Testconfig.json file](#testconfigjson-file)

## Code Coverage configuration files

This section describes the different configuration files used to control code coverage behavior.

### Runsettings

The `.runsettings` file is an XML file used to configure test runs and code coverage in Visual Studio and other .NET test runners. It allows you to specify data collectors, logging levels, output formats, and advanced code coverage options. For more information about the `.runsettings` file, see the [Visual Studio documentation](https://learn.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2022). See the [Runsettings file example](#runsettings-file) section below for a sample configuration.

### Coverage settings

Coverage settings can be specified in a dedicated coverage settings file, which is a subset of the `.runsettings` file containing only code coverage-related settings. This file can be provided in either XML or JSON format. The JSON format is supported starting from version 18.0. Coverage settings control aspects such as log levels, output paths, inclusion/exclusion rules, and instrumentation options. Refer to the [Settings](#settings) and [Settings under CodeCoverage tag](#settings-under-codecoverage-tag) tables for available options.

### testconfig.json

Code coverage configuration also supports the [Microsoft.Testing.Platform configuration settings file](https://learn.microsoft.com/en-us/dotnet/core/testing/microsoft-testing-platform-config), which provides a unified way to manage test and code coverage settings. Support for `testconfig.json` is available in version 18.0 and later. For more information, see the [Microsoft Testing Platform configuration documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/microsoft-testing-platform-config). See the [Testconfig.json file example](#testconfigjson-file) section below for a sample configuration.

### Which configuration file should I use?

Use this table to pick the right file for your scenario. All three accept the same code
coverage settings documented below; they differ in scope, format, and tooling support.

| File | Format | Best for | Available in version |
| --- | --- | --- | --- |
| `.runsettings` | XML | Configuring full test runs (test execution **and** code coverage) in Visual Studio, `dotnet test`, and `vstest.console.exe`. Use when you also need non-coverage run settings such as data collectors or test parallelization. | All supported versions |
| Coverage settings | XML or JSON | Configuring **only** code coverage, independent of a full `.runsettings` file. Use for a lightweight, coverage-focused file. JSON support starts in 18.0. | XML: all; JSON: 18.0 |
| `testconfig.json` | JSON | Projects built on [Microsoft.Testing.Platform](https://learn.microsoft.com/en-us/dotnet/core/testing/microsoft-testing-platform-config) that want a single unified config for test and coverage settings. | 18.0 |

The same option names, values, and defaults apply across all three files (see
[Settings](#settings) and [Settings under CodeCoverage tag](#settings-under-codecoverage-tag)).
For complete samples of each, jump to the [Example](#example) section.

## Settings

These settings appear directly under the `<Configuration>` element (or its JSON
equivalent). A dash (`—`) in the **Default** or **MTP.CodeCoverage Default** column means
the setting has no default and is unset unless you specify it. See the
[Example](#example) section for where these settings sit in a full file.

| Name | Values | Default | [MTP.CodeCoverage](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) Default | Description | Example (XML) | Example (JSON) | Available in version |
| --- | --- | --- | --- | --- | --- | --- | --- |
| **General / report output** | | | | | | | |
| CoverageFileName | File path | — | — | File path to output code coverage report | `<CoverageFileName>D:\examples\report.coverage</CoverageFileName>` | `"CoverageFileName": "D:\\examples\\report.coverage"` | 17.14 |
| Format | `coverage`, `cobertura`, `xml` | `coverage` | `coverage` | Output report format. | `<Format>coverage</Format>` | `"Format": "coverage"` | 17.14 |
| DeterministicReport | `True`, `False` | `False` | `False` | Requires `DeterministicSourcePaths` to be set to `True` during the build. When enabled, paths in the report will start with a deterministic fragment `/_/..` instead of full paths. More details can be found [here](https://github.com/dotnet/sourcelink/blob/main/docs/README.md#deterministicsourcepaths). | `<DeterministicReport>True</DeterministicReport>` | `"DeterministicReport": true` | 17.14 |
| **Exclude/include items in report** | | | | | | | |
| IncludeTestAssembly | `True`, `False` | `True` | `False` | Indicates if coverage should be collected for tests projects | `<IncludeTestAssembly>True</IncludeTestAssembly>` | `"IncludeTestAssembly": true` | 17.14 |
| ExcludeAssembliesWithoutSources | `NotSpecified`, `MissingAny`, `MissingAll`, `None` | `NotSpecified` | `MissingAll` | Excludes assemblies from the coverage report if their source files are missing. | `<ExcludeAssembliesWithoutSources>MissingAll</ExcludeAssembliesWithoutSources>` | `"ExcludeAssembliesWithoutSources": "MissingAll"` | 17.14 |
| DoesNotReturnAttribute | `SameAssembly`, `AllAssemblies`, `None` | `SameAssembly` | `SameAssembly` | Specifies the scope for matching functions with the DoesNotReturnAttribute to exclude from coverage. | `<DoesNotReturnAttribute>SameAssembly</DoesNotReturnAttribute>` | `"DoesNotReturnAttribute": "SameAssembly"` | 17.14 |
| **Logging** | | | | | | | |
| CoverageLogLevel | `Errors`,`Dumps`,`Messages`,`All` | — | — | Code coverage log level | `<CoverageLogLevel>Dumps</CoverageLogLevel>` | `"CoverageLogLevel": "Dumps"` | 17.14 |
| InstrumentationLogLevel | `Errors`,`Dumps`,`Messages`,`All` | — | — | CLR Instrumentation Engine log level. More info [here](https://github.com/microsoft/CLRInstrumentationEngine/blob/develop/docs/logging.md). | `<InstrumentationLogLevel>Dumps</InstrumentationLogLevel>` | `"InstrumentationLogLevel": "Dumps"` | 17.14 |
| ManagedVanguardLogLevel | `Error`,`Info`,`Verbose`,`None` | — | — | Managed instrumentation log level. Logging of managed side of code coverage. | `<ManagedVanguardLogLevel>Info</ManagedVanguardLogLevel>` | `"ManagedVanguardLogLevel": "Info"` | 17.14 |
| CoverageFileLogPath | File or directory path | — | — | File path or directory path to place where code coverage and CLR IE logs should be stored. Directory should be specified with `\` at the end. | `<CoverageFileLogPath>D:\examples\logs\coverage.log</CoverageFileLogPath>` | `"CoverageFileLogPath": "D:\\examples\\logs\\coverage.log"` | 17.14 |
| **Install directories** | | | | | | | |
| VanguardInstallDir | Directory path | — | — | Path to directory where custom `CodeCoverage.exe` and `covrun*.dll` files exists | `<VanguardInstallDir>D:\Microsoft.CodeCoverage\CodeCoverage</VanguardInstallDir>` | `"VanguardInstallDir": "D:\\Microsoft.CodeCoverage\\CodeCoverage"` | 17.14 |
| CLRIEX86InstallDir | Directory path | — | — | Path to directory with custom CLR IE x86 binary | `<CLRIEX86InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\x86</CLRIEX86InstallDir>` | `"CLRIEX86InstallDir": "D:\\Microsoft.CodeCoverage\\InstrumentationEngine\\x86"` | 17.14 |
| CLRIEX64InstallDir | Directory path | — | — | Path to directory with custom CLR IE x64 binary | `<CLRIEX64InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\x64</CLRIEX64InstallDir>` | `"CLRIEX64InstallDir": "D:\\Microsoft.CodeCoverage\\InstrumentationEngine\\x64"` | 17.14 |
| CLRIEARM64InstallDir | Directory path | — | — | Path to directory with custom CLR IE ARM64 binary | `<CLRIEARM64InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\arm64</CLRIEARM64InstallDir>` | `"CLRIEARM64InstallDir": "D:\\Microsoft.CodeCoverage\\InstrumentationEngine\\arm64"` | 17.14 |

## Settings under CodeCoverage tag

These settings appear inside the `<CodeCoverage>` element (nested under `<Configuration>`),
or the equivalent `CodeCoverage` object in JSON. As above, a dash (`—`) in a default column
means the setting has no default and is unset unless specified. See the
[Example](#example) section for a complete file showing where these settings belong.

| Name | Values | Default | [MTP.CodeCoverage](https://www.nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) Default | Description | Example (XML) | Example (JSON) | Available in version |
| --- | --- | --- | --- | --- | --- | --- | --- |
| **Exclude/include items in report** | | | | | | | |
| ExcludeCompilerAutoGeneratedModules | `True`, `False` | `False` | `False` | When set to True, excludes compiler auto-generated modules from the coverage report. | `<ExcludeCompilerAutoGeneratedModules>True</ExcludeCompilerAutoGeneratedModules>` | `"ExcludeCompilerAutoGeneratedModules": true` | — |
| SkipAutoProperties | `True`, `False` | `True` | `True` | Skips auto-implemented properties from code coverage results. | `<SkipAutoProperties>False</SkipAutoProperties>` | `"SkipAutoProperties": false` | 18.0 |
| ModulePaths | List of strings | — | — | Include and exclude lists for module paths.<br>Empty "Include" clauses imply all; empty "Exclude" clauses imply none. Each element in the list is a regular expression (ECMAScript syntax). See /visualstudio/ide/using-regular-expressions-in-visual-studio. An item must first match at least one entry in the include list to be included. Included items must then not match any entries in the exclude list to remain included. | `<ModulePaths><Exclude><ModulePath>.*CPPUnitTestFramework.*</ModulePath></Exclude></ModulePaths>` | `"ModulePaths": {"Exclude": [".*CPPUnitTestFramework.*"]}` | 17.14 |
| PublicKeyTokens | List | — | — | Include and exclude lists for public key tokens.<br>Matches the public key token of a signed assembly. | `<PublicKeyTokens><Exclude><PublicKeyToken>^B77A5C561934E089$</PublicKeyToken></Exclude></PublicKeyTokens>` | `"PublicKeyTokens": {"Exclude": ["^B77A5C561934E089$"]}` | 17.14 |
| CompanyNames | List of strings | — | — | Include and exclude lists for company names.<br>Matches the company name property in the assembly. | `<CompanyNames><Exclude><CompanyName>.*microsoft.*</CompanyName></Exclude></CompanyNames>` | `"CompanyNames": {"Exclude": [".*microsoft.*"]}` | 17.14 |
| Attributes | List of strings | — | — | Include and exclude lists for attributes.<br>Matches attributes on any code element. | `<Attributes><Exclude><Attribute>^System\.Diagnostics\.DebuggerHiddenAttribute$</Attribute></Exclude></Attributes>` | `"Attributes": {"Exclude": ["^System\\.Diagnostics\\.DebuggerHiddenAttribute$"]}` | 17.14 |
| Sources | List of strings | — | — | Include and exclude lists for source files.<br>Matches the path of the source files in which each method is defined. | `<Sources><Exclude><Source>.*\\atlmfc\\.*</Source></Exclude></Sources>` | `"Sources": {"Exclude": [".*\\\\atlmfc\\\\.*"]}` | 17.14 |
| Functions | List of strings | — | — | Include and exclude lists for functions.<br>Matches fully qualified names of functions. Use `\.` to delimit namespaces in C# or Visual Basic, `::` in C++.). | `<Functions><Exclude><Function>^Fabrikam\.UnitTest\..*</Function></Exclude></Functions>` | `"Functions": {"Exclude": ["^Fabrikam\\.UnitTest\\..*"]}` | 17.14 |
| **Symbols** | | | | | | | |
| SymbolsRestrictOriginalPathAccess | `True`, `False` | `False` | `False` | Determines if looking for a .pdb file in the original debug directory. | `<SymbolsRestrictOriginalPathAccess>True</SymbolsRestrictOriginalPathAccess>` | `"SymbolsRestrictOriginalPathAccess": true` | 17.14 |
| SymbolsRestrictReferencePathAccess | `True`, `False` | `False` | `False` | Determines if looking for a .pdb file is allowed in the path where the .exe file is located. | `<SymbolsRestrictReferencePathAccess>True</SymbolsRestrictReferencePathAccess>` | `"SymbolsRestrictReferencePathAccess": true` | 17.14 |
| SymbolsRestrictDBGAccess | `True`, `False` | `False` | `False` | Determines if looking for debug information is allowed from .dbg files. | `<SymbolsRestrictDBGAccess>True</SymbolsRestrictDBGAccess>` | `"SymbolsRestrictDBGAccess": true` | 17.14 |
| SymbolsRestrictSystemRootAccess | `True`, `False` | `False` | `False` | Determines if searching for .pdb files is allowed in the system root directory. | `<SymbolsRestrictSystemRootAccess>True</SymbolsRestrictSystemRootAccess>` | `"SymbolsRestrictSystemRootAccess": true` | 17.14 |
| SymbolSearchPaths | List of strings | — | — | Additional paths to search for .pdb (symbol) files. Symbols must be found for modules to be instrumented. If .pdb files are in the same folder as the .dll or .exe files, they are automatically found. Otherwise, specify them here. Note that searching for symbols increases code coverage runtime. So keep this small and local. | `<SymbolSearchPaths><Path>C:\Users\User\Documents\Visual Studio 2012\Projects\ProjectX\bin\Debug</Path></SymbolSearchPaths>` | `"SymbolSearchPaths": ["C:\\Users\\User\\Documents\\Visual Studio 2012\\Projects\\ProjectX\\bin\\Debug"]` | 17.14 |
| **Access control** | | | | | | | |
| AllowedUsers | List of strings | — | — | Supported only for .NET Framework. Additional users that will be able to access internal shared memory and pipes. | `<AllowedUsers><User>UserName1</User></AllowedUsers>` | `"AllowedUsers": ["UserName1"]` | 17.14 |
| **Logging** | | | | | | | |
| FileLogPath | `C:\folder\` or `C:\folder\log.txt` | — | — | Set the path for the static native instrumentation. | `<FileLogPath>C:\folder\log.txt</FileLogPath>` | `"FileLogPath": "C:\\folder\\log.txt"` | 17.14 |
| LogLevel | `Errors`,`Dumps`,`Messages`,`All` | — | — | Set the log level for the static native instrumentation. | `<LogLevel>All</LogLevel>` | `"LogLevel": "All"` | 17.14 |
| **Instrumentation** | | | | | | | |
| UseVerifiableInstrumentation | `True`, `False` | `True` | `False` | Set this to True to collect coverage information for functions marked with the "SecuritySafeCritical" attribute. Instead of writing directly into a memory location from such functions, code coverage inserts a probe that redirects to another function, which in turns writes into memory. | `<UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>` | `"UseVerifiableInstrumentation": true` | 17.14 |
| EnableDynamicManagedInstrumentation | `True`, `False` | `True` | `True` | Enable dynamic managed instrumentation. | `<EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>` | `"EnableDynamicManagedInstrumentation": true` | 17.14 |
| EnableStaticManagedInstrumentation | `True`, `False` | `False` | `False` | Enable static managed instrumentation. | `<EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>` | `"EnableStaticManagedInstrumentation": true` | 17.14 |
| EnableStaticManagedInstrumentationRestore | `True`, `False` | `True` | `True` | Enable static managed instrumentation restore. If enabled all instrumented files are restored after collection. | `<EnableStaticManagedInstrumentationRestore>True</EnableStaticManagedInstrumentationRestore>` | `"EnableStaticManagedInstrumentationRestore": true` | 17.14 |
| EnableStaticManagedInstrumentationSafeInitialization | `True`, `False` | `False` | `False` | Enables safe initialization for static managed instrumentation. | `<EnableStaticManagedInstrumentationSafeInitialization>True</EnableStaticManagedInstrumentationSafeInitialization>` | `"EnableStaticManagedInstrumentationSafeInitialization": true` | — |
| EnableDynamicNativeInstrumentation | `True`, `False` | `True` | `False` (Disabled) | Enable dynamic native instrumentation. | `<EnableDynamicNativeInstrumentation>True</EnableDynamicNativeInstrumentation>` | `"EnableDynamicNativeInstrumentation": true` | 17.14 |
| EnableStaticNativeInstrumentation | `True`, `False` | `True` | `False` | Enable static native instrumentation. | `<EnableStaticNativeInstrumentation>True</EnableStaticNativeInstrumentation>` | `"EnableStaticNativeInstrumentation": true` | 17.14 |
| EnableStaticNativeInstrumentationRestore | `True`, `False` | `True` | `True` | Enable static native instrumentation restore. If enabled all instrumented files are restored after collection. | `<EnableStaticNativeInstrumentationRestore>True</EnableStaticNativeInstrumentationRestore>` | `"EnableStaticNativeInstrumentationRestore": true` | 17.14 |
| **Communication and process collection** | | | | | | | |
| CommunicationTimeout | Integer | 60000 | 60000 | Specifies communication time out in milliseconds | `<CommunicationTimeout>90000</CommunicationTimeout>` | `"CommunicationTimeout": 90000` | 17.14 |
| PipeClientsCount | Integer | 254 | 254 | Specifies number of pipe connections started by coverage server. | `<PipeClientsCount>2540</PipeClientsCount>` | `"PipeClientsCount": 2540` | 17.14 |
| CollectFromChildProcesses | `True`, `False` | `True` | `True` | When set to True, collects coverage information from child processes that are launched by test or production code. | `<CollectFromChildProcesses>True</CollectFromChildProcesses>` | `"CollectFromChildProcesses": true` | 17.14 |
| CollectAspDotNet | `True`, `False` | `False` | `False` | When set to True, enables code coverage collection for ASP.NET processes. | `<CollectAspDotNet>True</CollectAspDotNet>` | `"CollectAspDotNet": true` | — |
| AllowLowIntegrityProcesses | `True`, `False` | `False` | `False` | When set to True, collects coverage information from child processes that are launched with low-level ACLs, for example, UWP apps. | `<AllowLowIntegrityProcesses>True</AllowLowIntegrityProcesses>` | `"AllowLowIntegrityProcesses": true` | 17.14 |

## Example

The following complete samples show the same settings expressed in each supported file
format. Pick the one that matches your chosen file (see [Which configuration file should I
use?](#which-configuration-file-should-i-use)):

- [Runsettings file](#runsettings-file) — full `.runsettings` (XML)
- [Coverage config file](#coverage-config-file) — coverage-only settings (XML and JSON)
- [Testconfig.json file](#testconfigjson-file) — Microsoft.Testing.Platform config (JSON)

### Runsettings file

<details>
<summary>Show full <code>.runsettings</code> example</summary>

```xml
<?xml version="1.0" encoding="utf-8"?>
<!-- File name extension must be .runsettings -->
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="Code Coverage" uri="datacollector://Microsoft/CodeCoverage/2.0"
        assemblyQualifiedName="Microsoft.VisualStudio.Coverage.DynamicCoverageDataCollector, Microsoft.VisualStudio.TraceCollector, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
        <Configuration>
          <CoverageLogLevel>Dumps</CoverageLogLevel>
          <InstrumentationLogLevel>Dumps</InstrumentationLogLevel>
          <ManagedVanguardLogLevel>Info</ManagedVanguardLogLevel>
          <CoverageFileLogPath>D:\examples\logs\coverage.log</CoverageFileLogPath>
          <CoverageFileName>D:\examples\report.coverage</CoverageFileName>
          <Format>coverage</Format>
          <CLRIEX86InstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\InstrumentationEngine\x86</CLRIEX86InstallDir>
          <CLRIEX64InstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\InstrumentationEngine\x64</CLRIEX64InstallDir>
          <VanguardInstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\CodeCoverage</VanguardInstallDir>
          <IncludeTestAssembly>True</IncludeTestAssembly>

          <CodeCoverage>
            <CommunicationTimeout>90000</CommunicationTimeout>
            <PipeClientsCount>2540</PipeClientsCount>
            <CollectFromChildProcesses>True</CollectFromChildProcesses>
            <UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>
            <AllowLowIntegrityProcesses>True</AllowLowIntegrityProcesses>
            <SymbolsRestrictOriginalPathAccess>True</SymbolsRestrictOriginalPathAccess>
            <SymbolsRestrictReferencePathAccess>True</SymbolsRestrictReferencePathAccess>
            <SymbolsRestrictDBGAccess>True</SymbolsRestrictDBGAccess>
            <SymbolsRestrictSystemRootAccess>True</SymbolsRestrictSystemRootAccess>
            <EnableDynamicNativeInstrumentation>True</EnableDynamicNativeInstrumentation>
            <EnableStaticNativeInstrumentation>True</EnableStaticNativeInstrumentation>
            <EnableStaticNativeInstrumentationRestore>True</EnableStaticNativeInstrumentationRestore>
            <EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>
            <EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>
            <EnableStaticManagedInstrumentationRestore>True</EnableStaticManagedInstrumentationRestore>
            <SymbolSearchPaths>
              <Path>C:\Users\User\Documents\Visual Studio 2012\Projects\ProjectX\bin\Debug</Path>
              <Path>\\mybuildshare\builds\ProjectX</Path>
            </SymbolSearchPaths>
            <AllowedUsers>
              <User>UserName1</User>
              <User>UserName2</User>
            </AllowedUsers>
            <ModulePaths>
              <Include>
                <ModulePath>.*\.dll$</ModulePath>
                <ModulePath>.*\.exe$</ModulePath>
              </Include>
              <Exclude>
                <ModulePath>.*CPPUnitTestFramework.*</ModulePath>
              </Exclude>
            </ModulePaths>
            <Functions>
              <Exclude>
                <Function>^Fabrikam\.UnitTest\..*</Function>
                <Function>^std::.*</Function>
                <Function>^ATL::.*</Function>
                <Function>.*::__GetTestMethodInfo.*</Function>
                <Function>^Microsoft::VisualStudio::CppCodeCoverageFramework::.*</Function>
                <Function>^Microsoft::VisualStudio::CppUnitTestFramework::.*</Function>
              </Exclude>
            </Functions>
            <Attributes>
              <Exclude>
                <Attribute>^System\.Diagnostics\.DebuggerHiddenAttribute$</Attribute>
                <Attribute>^System\.Diagnostics\.DebuggerNonUserCodeAttribute$</Attribute>
                <Attribute>^System\.CodeDom\.Compiler\.GeneratedCodeAttribute$</Attribute>
                <Attribute>^System\.Diagnostics\.CodeAnalysis\.ExcludeFromCodeCoverageAttribute$</Attribute>
              </Exclude>
            </Attributes>
            <Sources>
              <Exclude>
                <Source>.*\\atlmfc\\.*</Source>
                <Source>.*\\vctools\\.*</Source>
                <Source>.*\\public\\sdk\\.*</Source>
                <Source>.*\\microsoft sdks\\.*</Source>
                <Source>.*\\vc\\include\\.*</Source>
              </Exclude>
            </Sources>
            <CompanyNames>
              <Exclude>
                <CompanyName>.*microsoft.*</CompanyName>
              </Exclude>
            </CompanyNames>
            <PublicKeyTokens>
              <Exclude>
                <PublicKeyToken>^B77A5C561934E089$</PublicKeyToken>
                <PublicKeyToken>^B03F5F7F11D50A3A$</PublicKeyToken>
                <PublicKeyToken>^31BF3856AD364E35$</PublicKeyToken>
                <PublicKeyToken>^89845DCD8080CC91$</PublicKeyToken>
                <PublicKeyToken>^71E9BCE111E9429C$</PublicKeyToken>
                <PublicKeyToken>^8F50407C4E9E73B6$</PublicKeyToken>
                <PublicKeyToken>^E361AF139669C375$</PublicKeyToken>
              </Exclude>
            </PublicKeyTokens>
            <FileLogPath>C:\logs\</FileLogPath>
            <LogLevel>All</LogLevel>
          </CodeCoverage>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
```

</details>

To enable all available logs

<details>
<summary>Show example that enables all available logs</summary>

```xml
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="Code Coverage" uri="datacollector://Microsoft/CodeCoverage/2.0"
        assemblyQualifiedName="Microsoft.VisualStudio.Coverage.DynamicCoverageDataCollector, Microsoft.VisualStudio.TraceCollector">
        <Configuration>
          <CoverageLogLevel>Dumps</CoverageLogLevel>
          <InstrumentationLogLevel>Dumps</InstrumentationLogLevel>
          <ManagedVanguardLogLevel>Verbose</ManagedVanguardLogLevel>
          <CoverageFileLogPath>C:\LogFolder\</CoverageFileLogPath>
          <CodeCoverage>
            <FileLogPath>C:\LogFolder\</FileLogPath>
            <LogLevel>All</LogLevel>
          </CodeCoverage>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
```

</details>

### Coverage config file

<details>
<summary>Show coverage config file example (XML)</summary>

```xml
<?xml version="1.0" encoding="utf-8"?>
<Configuration>
  <CoverageLogLevel>Dumps</CoverageLogLevel>
  <InstrumentationLogLevel>Dumps</InstrumentationLogLevel>
  <ManagedVanguardLogLevel>Info</ManagedVanguardLogLevel>
  <CoverageFileLogPath>D:\examples\logs\coverage.log</CoverageFileLogPath>
  <CoverageFileName>D:\examples\report.coverage</CoverageFileName>
  <Format>coverage</Format>
  <CLRIEX86InstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\InstrumentationEngine\x86</CLRIEX86InstallDir>
  <CLRIEX64InstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\InstrumentationEngine\x64</CLRIEX64InstallDir>
  <VanguardInstallDir>D:\vscodecoverage\artifacts\test\Microsoft.CodeCoverage\CodeCoverage</VanguardInstallDir>
  <IncludeTestAssembly>True</IncludeTestAssembly>

  <CodeCoverage>
    <CommunicationTimeout>90000</CommunicationTimeout>
    <PipeClientsCount>2540</PipeClientsCount>
    <CollectFromChildProcesses>True</CollectFromChildProcesses>
    <UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>
    <AllowLowIntegrityProcesses>True</AllowLowIntegrityProcesses>
    <SymbolsRestrictOriginalPathAccess>True</SymbolsRestrictOriginalPathAccess>
    <SymbolsRestrictReferencePathAccess>True</SymbolsRestrictReferencePathAccess>
    <SymbolsRestrictDBGAccess>True</SymbolsRestrictDBGAccess>
    <SymbolsRestrictSystemRootAccess>True</SymbolsRestrictSystemRootAccess>
    <EnableDynamicNativeInstrumentation>True</EnableDynamicNativeInstrumentation>
    <EnableStaticNativeInstrumentation>True</EnableStaticNativeInstrumentation>
    <EnableStaticNativeInstrumentationRestore>True</EnableStaticNativeInstrumentationRestore>
    <EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>
    <EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>
    <EnableStaticManagedInstrumentationRestore>True</EnableStaticManagedInstrumentationRestore>
    <SymbolSearchPaths>
      <Path>C:\Users\User\Documents\Visual Studio 2012\Projects\ProjectX\bin\Debug</Path>
      <Path>\\mybuildshare\builds\ProjectX</Path>
    </SymbolSearchPaths>
    <AllowedUsers>
      <User>UserName1</User>
      <User>UserName2</User>
    </AllowedUsers>
    <ModulePaths>
      <Include>
        <ModulePath>.*\.dll$</ModulePath>
        <ModulePath>.*\.exe$</ModulePath>
      </Include>
      <Exclude>
        <ModulePath>.*CPPUnitTestFramework.*</ModulePath>
      </Exclude>
    </ModulePaths>
    <Functions>
      <Exclude>
        <Function>^Fabrikam\.UnitTest\..*</Function>
        <Function>^std::.*</Function>
        <Function>^ATL::.*</Function>
        <Function>.*::__GetTestMethodInfo.*</Function>
        <Function>^Microsoft::VisualStudio::CppCodeCoverageFramework::.*</Function>
        <Function>^Microsoft::VisualStudio::CppUnitTestFramework::.*</Function>
      </Exclude>
    </Functions>
    <Attributes>
      <Exclude>
        <Attribute>^System\.Diagnostics\.DebuggerHiddenAttribute$</Attribute>
        <Attribute>^System\.Diagnostics\.DebuggerNonUserCodeAttribute$</Attribute>
        <Attribute>^System\.CodeDom\.Compiler\.GeneratedCodeAttribute$</Attribute>
        <Attribute>^System\.Diagnostics\.CodeAnalysis\.ExcludeFromCodeCoverageAttribute$</Attribute>
      </Exclude>
    </Attributes>
    <Sources>
      <Exclude>
        <Source>.*\\atlmfc\\.*</Source>
        <Source>.*\\vctools\\.*</Source>
        <Source>.*\\public\\sdk\\.*</Source>
        <Source>.*\\microsoft sdks\\.*</Source>
        <Source>.*\\vc\\include\\.*</Source>
      </Exclude>
    </Sources>
    <CompanyNames>
      <Exclude>
        <CompanyName>.*microsoft.*</CompanyName>
      </Exclude>
    </CompanyNames>
    <PublicKeyTokens>
      <Exclude>
        <PublicKeyToken>^B77A5C561934E089$</PublicKeyToken>
        <PublicKeyToken>^B03F5F7F11D50A3A$</PublicKeyToken>
        <PublicKeyToken>^31BF3856AD364E35$</PublicKeyToken>
        <PublicKeyToken>^89845DCD8080CC91$</PublicKeyToken>
        <PublicKeyToken>^71E9BCE111E9429C$</PublicKeyToken>
        <PublicKeyToken>^8F50407C4E9E73B6$</PublicKeyToken>
        <PublicKeyToken>^E361AF139669C375$</PublicKeyToken>
      </Exclude>
    </PublicKeyTokens>
    <FileLogPath>C:\logs\</FileLogPath>
    <LogLevel>All</LogLevel>
  </CodeCoverage>
</Configuration>
```

</details>

<details>
<summary>Show coverage config file example (JSON)</summary>

```json
{
  "Configuration": {
    "CoverageLogLevel": "Dumps",
    "InstrumentationLogLevel": "Dumps",
    "ManagedVanguardLogLevel": "Info",
    "CoverageFileLogPath": "D:\\examples\\logs\\coverage.log",
    "CoverageFileName": "D:\\examples\\report.coverage",
    "Format": "coverage",
    "CLRIEX86InstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\InstrumentationEngine\\x86",
    "CLRIEX64InstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\InstrumentationEngine\\x64",
    "VanguardInstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\CodeCoverage",
    "IncludeTestAssembly": true,
    "CodeCoverage": {
      "CommunicationTimeout": 90000,
      "PipeClientsCount": 2540,
      "CollectFromChildProcesses": true,
      "UseVerifiableInstrumentation": true,
      "AllowLowIntegrityProcesses": true,
      "SymbolsRestrictOriginalPathAccess": true,
      "SymbolsRestrictReferencePathAccess": true,
      "SymbolsRestrictDBGAccess": true,
      "SymbolsRestrictSystemRootAccess": true,
      "EnableDynamicNativeInstrumentation": true,
      "EnableStaticNativeInstrumentation": true,
      "EnableStaticNativeInstrumentationRestore": true,
      "EnableDynamicManagedInstrumentation": true,
      "EnableStaticManagedInstrumentation": true,
      "EnableStaticManagedInstrumentationRestore": true,
      "SymbolSearchPaths": [
        "C:\\Users\\User\\Documents\\Visual Studio 2012\\Projects\\ProjectX\\bin\\Debug",
        "\\\\mybuildshare\\builds\\ProjectX"
      ],
      "AllowedUsers": [
        "UserName1",
        "UserName2"
      ],
      "ModulePaths": {
        "Include": [
          ".*\\.dll$",
          ".*\\.exe$"
        ],
        "Exclude": [
          ".*CPPUnitTestFramework.*"
        ]
      },
      "Functions": {
        "Exclude": [
          "^Fabrikam\\.UnitTest\\..*",
          "^std::.*",
          "^ATL::.*",
          ".*::__GetTestMethodInfo.*",
          "^Microsoft::VisualStudio::CppCodeCoverageFramework::.*",
          "^Microsoft::VisualStudio::CppUnitTestFramework::.*"
        ]
      },
      "Attributes": {
        "Exclude": [
          "^System\\.Diagnostics\\.DebuggerHiddenAttribute$",
          "^System\\.Diagnostics\\.DebuggerNonUserCodeAttribute$",
          "^System\\.CodeDom\\.Compiler\\.GeneratedCodeAttribute$",
          "^System\\.Diagnostics\\.CodeAnalysis\\.ExcludeFromCodeCoverageAttribute$"
        ]
      },
      "Sources": {
        "Exclude": [
          ".*\\\\atlmfc\\\\.*",
          ".*\\\\vctools\\\\.*",
          ".*\\\\public\\\\sdk\\\\.*",
          ".*\\\\microsoft sdks\\\\.*",
          ".*\\\\vc\\\\include\\\\.*"
        ]
      },
      "CompanyNames": {
        "Exclude": [
          ".*microsoft.*"
        ]
      },
      "PublicKeyTokens": {
        "Exclude": [
          "^B77A5C561934E089$",
          "^B03F5F7F11D50A3A$",
          "^31BF3856AD364E35$",
          "^89845DCD8080CC91$",
          "^71E9BCE111E9429C$",
          "^8F50407C4E9E73B6$",
          "^E361AF139669C375$"
        ]
      },
      "FileLogPath": "C:\\logs\\",
      "LogLevel": "All"
    }
  }
}
```

</details>

### Testconfig.json file

<details>
<summary>Show testconfig.json example</summary>

```json
{
  "codeCoverage": {
    "Configuration": {
      "CoverageLogLevel": "Dumps",
      "InstrumentationLogLevel": "Dumps",
      "ManagedVanguardLogLevel": "Info",
      "CoverageFileLogPath": "D:\\examples\\logs\\coverage.log",
      "CoverageFileName": "D:\\examples\\report.coverage",
      "Format": "coverage",
      "CLRIEX86InstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\InstrumentationEngine\\x86",
      "CLRIEX64InstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\InstrumentationEngine\\x64",
      "VanguardInstallDir": "D:\\vscodecoverage\\artifacts\\test\\Microsoft.CodeCoverage\\CodeCoverage",
      "IncludeTestAssembly": true,
      "CodeCoverage": {
        "CommunicationTimeout": 90000,
        "PipeClientsCount": 2540,
        "CollectFromChildProcesses": true,
        "UseVerifiableInstrumentation": true,
        "AllowLowIntegrityProcesses": true,
        "SymbolsRestrictOriginalPathAccess": true,
        "SymbolsRestrictReferencePathAccess": true,
        "SymbolsRestrictDBGAccess": true,
        "SymbolsRestrictSystemRootAccess": true,
        "EnableDynamicNativeInstrumentation": true,
        "EnableStaticNativeInstrumentation": true,
        "EnableStaticNativeInstrumentationRestore": true,
        "EnableDynamicManagedInstrumentation": true,
        "EnableStaticManagedInstrumentation": true,
        "EnableStaticManagedInstrumentationRestore": true,
        "SymbolSearchPaths": [
          "C:\\Users\\User\\Documents\\Visual Studio 2012\\Projects\\ProjectX\\bin\\Debug",
          "\\\\mybuildshare\\builds\\ProjectX"
        ],
        "AllowedUsers": [
          "UserName1",
          "UserName2"
        ],
        "ModulePaths": {
          "Include": [
            ".*\\.dll$",
            ".*\\.exe$"
          ],
          "Exclude": [
            ".*CPPUnitTestFramework.*"
          ]
        },
        "Functions": {
          "Exclude": [
            "^Fabrikam\\.UnitTest\\..*",
            "^std::.*",
            "^ATL::.*",
            ".*::__GetTestMethodInfo.*",
            "^Microsoft::VisualStudio::CppCodeCoverageFramework::.*",
            "^Microsoft::VisualStudio::CppUnitTestFramework::.*"
          ]
        },
        "Attributes": {
          "Exclude": [
            "^System\\.Diagnostics\\.DebuggerHiddenAttribute$",
            "^System\\.Diagnostics\\.DebuggerNonUserCodeAttribute$",
            "^System\\.CodeDom\\.Compiler\\.GeneratedCodeAttribute$",
            "^System\\.Diagnostics\\.CodeAnalysis\\.ExcludeFromCodeCoverageAttribute$"
          ]
        },
        "Sources": {
          "Exclude": [
            ".*\\\\atlmfc\\\\.*",
            ".*\\\\vctools\\\\.*",
            ".*\\\\public\\\\sdk\\\\.*",
            ".*\\\\microsoft sdks\\\\.*",
            ".*\\\\vc\\\\include\\\\.*"
          ]
        },
        "CompanyNames": {
          "Exclude": [
            ".*microsoft.*"
          ]
        },
        "PublicKeyTokens": {
          "Exclude": [
            "^B77A5C561934E089$",
            "^B03F5F7F11D50A3A$",
            "^31BF3856AD364E35$",
            "^89845DCD8080CC91$",
            "^71E9BCE111E9429C$",
            "^8F50407C4E9E73B6$",
            "^E361AF139669C375$"
          ]
        },
        "FileLogPath": "C:\\logs\\",
        "LogLevel": "All"
      }
    }
  }
}
```

</details>
