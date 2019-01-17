using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Parallel
{
    class Parallel
    {
        static CountdownEvent countOfActions; 

        public static void WaitAll(Action[] actions)
        {
            countOfActions = new CountdownEvent(actions.Length);

            // add actions to threads
            foreach (Action action in actions)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(WaitOne, action);
                
            }

            countOfActions.Wait();
        }

        private static void WaitOne(object action)
        {
            (action as Action).Invoke();
            countOfActions.Signal();
        }

    }
}
