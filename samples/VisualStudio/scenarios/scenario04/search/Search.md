# Search

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
1. String - items that contain input search query in their name and type
    1. Common
        1. string
        2. Method
    2. Project Report only
        1. Project
        2. Namespace
        3. Class
    3. Source Report only
        1. Directory
        2. File

## Examples

- Without any search parameters

  ![no search](no-search.png)

- String search
  
  ![any search](any-search.png)

- "Covered (%Blocks)":"<80"

  ![blocks search](blocks-covered.png)

- "Not Covered (%Blocks)":">50"

  ![no blocks search](not-covered-blocks.png)

- Method:"new"
  ![method search](method.png)

- Directory:"src"
  ![directory search](directory.png)
