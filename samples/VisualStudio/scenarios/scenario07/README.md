# Scenario Description

Static C++ code coverage for new Native Unit Test project in Visual Studio ARM64.

## Collect C++ code coverage on ARM64 system

1. Open Visual Studio Enterprise

2. Create new Native Unit Test project.

    ![alt text](create.png "Create Native Unit Test Project.")

3. Enable **Profile** (Configuration Properties->Linker->Advanced) flag for all projects in solution

    ![alt text](profile-flag.png "Profile linker flag.")

4. Collect code coverage using **Analyze Code Coverage for All Tests** in the **Test** menu

    ![alt text](analyze.png "Test menu with Analyze Code Coverage for All Tests command.")

5. View code coverage results

    ![alt text](results.png "Code coverage results.")
