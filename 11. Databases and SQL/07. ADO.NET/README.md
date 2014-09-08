## 07. ADO.NET

1. Write a program that retrieves from the `Northwind` sample database in MS SQL Server the number of  rows in the `Categories` table.
2. Write a program that retrieves the name and description of all categories in the `Northwind` DB.
3. Write a program that retrieves from the `Northwind` database all product categories and the names of the products in each category. Can you do this with a single SQL query (with table join)?
4. Write a method that adds a new product in the products table in the `Northwind` database. Use a parameterized SQL command.
5. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
6. Create an Excel file with 2 columns: `name` and `score`
	![excel-img](./06.%20Read%20MS%20Excel/excel.png)
	Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
7. Implement appending new rows to the Excel file.
8. Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like `'`, `%`, `"`, `\` and `_`.
9. Download and install `MySQL` database, `MySQL Connector/Net` (.NET Data Provider for MySQL) + `MySQL Workbench` GUI administration tool . Create a MySQL database to store `Books` (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.
10. Re-implement the previous task with SQLite embedded DB (see [http://sqlite.phxsoftware.com](http://sqlite.phxsoftware.com)).