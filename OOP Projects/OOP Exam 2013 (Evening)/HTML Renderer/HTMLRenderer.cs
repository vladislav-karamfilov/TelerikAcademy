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
            return new HtmlElement(name);
		}

		public IElement CreateElement(string name, string content)
		{
            return new HtmlElement(name, content);
		}

		public ITable CreateTable(int rows, int cols)
		{
            return new HtmlTable(rows, cols);
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

    public class HtmlElement : IElement
    {
        private string name;
        private string textContent;
        private IEnumerable<IElement> childElements;

        public HtmlElement(string name)
        {
            this.Name = name;
            this.ChildElements = new List<IElement>();
        }

        public HtmlElement(string name, string content)
        {
            this.Name = name;
            this.TextContent = content;
            this.ChildElements = new List<IElement>();
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public virtual string TextContent
        {
            get { return this.textContent; }
            set { this.textContent = value; }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
            private set { this.childElements = value; }
        }

        public virtual void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            (this.childElements as List<IElement>).Add(element);
        }

        public void Render(StringBuilder output)
        {
            if (output == null)
            {
                throw new ArgumentNullException();
            }
            output.Append(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this.Name != null)
            {
                output.Append("<" + this.Name + ">");
            }
            if (this.TextContent != null)
            {
                string newTextContent;
                newTextContent = this.TextContent.Replace("<", "&lt;");
                newTextContent = newTextContent.Replace(">", "&gt;");
                newTextContent = newTextContent.Replace("& ", "&amp; ");
                output.Append(newTextContent);
            }
            foreach (IElement childElement in childElements)
            {
                output.Append(childElement.ToString());
            }
            if (this.Name != null)
            {
                output.Append("</" + this.Name + ">");
            }
            return output.ToString();
        }
    }

    public class HtmlTable : HtmlElement, ITable
    {
        private readonly IElement[,] htmlElements;
        private const string TableName = "table";
        private const string TableTextContent = null;

        public HtmlTable(int rows, int cols)
            : base(TableName)
        {
            this.htmlElements = new HtmlElement[rows, cols];
        }

        public int Rows
        {
            get { return this.htmlElements.GetLength(0); }
        }

        public int Cols
        {
            get { return this.htmlElements.GetLength(1); }
        }

        public override string TextContent
        {
            get { return TableTextContent; }
            set { throw new InvalidOperationException(); }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException();
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.htmlElements[row, col];
            }
            set
            {
                this.htmlElements[row, col] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("<table>");
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    output.Append(this[row, col].ToString());
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
            return output.ToString();
        }
    }
}
