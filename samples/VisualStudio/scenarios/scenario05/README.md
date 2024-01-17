# Scenario Description

Search code coverage content in Microsoft Visual Studio Enterprise.

## Search

Search parameters can be used to filter the coverage report.

Search parameters are provided in the search control in the window toolbar.

![search toolbar](search-toolbar.png)

## Search Parameters

Following search parameters are available to filter the coverage report

1. Coverage numbers - methods where coverage value is greater or smaller than the specified search query
    1. Covered (%Blocks)
    2. Not Covered (%Blocks)
    3. Covered (%Lines)
    4. Partially Covered (%Lines)
    5. Not Covered (%Lines)
1. Name - items that contain input search query in their name
    1. Project Report
        1. Name
        2. Project
        3. Namespace
        4. Class
        5. Method
    2. Source Report
        1. Name
        2. Directory
        3. File
        4. Method

## Examples

- Without any search parameters

  ![no search](no-search.png)

- Name search
  
  ![any search](any-search.png)

- "Covered (%Blocks)":"<80"

  ![blocks search](blocks-covered.png)

- "Not Covered (%Blocks)":">50"

  ![no blocks search](not-covered-blocks.png)

- Method:"new"
  ![method search](method.png)

- Directory:"src"
  ![directory search](directory.png)
