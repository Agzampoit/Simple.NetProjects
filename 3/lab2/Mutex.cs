using System.Threading;

namespace lab2
{
    class Mutex
    {
        private int ID = -1; //-1 - open, >0 locked

        public void Lock()
        {
            int currentID = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref ID, currentID, -1) != -1)
            {
                Thread.Sleep(100);
            }
        }

        public void UnLock()
        {
            int currentID;
            do
            {
                currentID = Thread.CurrentThread.ManagedThreadId;
            } while (Interlocked.CompareExchange(ref ID, -1, currentID) != -1);
        }
    }
}
