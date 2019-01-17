using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLoadLib
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Kostya\source\repos\TestLib\TestLib\bin\Debug\Testlib.dll";
            AssemblyLoad parser = new AssemblyLoad(filename);

            List<string> types = parser.GetPublicTypes();

            foreach (string type in types)
            {
                Console.WriteLine(type);
            }

            Console.ReadLine();
        }
    }
}
