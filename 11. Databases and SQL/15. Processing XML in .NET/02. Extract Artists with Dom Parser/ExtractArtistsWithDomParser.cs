/*
 * Write program that extracts all different artists 
 * which are found in the catalog.xml. 
 * For each author you should print the number 
 * of albums in the catalogue. 
 * Use the DOM parser and a hash-table.
 */
namespace _02.Extract_Artists_with_Dom_Parser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractArtistsWithDomParser
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";
        static void Main()
        {
            var artists = new Dictionary<string, int>();
            var doc = new XmlDocument();
            doc.Load(FilePath);

            var rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                XmlElement artistNode = node["artist"];
                if (artistNode != null)
                {
                    var artist = artistNode.InnerText;
                    var xmlElement = node["songs"];
                    if (xmlElement != null)
                    {
                        var numberOfSongs = xmlElement.ChildNodes.Count;

                        if (!artists.ContainsKey(artist))
                        {
                            artists.Add(artist, 0);
                        }

                        artists[artist] += numberOfSongs;
                    }
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0}: {1} songs", artist.Key, artist.Value);
            }
        }
    }
}
