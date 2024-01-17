# Report Type View

Coverage report content can be filtered in two different ways in the **Code Coverage Results** window

1. Full Report
2. Changeset Report

It can be selected by using ![configure views](../../../media/categorized-view.png) **Configure Code Coverage Views** button in the window toolbar.

![configure code coverage views](../configure-views.png)

Select **Report Content** from the **Code Coverage Views** dialog.

![select report style](report-content.png)

## Full Report

Full report shows all content present in the coverage report.

## Changeset Report

Changeset report filters the coverage report and shows only statistics for the changes made in local branch (commits + non committed changes). Developers can use this information to identify missing coverage for their changes and can improve coverage for newly added code.

## Example

1. Open [solution](../../../VisualStudio.sln) in Visual Studio Enterprise and switch branch to **changeset-view**

2. Open [changesetReport.coverage](../../../reports/changesetReport.coverage)

3. Open [ChangesetLibrary\ChangesetLibrary.cs](../../../src/ChangesetViewLibrary/ChangesetLibrary.cs)

4. Switch to **Changeset Report** and set **Base Branch** (origin/main)

    ![changeset-report](changeset.png)

Full report shows coverage statistics for the whole report, while changeset report shows coverage only for the changes made in local branch.

Full Report | Changeset Report
--- | ---
![full report](full-report.png) | ![changeset report](changeset-report.png)
