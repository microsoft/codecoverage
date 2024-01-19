# Report Type View

Coverage report content can be visualized in two different ways in the **Code Coverage Results** window

1. Project View
2. Source View

View can be selected by using ![configure views](../../../media/categorized-view.png) **Configure Code Coverage Views** button in the window toolbar.

![configure code coverage views](../configure-views.png)

Select **Report Style** from the **Code Coverage Views** dialog.

![select report style](report-style.png)

## Project View

Project view shows coverage data in the following hierarchy

- ![report](../../../media/code-coverage.png) Report
  - ![project](../../../media/module.png) Project1
    - ![namespace](../../../media/namespace.png) Namespace1
      - ![class](../../../media/class.png) Class1
        - ![method](../../../media/method.png) Method
      - ![class](../../../media/class.png) Class2
        - ![method](../../../media/method.png) Method
        - ![method](../../../media/method.png) Method
    - ![namespace](../../../media/namespace.png) Namespace2
      - ![class](../../../media/class.png) Class3
        - ![method](../../../media/method.png) Method
  - ![project](../../../media/module.png) Project2

## Source View

Source view shows coverage data in directory/file hierarchy

- ![report](../../../media/code-coverage.png) Report
  - ![directory](../../../media/directory.png) Directory1
    - ![directory](../../../media/directory.png) Directory2
      - ![file](../../../media/file.png) File1
        - ![method](../../../media/method.png) Method
        - ![method](../../../media/method.png) Method
      - ![file](../../../media/file.png) File2
        - ![method](../../../media/method.png) Method
    - ![file](../../../media/file.png) File3
      - ![method](../../../media/method.png) Method
  - ![file](../../../media/file.png) File4
    - ![method](../../../media/method.png) Method

Source view combines coverage data available for all projects and combines them on a file level. Source view does not support blocks coverage data.

## Example

Open [sourceview.coverage](../../../reports/sourceview.coverage) in the window. **Helpers.cs** file contains **MathHelpers**, **DirectoryHelpers**, and **FileHelpers** classes and is included in **SourceViewLibrary** and **SourceViewLibrary.Tests** project.

  1. Project view shows classes in both project nodes. Coverage statistics are according to respective project.
  ![project view report](project-view-report.png)
  2. Source view combines coverage statistics for all classes and methods present in a file.
  ![source view report](source-view-report.png)
