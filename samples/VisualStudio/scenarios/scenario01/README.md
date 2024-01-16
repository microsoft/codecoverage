# Scenario Description

Collect and view code coverage in Microsoft Visual Studio Enterprise.

## Collect code coverage

1. Clone repository

    ```shell
    git clone https://github.com/microsoft/codecoverage.git
    ```

2. Open solution in Visual Studio Enterprise

    ```shell
    cd codecoverage/samples/VisualStudio
    start VisualStudio.sln
    ```

3. Calculate code coverage using **Analyze Code Coverage for All Tests** in the **Test** menu.

    ![alt text](analyze-codecoverage.png "Test menu with Analyze Code Coverage for All Tests command.")

## Enable code coverage coloring

1. Enable code coverage coloring, choose ![enable code coverage coloring](../../media/code-coverage.png) **Show Code Coverage Coloring** to enable coloring in the editor.

    ![Enable Code Coverage Coloring in Visual Studio](enable-coloring.png "Enable Code Coverage Coloring in Visual Studio.")

2. Enable **Line Coloring** to view coverage status in the code editor.

    ![Show Code Coverage Coloring in the code editor](line-coloring.png "Show Code Coverage Coloring in the code editor.")

3. Enable **Margin Glyphs** to view coverage status in the margin editor.

    ![Show Code Coverage Coloring in the margin editor](margin-glyphs.png "Show Code Coverage Coloring in the margin editor.")

## Update code coverage result window layout

1. Update columns using ![](../../media/add-remove-columns.png) **Add/Remove Columns...** from the context menu.

    ![Add remove columns context menu](add-remove-columns-menu.png)

2. Add/remove or order columns shown in the code coverage results window.

    ![Columns selector window](columns-window.png)