using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
	public class Document :  IDocument
	{
		public string Name
		{
			get { throw new NotImplementedException(); }
		}

		public string Content
		{
			get { throw new NotImplementedException(); }
		}

		public void LoadProperty(string key, string value)
		{
			throw new NotImplementedException();
		}

		public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
		{
			throw new NotImplementedException();
		}
	}
}
