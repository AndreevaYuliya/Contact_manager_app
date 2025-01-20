# Contact Manager Application

An ASP.NET MVC application that allows users to upload a CSV file with the following fields, store the data into MS SQL database, and display stored data on the page. 

CSV fields:
- Name [string]
- Date of birth [date]
- Married [bool]
- Phone [string]
- Salary [decimal] 

## Requirements:

1. Server-side:
    - Users should be able to upload a CSV file containing the specified fields.
    - The application should process the CSV file on the backend and save the data to an MS SQL database
2. Client-side
    - Users should be able to filter and sort the data by any column using JavaScript on the client side.
    - The table should support inline editing for any row, with an option to delete records from the database.
3. Additional Features:
    - Implement basic data validation and error handling.
