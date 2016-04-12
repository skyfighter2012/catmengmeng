using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Async
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = DoSomethingAsync();
            Console.WriteLine(task.Id);
            Console.ReadKey();
        }

        public static async Task DoSomethingAsync()
        {
            int val = 13;
            Console.WriteLine("before first await");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("first await");
            val *= 2;
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("DoSomethingAsync");
        }
    }
}
