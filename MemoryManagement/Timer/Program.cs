using System;
using System.Linq;

namespace Timer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.Start())
            {
                var sum = Enumerable.Range(1, 10000000).Select(x => (long) x).Sum();
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                long sum = 0;
                for (long i = 1; i < 10000000; i++)
                    sum += i;
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}