## 03. Data Modeling and ER Diagram

1. Create the following database diagram in SQL Server:
	![diagram](01.%20Diagram/DB-diagram.png)
* Fill some sample data in the tables with SQL Server Management Studio.
* Typical universities have: faculties, departments, professors, students, courses, etc. Faculties have name and could have several departments. Each department has name, professors and courses. Each professor has name, a set of titles (Ph. D, academician, senior assistant, etc.) and a set of courses. Each course consists of several students. Each student belongs to some faculty and to several of the courses. Your task is to create a data model (E/R diagram) for the typical university in SQL Server using SQL Server Management Studio (SSMS).
* Create the same data model in MySQL.
* We should design a multilingual dictionary. We have a set of words in the dictionary.
	- Each word can be in some language and can have synonyms and explanations in the same language and translation words and explanations in several other languages.
	- The synonyms and translation words are sets of words from the dictionary. The explanations are textual descriptions.
	- Design a database schema (a set of tables and relationships) to store the dictionary.
* Add support in the previous database for storing antonym pairs.
	- Add support for storing part-of-speech information (e.g. verb, noun, adjective, �).
	- Add support for storing hypernym / hyponym chains (e.g. tree ? oak, pine, walnut-tree, �).