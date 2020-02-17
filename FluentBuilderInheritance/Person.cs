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

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }

    // this builder is now amenable to inheritance
    // it supports inheritance and a fluent interface
    // class Foo : Bar<Foo>
    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        protected Person person = new Person();
        public /*PersonInfoBuilder*/ SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    // this builder is now amenable to inheritance
    // it supports inheritance and a fluent interface
    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
                                        where SELF : PersonJobBuilder<SELF>//open-closed principle; recursive generics 
    {
        public /*PersonJobBuilder*/ SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}