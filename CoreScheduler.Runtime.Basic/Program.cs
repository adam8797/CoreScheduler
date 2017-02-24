using System;
using CoreScheduler.Server;
using Quartz;

namespace CoreScheduler.Runtime.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CoreRuntime.Start();
                Console.ReadLine();
            }
            catch (SchedulerException ex)
            {
                Console.WriteLine("An exception was thrown by the scheduler.");
                Console.WriteLine(ex);
                Console.WriteLine("The program will now exit.");
            }
        }
    }
}
