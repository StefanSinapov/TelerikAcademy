/*
 * 9. Rewrite the last exercises using XDocument, XElement and XAttribute.
 */
namespace _09.Traverse_Directory_with_XDocument
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    class TraverseDirectoryWithXDocument
    {
        private const string OutputFilePath = @"..\..\..\output\directory-xdocument.xml";
        private const string PathToBeTraversed = @"..\..\..\";

        static void Main()
        {
            var direcotriesXml = new XElement("dirs");

            TraverseTree(PathToBeTraversed, direcotriesXml);

            direcotriesXml.Save(OutputFilePath);
        }

        public static void TraverseTree(string root, XElement rootElement)
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

                var dirElement = new XElement("dir");
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

                dirElement.Add(new XElement("name", currentDir));

                var filesElement = new XElement("files");

                foreach (string file in files)
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        filesElement.Add(new XElement("file", fi.Name));
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                dirElement.Add(filesElement);

                foreach (string str in subDirs)
                    dirs.Push(str);

                rootElement.Add(dirElement);
            }
        }
    }
}
