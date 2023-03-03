using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap0 = new MaxHeap<int>();
            heap0.Add(160);
            heap0.Add(130);
            heap0.Add(100);
            heap0.Add(90);
            heap0.Add(60);

            heap0.Update(60, 65);


            heap0.Update(130, 85);


            heap0.Update(90, 165);


            heap0.Update(160, 250);

            heap0.Update(0, 10);
            Console.WriteLine( heap0.Contains(0));

        }
    }
}

