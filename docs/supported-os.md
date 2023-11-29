# Supported OS versions

Below table illustrates the availability of our tooling on different operating systems and specifies whether dynamic or static instrumentation is enabled or disabled by default.

OS                                    | Version               | Architectures     | Dynamic instrumentation |Static instrumentation
--------------------------------------|-----------------------|-------------------|-------------------------|----------------------
Windows                               | Any                   | x64, x86, Arm64   | Supported - Enabled     | Supported - Disabled
Alpine Linux                          | 3.15+                 | x64               | Supported - Enabled     | Supported - Enabled
Alpine Linux                          | 3.15+                 | Arm64, Arm32      | Not supported           | Supported - Enabled
CentOS                                | 7                     | x64               | Not supported           | Supported - Enabled
CentOS                                | 8+                    | x64               | Supported - Enabled     | Supported - Enabled
Debian                                | 10+                   | x64               | Supported - Enabled     | Supported - Enabled
Debian                                | 10+                   | Arm64, Arm32      | Not supported           | Supported - Enabled
Fedora                                | 33+                   | x64               | Supported - Enabled     | Supported - Enabled
OpenSUSE                              | 15+                   | x64               | Supported - Enabled     | Supported - Enabled
Oracle Linux                          | 7+                    | x64               | Supported - Enabled     | Supported - Enabled
Red Hat Enterprise Linux              | 7+                    | x64               | Supported - Enabled     | Supported - Enabled
Red Hat Enterprise Linux              | 7+                    | Arm64             | Not supported           | Supported - Enabled
SUSE Enterprise Linux (SLES)          | 12 SP+                | x64               | Supported - Enabled     | Supported - Enabled
Ubuntu                                | 18.04+                | x64               | Supported - Enabled     | Supported - Enabled
Ubuntu                                | 18.04+                | Arm64, Arm32      | Not supported           | Supported - Enabled
macOS                                 | 10.15+                | x64               | Supported - Enabled     | Supported - Enabled
macOS                                 | 10.15+                | Arm64             | Not supported           | Supported - Enabled

Other operating systems are supported at best effort.

## Linux libc compability (only dynamic instrumentation)

- x64: [glibc](https://www.gnu.org/software/libc/) 2.27 (from ubuntu 18.04)
- Alpine: [musl](https://musl.libc.org/) 1.2.2 (from Alpine 3.13)

## Dependencies (only dynamic instrumentation)

On macOS and linux dynamic instrumentation requires [libxml2](https://github.com/GNOME/libxml2) package to be installed.