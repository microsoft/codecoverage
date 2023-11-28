# Code Coverage configuration

- [Code Coverage configuration](#code-coverage-configuration)
  - [Settings](#settings)
  - [Settings under CodeCoverage tag](#settings-under-codecoverage-tag)
  - [Example](#example)

## Settings

| Name | Values | Default | Description | Example |
|---|---|---|---|---|
| CoverageLogLevel | `Errors`,`Dumps`,`Messages`,`All` |  | Code coverage log level  | `<CoverageLogLevel>Dumps</CoverageLogLevel>` |
| InstrumentationLogLevel  | `Errors`,`Dumps`,`Messages`,`All` |  | CLR Instrumentation Engine log level. More info <a href="https://github.com/microsoft/CLRInstrumentationEngine/blob/develop/docs/logging.md">here</a>. | `<InstrumentationLogLevel>Dumps</InstrumentationLogLevel>` |
| ManagedVanguardLogLevel  | `Error`,`Info`,`Verbose`,`None` |  | Managed instrumentation log level. Logging of managed side of code coverage. | `<ManagedVanguardLogLevel>Info</ManagedVanguardLogLevel>` |
| CoverageFileLogPath  | File or directory path | | File path or directory path to place where code coverage and CLR IE logs should be stored. Directory should be specified with `\` at the end. | `<CoverageFileLogPath>D:\examples\logs\coverage.log</CoverageFileLogPath>` |
| CoverageFileName | File path | | File path to output code coverage report | `<CoverageFileName>D:\examples\report.coverage</CoverageFileName>` |
| Format | `coverage`, `cobertura`, `xml` | `coverage` | Output report format. | `<Format>coverage</Format>` |
| VanguardInstallDir | Directory path | | Path to directory where custom `CodeCoverage.exe` and `covrun*.dll` files exists | `<VanguardInstallDir>D:\Microsoft.CodeCoverage\CodeCoverage</VanguardInstallDir>` |
| CLRIEX86InstallDir | Directory path | | Path to directory with custom CLR IE x86 binary | `<CLRIEX86InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\x86</CLRIEX86InstallDir>` |
| CLRIEX64InstallDir | Directory path | | Path to directory with custom CLR IE x64 binary | `<CLRIEX64InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\x64</CLRIEX64InstallDir>` |
| CLRIEARM64InstallDir | Directory path | | Path to directory with custom CLR IE ARM64 binary | `<CLRIEARM64InstallDir>D:\Microsoft.CodeCoverage\InstrumentationEngine\arm64</CLRIEARM64InstallDir>` |
| PerTestCodeCoverage | `True`, `False` | `False` | Indicates if coverage should be collected for each test separately | `<PerTestCodeCoverage>True</PerTestCodeCoverage>` |
| IncludeTestAssembly | `True`, `False` | `True` | Indicates if coverage should be collected for tests projects | `<IncludeTestAssembly>True</IncludeTestAssembly>` |

## Settings under CodeCoverage tag

| Name | Values | Default  | Description  | Example |
|---|---|---|---|---|
| CommunicationTimeout | Integer | 60000 | Specifies comminication time out in milliseconds | `<CommunicationTimeout>90000</CommunicationTimeout>` |
| PipeClientsCount | Integer | 254 | Specifies number of pipe connections started by coverage server. | `<PipeClientsCount>2540</PipeClientsCount>` |
| CollectFromChildProcesses | `True`, `False` | `True` | When set to True, collects coverage information from child processes that are launched by test or production code. | `<CollectFromChildProcesses>True</CollectFromChildProcesses>` |
| UseVerifiableInstrumentation | `True`, `False` | `True` | Set this to True to collect coverage information for functions marked with the "SecuritySafeCritical" attribute. Instead of writing directly into a memory location from such functions, code coverage inserts a probe that redirects to another function, which in turns writes into memory. | `<UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>` |
| AllowLowIntegrityProcesses | `True`, `False` | `False` | When set to True, collects coverage information from child processes that are launched with low-level ACLs, for example, UWP apps. | `<AllowLowIntegrityProcesses>True</AllowLowIntegrityProcesses>` |
| SymbolsRestrictOriginalPathAccess | `True`, `False` | `False` | Determines if looking for a .pdb file in the original debug directory. | `<SymbolsRestrictOriginalPathAccess>True</SymbolsRestrictOriginalPathAccess>` |
| SymbolsRestrictReferencePathAccess | `True`, `False` | `False` | Determines if looking for a .pdb file is allowed in the path where the .exe file is located. | `<SymbolsRestrictReferencePathAccess>True</SymbolsRestrictReferencePathAccess>` |
| SymbolsRestrictDBGAccess | `True`, `False` | `False` | Determines if looking for debug information is allowed from .dbg files. | `<SymbolsRestrictDBGAccess>True</SymbolsRestrictDBGAccess>` |
| SymbolsRestrictSystemRootAccess | `True`, `False` | `False` | Determines if searching for .pdb files is allowed in the system root directory. | `<SymbolsRestrictSystemRootAccess>True</SymbolsRestrictSystemRootAccess>` |
| EnableDynamicNativeInstrumentation | `True`, `False` | `True` | Enable dynamic native instrumentation. | `<EnableDynamicNativeInstrumentation>True</EnableDynamicNativeInstrumentation>` |
| EnableStaticNativeInstrumentation | `True`, `False` | `True` | Enable static native instrumentation. | `<EnableStaticNativeInstrumentation>True</EnableStaticNativeInstrumentation>` |
| EnableStaticNativeInstrumentationRestore | `True`, `False` | `True` | Enable static native instrumentation restore. If enabled all instrumented files are restored after collection. | `<EnableStaticNativeInstrumentationRestore>True</EnableStaticNativeInstrumentationRestore>` |
| EnableDynamicManagedInstrumentation | `True`, `False` | `True` | Enable dynamic managed instrumentation. | `<EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>` |
| EnableStaticManagedInstrumentation | `True`, `False` | `False` | Enable static managed instrumentation. | `<EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>` |
| EnableStaticManagedInstrumentationRestore | `True`, `False` | `True` | Enable static managed instrumentation restore. If enabled all instrumented files are restored after collection. | `<EnableStaticManagedInstrumentationRestore>True</EnableStaticManagedInstrumentationRestore>` |
| SymbolSearchPaths | XML | | Additional paths to search for .pdb (symbol) files. Symbols must be found for modules to be instrumented. If .pdb files are in the same folder as the .dll or .exe files, they are automatically found. Otherwise, specify them here. Note that searching for symbols increases code coverage runtime. So keep this small and local. | `<SymbolSearchPaths><Path>C:\Users\User\Documents\Visual Studio 2012\Projects\ProjectX\bin\Debug</Path></SymbolSearchPaths>` |
| AllowedUsers | XML | | Supported only for .NET Framework. Additional users that will be able to access internal shared memory and pipes. | `<AllowedUsers><User>UserName1</User></AllowedUsers>` |
| ModulePaths | XML | | Include and exclude lists for module paths. <br> Empty "Include" clauses imply all; empty "Exclude" clauses imply none. Each element in the list is a regular expression (ECMAScript syntax). See /visualstudio/ide/using-regular-expressions-in-visual-studio. An item must first match at least one entry in the include list to be included. Included items must then not match any entries in the exclude list to remain included. |  `<ModulePaths><Exclude><ModulePath>.*CPPUnitTestFramework.*</ModulePath></Exclude></ModulePaths>` |
| PublicKeyTokens | XML | | Include and exclude lists for public key tokens.<br>Matches the public key token of a signed assembly. | `<PublicKeyTokens><Exclude><PublicKeyToken>^B77A5C561934E089$</PublicKeyToken></Exclude></PublicKeyTokens>` |
| CompanyNames | XML | | Include and exclude lists for company names.<br>Matches the company name property in the assembly. | `<CompanyNames><Exclude><CompanyName>.*microsoft.*</CompanyName></Exclude></CompanyNames>` |
| Attributes | XML | | Include and exclude lists for attributes.<br>Matches attributes on any code element. | `<Attributes><Exclude><Attribute>^System\.Diagnostics\.DebuggerHiddenAttribute$</Attribute></Exclude></Attributes>` |
| Sources | XML | | Include and exclude lists for source files.<br>Matches the path of the source files in which each method is defined. | `<Sources><Exclude><Source>.*\\atlmfc\\.*</Source></Exclude></Sources>` |
| Functions | XML | | Include and exclude lists for functions.<br>Matches fully qualified names of functions. Use `\.` to delimit namespaces in C# or Visual Basic, `::` in C++.). | `<Functions><Exclude><Function>^Fabrikam\.UnitTest\..*</Function></Exclude></Functions>` |
| DumpStaticNativeDisassembly | `True`, `False` | `False` | Generates the assembler dump of the native static instrumentation close to the module. | `<DumpStaticNativeDisassembly>True</DumpStaticNativeDisassembly>` |
| FileLogPath | `C:\folder\` or `C:\folder\log.txt` | | Set the path for the static native instrumentation. | `<FileLogPath>C:\folder\log.txt</FileLogPath>` |
| LogLevel | `Errors`,`Dumps`,`Messages`,`All` | | Set the log level for the static native instrumentation. | `<LogLevel>All</LogLevel>` |
## Example

```
<?xml version="1.0" encoding="utf-8"?>
<!-- File name extension must be .runsettings -->
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="Code Coverage" uri="datacollector://Microsoft/CodeCoverage/2.0" assemblyQualifiedName="Microsoft.VisualStudio.Coverage.DynamicCoverageDataCollector, Microsoft.VisualStudio.TraceCollector, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
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
          <PerTestCodeCoverage>True</PerTestCodeCoverage>
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
            <DumpStaticNativeDisassembly>False</DumpStaticNativeDisassembly>
            <FileLogPath>C:\logs\</FileLogPath>
            <LogLevel>All</LogLevel>
          </CodeCoverage>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
```
To enable all available logs
```
 <RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="Code Coverage" uri="datacollector://Microsoft/CodeCoverage/2.0" assemblyQualifiedName="Microsoft.VisualStudio.Coverage.DynamicCoverageDataCollector, Microsoft.VisualStudio.TraceCollector">
        <Configuration>
          <CoverageLogLevel>Dumps</CoverageLogLevel>
          <InstrumentationLogLevel>Dumps</InstrumentationLogLevel>
          <ManagedVanguardLogLevel>Verbose</ManagedVanguardLogLevel>
          <CoverageFileLogPath>C:\LogFolder\</CoverageFileLogPath>
          <PerTestCodeCoverage>False</PerTestCodeCoverage>
          <CodeCoverage>
            <FileLogPath>C:\LogFolder\</FileLogPath>
            <LogLevel>All</LogLevel>
            <DumpStaticNativeDisassembly>true</DumpStaticNativeDisassembly>
          </CodeCoverage>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
```
