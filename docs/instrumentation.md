# Static and dynamic instrumentation

For years our Microsoft's code coverage tooling was working only on Windows leveraging dynamic instrumentation through CLR profiling ([Profiling Overview - .NET Framework | Microsoft Learn](https://learn.microsoft.com/dotnet/framework/unmanaged-api/profiling/profiling-overview)). Dynamic instrumentation means that libraries are instrumented in memory after library image is loaded by process. In [Microsoft.CodeCoverage](https://www.nuget.org/packages/Microsoft.CodeCoverage) version [17.2.0](https://www.nuget.org/packages/Microsoft.CodeCoverage/17.2.0) we took dependency on [CLR instrumentation engine](https://github.com/microsoft/CLRInstrumentationEngine) and added support for dynamic instrumentation on Linux x64 and macOS x64. Unfortunately we were not able to extend it to all platforms due too some native dependencies not available. Therefore in version [17.5.0](https://www.nuget.org/packages/Microsoft.CodeCoverage/17.5.0) we added option to collect code coverage in static way, which means that libraries are instrumented on disk before loading by the process. As instrumentation is done fully in managed way (leveraging [Mono.Cecil](https://github.com/jbevain/cecil)), it is supported on all platforms where .NET is supported. By default dynamic instrumentation is enabled on all platforms. Static instrumentation is enabled by on non-Windows operating systems. When both dynamic and static instrumentation is enabled our tools detects that file loaded by process is already statically instrumented and skips dynamic instrumentation.

Dynamic instrumentation requires configuring environment variables (CLR Profiling) to collect code coverage. In environments where this is not possible (for example IIS) we recommend using static instrumentation.

You can control dynamic and static instrumentation using below flags in your configuration:
```xml
<CodeCoverage>
  <EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>
  <EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>
</CodeCoverage>
```

As we mentioned above when static instrumentation is enabled libraries and corresponding pdb files are changed before loaded by process under code coverage. By default we are restoring those files after process is done. You can disable it by adding into your configuration:

```xml
<CodeCoverage>
  <EnableStaticManagedInstrumentationRestore>False</EnableStaticManagedInstrumentationRestore>
</CodeCoverage>
```
It can be useful when debugging some issues or to speed up build inside pipeline. 

> **_NOTE:_** Make sure instrumented binaries are not deployed into production.

When you use static instrumentation by default all libraries from test project output folder are instrumented (changed). If you need to instrument more libraries you can specify additional directories:

```xml
<CodeCoverage>
<ModulePaths>
  <IncludeDirectories>
     <Directory Recursive="True">D:\src\Lib1\bin\Debug</Directory>
     <Directory Recursive="False">D:\src\Lib2\bin\Debug</Directory>
  </IncludeDirectories>
</ModulePaths>
</CodeCoverage>
```

Above configuration will make sure all files from `D:\src\Lib1\bin\Debug` directory and subdirectories will be also instrumented. Also all files from directory `D:\src\Lib2\bin\Debug` will be instrumented.
