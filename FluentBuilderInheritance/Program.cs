using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    /// <summary>
    /// builders inheriting from other builders = no problem
    /// unless you are using fluent interfaces. This is
    /// mitigated using recursive generics
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new PersonJobBuilder();
            //builder.Called("Mark"); // problem is that we cannot do chain calls of methods

            //uses fluent inheritance builder api
            var person = Person.New.Called("Mark").WorksAsA("teacher").Build();
            Console.WriteLine(person);

            Console.ReadLine();
        }
    }
}