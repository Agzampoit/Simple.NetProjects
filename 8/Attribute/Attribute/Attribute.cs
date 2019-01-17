using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClass: System.Attribute
    {
        public string Name { get; set; }

        public ExportClass()
        {
            this.Name = "Не назначено";
        }

        public ExportClass(string name)
        {
            this.Name = name;
        }
    }
}
