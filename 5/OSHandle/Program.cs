using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            OSHandler test = new OSHandler();
            test.Handle = 1;
            Console.WriteLine(test.Handle);
            test.Dispose();
            Console.WriteLine(test.Handle);
            Console.ReadLine();
        }
    }
}
