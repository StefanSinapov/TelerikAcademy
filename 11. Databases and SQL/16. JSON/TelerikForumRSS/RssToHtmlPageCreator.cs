namespace TelerikForumRSS
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Models;

    public class RssToHtmlPageCreator
    {
        private const string RssItemTemplateFormat = "<li><a href=\"{0}\"><strong>[{1}]</strong> {2}</a></li>";

        private const string HtmlPageBeggining =
@"<!DOCTYPE html>
<html>
    <body>
        <h1>Telerik Academy RSS Feed</h1>
        <ul>
";
        private const string HtmlPageEnding =
@"        </ul>
    </body>
</html>
";

        public void CreateHtmlPage(string path, IEnumerable<Item> rssItems)
        {
            string html = this.GenerateHtml(rssItems);
            this.CreateFile(path, html);
        }

        private void CreateFile(string path, string html)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(html);
                }
            }
        }

        private string GenerateHtml(IEnumerable<Item> rssItems)
        {
            var page = new StringBuilder();
            page.AppendLine(HtmlPageBeggining);

            foreach (Item rssItem in rssItems)
            {
                var line = string.Format(RssItemTemplateFormat, rssItem.Link, rssItem.Category, rssItem.Title);
                page.AppendLine(line);
            }

            page.AppendLine(HtmlPageEnding);
            return page.ToString();
        }
    }
}