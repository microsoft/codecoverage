# Report Type View

Report content can be visualzied in two different ways in the **Code Coverage Results** window

1. Project View
2. Source View

View can be selected by using ![configure views](../../../media/categorized-view.png) **Configure Code Coverage Views** button in the window toolbar.

![configure code coverage views](../configure-views.png)

Select report style from the **Code Coverage Views** dialog.

![select report style](report-style.png)

## Project View

Project view shows coverage data in the following hierarchy

- Project1
  - Namespace1
    - Class1
      - Method
    - Class2
      - Method
      - Method
  - Namespace2
    - Class3
      - Method
- Project2

## Source View

Source view shows coverage data in directory/file hierarchy

- Directory1
  - Directory2
    - File1
    - File2
  - File3

Source view combines coverage data available for all projects and combine them on a file level. Source view does not support blocks coverage data. It combines data from

## Example

**Helpers.cs** file contains **MathHelpers**, **DirectoryHelpers**, and **FileHelpers** classes and is included in **SourceViewLibrary** and **SourceViewLibrary.Tests** project.

  1. Project view shows classes in both project nodes. Coverage statistics are according to respective project.
  ![project view report](project-view-report.png)
  2. Source view takes show combines coverage statistics for all classes and methods present in a file.
  ![source view report](source-view-report.png)
