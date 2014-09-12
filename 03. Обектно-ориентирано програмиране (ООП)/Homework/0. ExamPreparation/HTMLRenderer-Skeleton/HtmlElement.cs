using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
	public class HtmlElement : IElement
	{
		private IList<IElement> childElements;
		public string Name { get; set; }
		public string TextContent { get; set; }

		public HtmlElement(string name)
		{
			this.Name = name;
		}

		public HtmlElement(string name, string content)
		{
			this.Name = name;
			this.TextContent = content;
			this.childElements = new List<IElement>();
		}

		public IEnumerable<IElement> ChildElements 
		{
			get { return this.childElements; }
		}


		public void AddElement(IElement element)
		{
			this.childElements.Add(element);
		}

		public virtual void Render(StringBuilder output)
		{
			if (this.Name != null)
			{
				output.Append(string.Format("<{0}>", this.Name));
			}
			if(this.TextContent!=null)
			{
				output.Append(RenderContent(this.TextContent));
			}
			if(this.childElements.Count>0)
			{
				foreach (var item in this.childElements)
				{
					output.Append(item.ToString());
				}
			}
			if (this.Name != null)
			{
				output.Append(string.Format("</{0}>", this.Name));
			}
			
		}

		private string RenderContent(string text)
		{
			StringBuilder result = new StringBuilder();
			foreach (var ch in text)
			{
				switch (ch)
				{
					case '<':
						result.Append("&lt;");
						break;
					case '>':
						result.Append("&gt;");
						break;
					case '&':
						result.Append("&amp;");
						break;
					default:
						result.Append(ch);
						break;
				}
			}
			return result.ToString();
		}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			this.Render(output);

			return output.ToString();
		}
	}
}
