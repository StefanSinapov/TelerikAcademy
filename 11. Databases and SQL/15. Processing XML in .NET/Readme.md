## 15. Processing XML in .NET

1. Create a XML file representing catalogue. The catalogue should contain albums of different artists. For each album you should define: name, artist, year, producer, price and a list of songs. Each song should be described by title and duration.
* Write program that extracts all different artists which are found in the catalog.xml. For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
* Implement the previous using XPath.
* Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
* Write a program, which using XmlReader extracts all song titles from catalog.xml.
* Rewrite the same using XDocument and LINQ query.
* In a text file we are given the name, address and phone number of given person (each at a single line). Write a program, which creates new XML document, which contains these data in structured XML format.
* Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, in which stores in appropriate way the names of all albums and their authors.
* Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. Use tags <file> and <dir> with appropriate attributes. For the generation of the XML document use the class XmlWriter.
* Rewrite the last exercises using XDocument, XElement and XAttribute.
* Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use XPath query.
* Rewrite the previous using LINQ query.
* Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
* Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
* \* Read some tutorial about the XQuery language. Implement the XML to HTML transformation with XQuery (instead of XSLT). Download some open source XQuery library for .NET and execute the XQuery to transform the catalog.xml to HTML.
* Using Visual Studio generate an XSD schema for the file catalog.xml. Write a C# program that takes an XML file and an XSD file (schema) and validates the XML file against the schema. Test it with valid XML catalogs and invalid XML catalogs.
