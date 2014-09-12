using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
	public class DocumentSystemHandler
	{
		private List<IDocument> documents;

		public DocumentSystemHandler()
		{
			this.documents = new List<IDocument>();
		}

		public string AddTextDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string AddPdfDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string AddWordDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string AddExcelDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string AddAudioDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string AddVideoDocument(string[] attributes)
		{
			throw new NotImplementedException();
		}

		public string ListDocuments()
		{
			throw new NotImplementedException();
		}

		public string EncryptDocument(string name)
		{
			throw new NotImplementedException();
		}

		public string DecryptDocument(string name)
		{
			throw new NotImplementedException();
		}

		public string EncryptAllDocuments()
		{
			throw new NotImplementedException();
		}

		public string ChangeContent(string name, string content)
		{
			throw new NotImplementedException();
		}
	}
}
