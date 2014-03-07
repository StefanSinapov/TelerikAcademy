using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
			return new HTMLElement(name);
		}

		public IElement CreateElement(string name, string textContent)
		{
			return new HTMLElement(name, textContent);
		}

		public ITable CreateTable(int rows, int cols)
		{
 			return new HTMLTable(rows, cols);
		}
	}

	class HTMLElement : IElement
	{
		public virtual string Name { get; private set; }
		public virtual string TextContent { get; set; }
		private IList<IElement> childElements;

		public HTMLElement(string name)
		{
			this.Name = name;
			this.childElements = new List<IElement>();
		}

		public HTMLElement(string name, string content) : this(name)
		{
			this.TextContent = content;
		}

		public virtual IEnumerable<IElement> ChildElements
		{ 
			get
			{
				return this.childElements;
			}
		}

		public virtual void AddElement(IElement element)
		{
			this.childElements.Add(element);
		}

		public virtual void Render(StringBuilder output)
		{
			if (this.Name != null)
			{
				output.Append("<");
				output.Append(this.Name);
				output.Append(">");
			}
			if (this.TextContent != null)
			{
				output.Append(HTMLEncode(this.TextContent));
			}
			foreach (var childElement in this.childElements)
			{
				childElement.Render(output);
			}
			if (this.Name != null)
			{
				output.Append("</");
				output.Append(this.Name);
				output.Append(">");
			}
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			this.Render(result);
			return result.ToString();
		}

		protected string HTMLEncode(string text)
		{
			StringBuilder result = new StringBuilder();
			foreach (var ch in text)
			{
				if (ch == '<')
				{
					result.Append("&lt;");
				}
				else if (ch == '>')
				{
					result.Append("&gt;");
				}
				else if (ch == '&')
				{
					result.Append("&amp;");
				}
				else
				{
					result.Append(ch);
				}
			}
			return result.ToString();
		}
	}
	
	class HTMLTable : HTMLElement, ITable
	{
		public int Rows { get; private set; }
		public int Cols { get; private set; }
		private IElement[,] tableElements;

		public HTMLTable(int rows, int cols) : base("table")
		{
			if (rows <= 0)
			{
				throw new ArgumentOutOfRangeException("rows", 0, "Positive number required.");
			}
			if (cols <= 0)
			{
				throw new ArgumentOutOfRangeException("cols", 0, "Positive number required.");
			}
			this.Rows = rows;
			this.Cols = cols;
			this.tableElements = new IElement[rows, cols];
		}

		public override string TextContent
		{
			get
			{
				return null;
			}
			set
			{
				throw new InvalidOperationException("Tables cannot have text content");
			}
		}

		public virtual IElement this[int row, int col]
		{
			get
			{
				return this.tableElements[row, col];
			}

			set
			{
				this.tableElements[row, col] = value;
			}
		}

		public override void Render(StringBuilder output)
		{
			output.Append("<table>");
			for (int row = 0; row < this.Rows; row++)
			{
				output.Append("<tr>");
				for (int col = 0; col < this.Cols; col++)
				{
					output.Append("<td>");
					this.tableElements[row, col].Render(output);
					output.Append("</td>");
				}
				output.Append("</tr>");
			}
			output.Append("</table>");
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
