# Scenario Description

Collect and view code coverage in Microsoft Visual Studio Enterprise.

# Collect code coverage

1. Clone repository
    ```shell
    git clone https://github.com/microsoft/codecoverage.git
    ```

2. Open solution in Visual Studio
    ```shell
    cd codecoverage/samples/VisualStudio
    start VisualStudio.sln
    ```

3. On the **Test** menu, select **Analyze Code Coverage for All Tests**.
    ![alt text](analyze-codecoverage.png "Test menu with Analyze Code Coverage for All Tests command.")

        > [!TIP]
        > You can also run code coverage from the **Test Explorer** tool window.
    
# Enable code coverage coloring
1. Enable code coverage coloring, choose ![](code-coverage.png) **Show Code Coverage Coloring** to enable coloring in the editor.
    ![](enable-coloring.png "Enable Code Coverage Coloring in Visual Studio.")

    Enable **Line Coloring** to view coverage status in the code editor.
    ![](line-coloring.png "Show Code Coverage Coloring in the code editor.")

    Enable **Margin Glyphs** to view coverage status in the margin editor.
    ![](margin-glyphs.png "Show Code Coverage Coloring in the margin editor.")


# Update code coverage result window layout
1. Update columns using ![](add-remove-columns.png) **Add/Remove Columns...** from the context menu.
    ![](add-remove-columns-menu.png)

2.  Add/remove or order columns shown in the code coverage results window.
    ![](columns-window.png)

# Report
[Link](coverage-status.coverage)