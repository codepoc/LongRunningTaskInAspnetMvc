using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LongRunningTask.MyTask
{
    public class MyLongRunningTask
    {
        Guid currentRequest;
        public void RunMyTask(Guid requestId)
        {
            currentRequest = requestId;

            //Your actual long running task code goes here.

            //To run task in prallel
            
            //Method 1
            ThreadStart tsMethod1 = new ThreadStart(Method1);
            Thread tMethod1 = new Thread(tsMethod1);
            tMethod1.Start();

            //Method 2
            ThreadStart tsMethod2 = new ThreadStart(Method2);
            Thread tMethod2 = new Thread(tsMethod2);
            tMethod2.Start();                        
        }

        public void Method1()
        {
            ProgressTracker.add(currentRequest, "Method 1 :: Task 1: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "Method 1 :: Task 2: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "Method 1 :: Task 3: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "done");
        }


        public void Method2()
        {
            ProgressTracker.add(currentRequest, "Method 2 :: Task 1: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "Method 2 :: Task 2: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "Method 2 :: Task 3: Executing something!!!");
            System.Threading.Tasks.Task.Delay(3000).Wait();
            ProgressTracker.add(currentRequest, "done");
        }
    }
}
