# Scenario Description

Collect and view code coverage in Microsoft Visual Studio Enterprise.

# Collect code coverage using command line

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
    
4. Enable code coverage coloring, choose **Show Code Coverage Coloring** to enable coloring in the editor.
    ![alt text](enable-coloring.png "Enable Code Coverage Coloring in Visual Studio.")
    Enable **Line Coloring** to view coverage status in the code editor.
    ![alt text](line-coloring.png "Show Code Coverage Coloring in the code editor.")
    Enable **Margin Glyphs** to view coverage status in the margin editor.
    ![alt text](margin-glyphs.png "Show Code Coverage Coloring in the margin editor.")
 dotnet-coverage)](scenarios/scenario25/README.md)