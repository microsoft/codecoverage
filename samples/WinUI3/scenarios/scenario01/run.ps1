[CmdletBinding()]
param(
  [string]$PackageName = "Microsoft.CodeCoverage.WinUI3Sample",
  [string]$ApplicationId = "App",
  [string]$OutputPath = (Join-Path $PSScriptRoot "report.cobertura.xml")
)

$ErrorActionPreference = "Stop"

$dotnetCoverage = Get-Command dotnet-coverage -ErrorAction SilentlyContinue
if ($null -eq $dotnetCoverage)
{
  throw "dotnet-coverage is not installed. Run 'dotnet tool install --global dotnet-coverage'."
}

$collectHelp = (& dotnet-coverage collect --help 2>&1 | Out-String)
if ($collectHelp -notmatch "--app-id")
{
  throw "The installed dotnet-coverage version does not support packaged applications. Update to version 18.11.2 or later."
}

$package = Get-AppxPackage -Name $PackageName
if ($null -eq $package)
{
  throw "Package '$PackageName' is not installed. Build and deploy the WinUI 3 sample from Visual Studio first."
}

$appUserModelId = "$($package.PackageFamilyName)!$ApplicationId"
$resolvedOutputPath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($OutputPath)

Write-Host "Collecting coverage for $appUserModelId"
Write-Host "Select 'Run covered code' in the application, and then close the application window."

& dotnet-coverage collect --app-id $appUserModelId -f cobertura -o $resolvedOutputPath
if ($LASTEXITCODE -ne 0)
{
  throw "dotnet-coverage failed with exit code $LASTEXITCODE."
}

Write-Host "Code coverage report: $resolvedOutputPath"
