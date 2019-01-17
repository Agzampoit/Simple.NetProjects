using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute;

namespace TestLib
{
    [ExportClass("Класс, который делает что-то")]
    public class DoSomething
    {
        public DoSomething(string Name)
        {
            this.name = Name;
        }

        public string name;
    }

    [ExportClass("Класс, который ничего не делает")]
    public class NotDoSomething
    {
        
    }

    public class NoAttribute
    {

    }

    [ExportClass("Класс, который ничего не делает2")]
    public class NotDoSomething2
    {

    }
}
