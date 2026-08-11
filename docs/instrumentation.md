# Static and dynamic instrumentation

For years, our Microsoft's code coverage tooling was exclusive to Windows, employing dynamic instrumentation through CLR profiling ([Profiling Overview - .NET Framework | Microsoft Learn](https://learn.microsoft.com/dotnet/framework/unmanaged-api/profiling/profiling-overview)). Dynamic instrumentation involves instrumenting libraries in memory after the library image is loaded by the process.

In [Microsoft.CodeCoverage](https://www.nuget.org/packages/Microsoft.CodeCoverage) version [17.2.0](https://www.nuget.org/packages/Microsoft.CodeCoverage/17.2.0), we incorporated a dependency on the [CLR instrumentation engine](https://github.com/microsoft/CLRInstrumentationEngine) and introduced support for dynamic instrumentation on Linux x64 and macOS x64. Unfortunately, extending this support to all platforms was hindered by some unavailable native dependencies.

Therefore, in version [17.5.0](https://www.nuget.org/packages/Microsoft.CodeCoverage/17.5.0), we added an option to collect code coverage in a static way. This implies that libraries are instrumented on disk before loading by the process. As the instrumentation is fully managed (leveraging [Mono.Cecil](https://github.com/jbevain/cecil)), it is supported on all platforms where .NET is available. Dynamic instrumentation remains the default on all platforms, while static instrumentation is enabled on non-Windows operating systems. When both dynamic and static instrumentation are enabled, our tools detect that the file loaded by the process is already statically instrumented and subsequently skip dynamic instrumentation.

Dynamic instrumentation necessitates configuring environment variables (CLR Profiling) for code coverage collection. In environments where this isn't feasible, such as in IIS, we recommend opting for static instrumentation.

You can control dynamic and static instrumentation using below flags in your configuration:

```xml
<CodeCoverage>
  <EnableDynamicManagedInstrumentation>True</EnableDynamicManagedInstrumentation>
  <EnableStaticManagedInstrumentation>True</EnableStaticManagedInstrumentation>
</CodeCoverage>
```

For the full list of instrumentation flags and their defaults, see
[Configuration](configuration.md#settings-under-codecoverage-tag). For a per-OS breakdown of
which instrumentation modes are supported and enabled by default, see
[Supported OS versions](supported-os.md).

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

## Verifiable instrumentation (probes)

When code is instrumented, code coverage normally records that a basic block ran by writing
directly into a shared-memory location from inside the instrumented method. On .NET Framework,
methods that participate in [Code Access Security (CAS)](https://learn.microsoft.com/dotnet/framework/misc/code-access-security)
verification — for example, methods marked with the `SecuritySafeCritical` or `SecurityCritical`
attributes, or code that runs in a partial-trust / verifiable context — are not allowed to
perform that kind of direct memory write. When such a method is instrumented in the normal way,
the CLR can reject the modified IL as unverifiable and the test host throws a
[`System.Security.VerificationException`](https://learn.microsoft.com/dotnet/api/system.security.verificationexception).

To support these scenarios, code coverage can emit **verifiable probes**. Instead of writing
directly into memory from the instrumented method, code coverage inserts a probe that calls out
to a separate helper method, and that helper performs the write. The instrumented method itself
stays verifiable, so it passes CAS verification and no `VerificationException` is thrown. This is
controlled by the `UseVerifiableInstrumentation` setting:

```xml
<CodeCoverage>
  <UseVerifiableInstrumentation>True</UseVerifiableInstrumentation>
</CodeCoverage>
```

### When to enable it

Enable verifiable instrumentation when **both** of the following are true:

- Your tests target **.NET Framework** (verification does not apply to modern .NET), and
- Coverage collection fails with a `System.Security.VerificationException`, or you are
  instrumenting assemblies that contain `SecuritySafeCritical` / `SecurityCritical` code or run
  in a partially trusted context.

Verifiable probes add a small amount of runtime overhead because each recorded block goes through
an extra helper call, so leave the setting at its default unless you hit one of the situations
above. For the setting's default per file type, see the `UseVerifiableInstrumentation` row in
[Configuration](configuration.md#settings-under-codecoverage-tag).

> **_NOTE:_** If you are using .NET Framework and see `System.Security.VerificationException`
> thrown by your tests while coverage is enabled, set `UseVerifiableInstrumentation` to `True`.

## See also

- [Configuration](configuration.md) — all code coverage settings, including the instrumentation flags shown above.
- [Supported OS versions](supported-os.md) — which instrumentation modes are available and enabled by default per OS.
