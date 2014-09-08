/*
 * 08. Write a program to traverse given directory and write 
 * to a XML file its contents together with all subdirectories and files.
 * Use tags <file> and <dir> with appropriate attributes.
 * For the generation of the XML document use the class XmlWriter.
 */
namespace _08.Traverse_Directory_XmlWritter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    class TraverseDirectoryXmlWritter
    {
        private const string OutputFilePath = @"..\..\..\output\directory.xml";
        private const string PathToBeTraversed = @"..\..\..\";

        static void Main()
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (var writer = new XmlTextWriter(OutputFilePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("dirs");

                TraverseTree(PathToBeTraversed, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("Writing done, you can see result here: {0}", OutputFilePath);
        }

        public static void TraverseTree(string root, XmlTextWriter writer)
        {
            // Data structure to hold names of subfolders to be 
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                writer.WriteStartElement("dir");
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                //add dir to xml
                // Console.WriteLine(currentDir);

                writer.WriteElementString("name", currentDir);
                writer.WriteStartElement("files");

                foreach (string file in files)
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        writer.WriteElementString("file", fi.Name);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndElement();

                foreach (string str in subDirs)
                    dirs.Push(str);
            }
        }
    }
}
