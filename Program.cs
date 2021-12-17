using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Threading
{
    class Program
    {
        static void Main()
        {
            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
            Task tsk1 = Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    dic.TryAdd(i, i + 1);
                }
            });
            Task tsk2 = Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    dic.TryAdd(i + 1, i);
                }
            });
            Task[] allTasks = { tsk1, tsk2 }; Task.WaitAll(allTasks); // Wait for all tasks
            System.Console.WriteLine("Program ran succussfully");
        }
    } //This method prevents more than one thread from working on the same key value at a time preventing any issues from 2 threads trying to add the same key value.

    static void MyThreadMethod()
        {
            Console.WriteLine(">> This is myThread <<"); for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine(); Console.WriteLine(">> Bye From MyThread <<");
        }
        static void Main2(string[] args)
        {
            Thread myThread = new Thread(new ThreadStart(MyThreadMethod));

            myThread.IsBackground = true;

            myThread.Start();

            Console.WriteLine(">> This program is executing myThread and running it as a background process. <<");

            //This program is executing myThread and running it as a background process.
        }
    }
}
