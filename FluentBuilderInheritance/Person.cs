using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public class PersonInfoBuilder
    {
        protected Person person = new Person();
        public PersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
    }

    public class PersonJobBuilder : PersonInfoBuilder //open-closed principle
    {
        public PersonJobBuilder WorksAsA(string position)
        {
            person.Position = position;
            return this;
        }
    }
}
