using System;
using System.Collections.Concurrent;
using System.Threading;

namespace lab1
{
    public class TaskQueue
    {
        private bool working;

        private Thread[] threads;
        public delegate void TaskDelegate();
        private TaskDelegate[] threadTasks;
        private object[] threadLockers;


        private ConcurrentQueue<TaskDelegate> queue;
        private Thread dequeueThread;

        public TaskQueue(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("count", "Thread count must be greater than zero");
            }

            working = true;

            threads = new Thread[count];
            threadTasks = new TaskDelegate[count];
            threadLockers = new object[count];

            // create thread pool
            for (int i = 0; i < count; i++)
            {
                threadLockers[i] = new object();
                threads[i] = new Thread(() =>
                {
                    int index = Convert.ToInt32(Thread.CurrentThread.Name);
                    while (working)
                    {
                        lock (threadLockers[index])
                        {
                            threadTasks[index]?.Invoke();
                            threadTasks[index] = null;
                        }

                        Thread.Sleep(0);
                    }
                });
                threads[i].Name = i.ToString();
                threads[i].Start();
            }

            // create thread that dequeues tasks
            queue = new ConcurrentQueue<TaskDelegate>();
            dequeueThread = new Thread(DequeueTasks);
            dequeueThread.Start();
        }

        public void EnqueueTask(TaskDelegate task)
        {
            queue.Enqueue(task);
        }

        public void Finish()
        {
            bool noTasks;
            do
            {
                // no tasks in queue
                noTasks = queue.Count == 0;
                // all threads finished their tasks
                for (int i = 0; i < threads.Length; i++)
                {
                    noTasks = noTasks && threadTasks[i] == null;
                }

                Thread.Sleep(0);
            }
            while (!noTasks);

            working = false;
        }

        private void DequeueTasks()
        {
            while (working)
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    // searching for first thread without task
                    if (threadTasks[i] == null)
                    {
                        lock (threadLockers[i])
                        {       //пока в очереди нету задач и работает - ожидаем
                                //если нашлась задача, то помещаем ее в threadTasks[i]
                            while (!queue.TryDequeue(out threadTasks[i]) && working) { }
                        }
                    }
                }

                Thread.Sleep(0);
            }
        }
    }

}
