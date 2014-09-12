namespace Phonebook
{
    using System.Text;

    public class PrinterWithStringBuilder : IPrinter
    {
        private StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            this.output.AppendLine(text);
        }

        public string GetAllAsString()
        {
            return this.output.ToString();
        }
    }
}