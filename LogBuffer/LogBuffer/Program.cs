using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LogBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer buf = new LogBuffer(30, 10000);
            //buf.Add("ПРивет  1");
            //buf.Add("ПРивет  2 ");
            //buf.Add("Привет 3");

            for (int i = 1; i <= 10000; i++)
            {
                buf.Add(i.ToString());
            }
            Console.WriteLine("Ready, Enter...");
            Console.ReadLine();

            Tester test1 = new Tester();
            Console.WriteLine("File is correct " + test1.IsCorrect());
            Console.ReadLine();
            
        }
    }
}
