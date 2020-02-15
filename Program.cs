using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    /// <summary>
    /// some objects are simple enough to be created in
    /// a single constructor call
    /// some objects require a lot of ceremony to create (many concatenations vs stringbuilder)
    /// not good to have many params in ctor, opt for piecewise construction instead
    /// builder provides an api for building objects step-by-step
    /// if piecewise construction is complicated, then give api for doing it succintly
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new string[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            Console.ReadLine();
        }
    }
}
