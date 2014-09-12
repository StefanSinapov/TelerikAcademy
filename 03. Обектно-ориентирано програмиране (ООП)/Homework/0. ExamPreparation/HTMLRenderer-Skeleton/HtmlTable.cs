using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
	public class HtmlTable : HtmlElement, ITable
	{
		private const string TableName = "table";
		private int rows;
		private int cols;
		private IElement[,] elements;


		public HtmlTable(int rows, int cols)
			: base(TableName, null)
		{
			this.Rows = rows;
			this.Cols = cols;
			this.elements = new IElement[rows, cols];
		}


		public int Rows
		{
			get
			{
				return this.rows;
			}
			private set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Rows cannot be negative");
				this.rows = value;
			}
		}
		public int Cols
		{
			get
			{
				return this.cols;
			}
			private set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Cols cannot be negative");
				this.cols = value;
			}
		}

		public IElement this[int row, int col]
		{
			get
			{
				if (row < 0 || col < 0)
					throw new IndexOutOfRangeException("Not valid index");
				return this.elements[row, col];
			}
			set
			{
				if (row < 0 || col < 0)
					throw new IndexOutOfRangeException("Not valid index");
				this.elements[row, col] = value;
			}
		}

		public void Render(StringBuilder output)
		{
			output.Append("<table>");
			for (int i = 0; i < this.Rows; i++)
			{
				output.Append("<tr>");
				for (int j = 0; j < this.Cols; j++)
				{
					output.Append("<td>");
					this.elements[i, j].Render(output);
					output.Append("</td>");
				}
				output.Append("</tr>");
			}
			output.Append("</table>");
		}
	}
}
