﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement(){ }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: name);
            Text = text ?? throw new ArgumentNullException(paramName: text);
        }

        private string ToStringImplementation(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImplementation(indent + 1));
            }

            sb.AppendLine($"{i}<{Name}/>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImplementation(0);
        }
    }
}
