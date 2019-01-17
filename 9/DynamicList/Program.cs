using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicList
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<Person> list = new DynamicList<Person>();
            list.Add(new Person("First obj"));
            list.Add(new Person("Second obj"));
            list.Add(new Person("Third ogj"));
            list.Add(new Person("4-th obj"));
            Person pr5 = new Person("5-th obj");
            list.Add(pr5);
            list.ToList();
            Console.WriteLine(list.Count);
            
            foreach(Person pers in list)
            {
                Console.WriteLine(pers.Name);
            }

            list.Remove(pr5);

            foreach (Person pers in list)
            {
                Console.WriteLine(pers.Name);
            }

            list.Clear();

            Console.WriteLine(list.Count);

            Console.ReadLine();
        }

        class Person
        {
            private readonly string _name;
            public Person(string name)
            {
                _name = name;
            }
            public string Name
            {
                get => _name;
            }
        }
    }
}
