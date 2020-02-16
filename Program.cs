using System;
using System.Text;

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
            //low-level builder            
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            //does not build up different html objects, that's
            //why we need an HtmlBuilder
            var words = new string[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            //now nicely formatted using and html construct (oop way)
            // it will always build up trees of html elements
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world"); //chaining calls

            Console.WriteLine(builder.ToString());

            Console.ReadLine();
        }
    }
}
