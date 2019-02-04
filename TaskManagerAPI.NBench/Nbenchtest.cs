using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Repository;
using NBench;


namespace TaskManagerAPI.NBench
{
    public class Nbenchtest
    {
        TaskRepository repo = new TaskRepository();

        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void Gettasks_performance()
        {
            Console.WriteLine("started");
            repo.GetAllTasks();
            Console.WriteLine("End");
        }


    }
}
