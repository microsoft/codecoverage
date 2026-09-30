# Scenario Description

Collect JIT/CLRIE code coverage for a full-trust packaged (MSIX) WinUI 3 application.

Packaged applications are activated by the Windows Package Lifecycle Manager instead of being
started as ordinary child processes. The `--app-id` option lets `dotnet-coverage` activate the
installed application by its Application User Model ID (AUMID) and inject the profiler environment
into that activation.

> **_NOTE:_** This scenario applies to full-trust packaged applications. AppContainer applications
> such as UWP applications require additional support.

## Prerequisites

- Windows 10 version 2004 (build 19041) or later
- .NET 8 SDK
- Visual Studio with the WinUI application development workload and single-project MSIX tooling
- `dotnet-coverage` 18.11.2 or later

Install or update the tool:

```powershell
dotnet tool update --global dotnet-coverage
```

Confirm that the installed tool supports packaged applications:

```powershell
dotnet-coverage collect --help
```

The output should contain the `--app-id` option.

## Build and deploy the sample application

1. Open [WinUI3CodeCoverageApp.csproj](../../src/WinUI3CodeCoverageApp/WinUI3CodeCoverageApp.csproj)
   in Visual Studio.
2. Select the `x64` platform.
3. Build and deploy the project.
4. Close the application if Visual Studio launches it.

Confirm that the package is installed:

```powershell
Get-AppxPackage -Name Microsoft.CodeCoverage.WinUI3Sample
```

## Collect code coverage

From this scenario directory, run:

```powershell
.\run.ps1
```

`dotnet-coverage` activates the packaged application. Select **Run covered code**, and then close the
application window. Collection finishes when the application exits, and the script writes
`report.cobertura.xml` to this directory.

This scenario is intended for local Windows validation. It is not run in GitHub Actions because
hosted agents do not support registering and interactively running this MSIX application.

The equivalent manual commands are:

```powershell
$package = Get-AppxPackage -Name Microsoft.CodeCoverage.WinUI3Sample
$appId = "$($package.PackageFamilyName)!App"
dotnet-coverage collect --app-id $appId -f cobertura -o report.cobertura.xml
```

Do not start the application before running `dotnet-coverage`; the collector must activate the
package so the coverage profiler environment is applied to the new process.
