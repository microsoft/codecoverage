# Release notes

These release notes summarize completed issues assigned to release milestones in the
[Microsoft code coverage repository](https://github.com/microsoft/codecoverage/issues).
Versions are listed newest first.

## 18.11

- Added profiler compatibility for Ubuntu 26.04
  ([microsoft/codecoverage#224](https://github.com/microsoft/codecoverage/issues/224)).
- Prevented intermittent Linux test-host access violations caused by coverage buffer mappings
  being invalidated while instrumented code is running
  ([microsoft/codecoverage#238](https://github.com/microsoft/codecoverage/issues/238)).
- Handled abandoned reconciliation mutexes so passing test hosts no longer abort during
  shutdown
  ([microsoft/codecoverage#245](https://github.com/microsoft/codecoverage/issues/245)).

## 18.9

- Fixed empty Cobertura reports in CI builds that set `ContinuousIntegrationBuild=true`
  ([microsoft/codecoverage#221](https://github.com/microsoft/codecoverage/issues/221)).

## 18.5

- Fixed empty Microsoft Testing Platform v2 coverage results for binaries built with
  `ContinuousIntegrationBuild=true`
  ([microsoft/codecoverage#198](https://github.com/microsoft/codecoverage/issues/198)).
- Restored incremental builds with .NET 11 when using the code coverage extension
  ([microsoft/codecoverage#209](https://github.com/microsoft/codecoverage/issues/209)).

## 18.3

- Corrected incomplete coverage results for C# records when auto-property skipping is disabled
  ([microsoft/codecoverage#186](https://github.com/microsoft/codecoverage/issues/186)).
