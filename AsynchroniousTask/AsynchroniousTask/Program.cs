using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronious
{
    class Program
    {
        public static void Main(String[] args)
        {
            Task t = new Task(
                () => {
                    System.Threading.Thread.Sleep(5000);
                    Console.WriteLine("Huge Task Finish");
                }
                );

            //Start the Task  
            t.Start();

            //Wait for 1 second  
            bool rValue = t.Wait(1000);
            Console.WriteLine("Main Process Finished");
            Console.ReadLine();
            Task t1 = new Task(
() => {
    System.Threading.Thread.Sleep(5000);

});
            t1.Start();
            Console.WriteLine("Cancelled:- " + t.IsCanceled);
            Console.WriteLine("Completed:- " + t.IsCompleted);
            Console.WriteLine("Folted:- " + t.IsFaulted);
            Console.WriteLine("End of Main");
            Console.ReadLine();



            //parent and child class
            Task Parent = new Task(
() => {
    Task Child = new Task(
    () => {
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Inner Task Finish");
    },
    TaskCreationOptions.AttachedToParent
    );

    //Start Child Task  
    Child.Start();
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("Outer Task Finish");
}
);

            //Start the Task  
            Parent.Start();
            Parent.Wait();
            Console.ReadLine();
        }
    }
}