using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WaitAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Action[] delegates = new Action[4];

            delegates[0] = Write1;
            delegates[1] = Write2;
            delegates[2] = () => 
            {
                Console.WriteLine("//////////////////////////THREAD 3 START WORK");
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("Thread 3 is working - {0}", i);
            };
            delegates[3] = Write4;

            Parallel.Parallel.WaitAll(delegates);
            Console.WriteLine("Main Thread ended");
            Console.ReadLine();
        }



        static private void Write1()
        {
            Console.WriteLine("//////////////////////////THREAD 1 START WORK");
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Thread 1 is working - {0}", i);
        }

        static private void Write2()
        {
            Console.WriteLine("//////////////////////////THREAD 2 START WORK");
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Thread 2 is working - {0}", i);
        }

        static private void Write4()
        {
            Console.WriteLine("//////////////////////////THREAD 4 START WORK");
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Thread 4 is working - {0}", i);
        }

    }
}
