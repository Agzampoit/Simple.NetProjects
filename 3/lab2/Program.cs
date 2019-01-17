using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab2
{
    class Program
    {
        private class IncDecThreads
        {
            private Thread incThr, decThr;
            private int n;

            public IncDecThreads(int n = 3)
            {
                this.n = n;
                incThr = new Thread(Inc);
                decThr = new Thread(Dec);
                incThr.Start();
                decThr.Start();
            }

            private void Inc()
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Thread {0} is waiting for mutex...", Thread.CurrentThread.ManagedThreadId);
                    SharedResource.mtx.Lock();
                    Console.WriteLine("Thread {0} has accessed the variable", Thread.CurrentThread.ManagedThreadId);
                    SharedResource.Counter++;
                    Console.WriteLine("Thread {0} has changed the variable value to {1}", Thread.CurrentThread.ManagedThreadId, SharedResource.Counter);
                    SharedResource.mtx.UnLock();
                    Thread.Sleep(0);
                }
            }

            private void Dec()
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Thread {0} is waiting for mutex...", Thread.CurrentThread.ManagedThreadId);
                    SharedResource.mtx.Lock();
                    Console.WriteLine("Thread {0} has accessed the variable", Thread.CurrentThread.ManagedThreadId);
                    SharedResource.Counter--;
                    Console.WriteLine("Thread {0} has changed the variable value to {1}", Thread.CurrentThread.ManagedThreadId, SharedResource.Counter);
                    SharedResource.mtx.UnLock();
                    Thread.Sleep(0);
                }
            }
        }

        private static class SharedResource
        {
            public static int Counter = 0;
            public static Mutex mtx = new Mutex();
        }


        static void Main(string[] args)
        {
            IncDecThreads threads = new IncDecThreads(10);
            Console.ReadLine();
        }
    }
}
