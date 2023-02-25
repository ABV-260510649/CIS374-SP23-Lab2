using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> heap1 = new MinHeap<int>();
            heap1.Add(0);
            heap1.Add(25);
            heap1.Add(50);
            heap1.Add(75);
            heap1.Add(100);
            heap1.Add(125);
            heap1.Add(150);

            //Console.WriteLine( (heap1.Contains(25))); True
            //Console.WriteLine( (heap1.Contains(5000))); // False
            heap1.Add(5000);
            // Console.WriteLine(  (heap1.Contains(5000))); //True
            //Console.WriteLine( (heap1.Contains(150))); //True
            heap1.ExtractMin();
            Console.WriteLine( (heap1.Contains(0))); //False
            Console.WriteLine(heap1.ExtractMax());

            /*MaxHeap<int> heap1 = new MaxHeap<int>();
            heap1.Add(0);
            heap1.Add(25);
            heap1.Add(50);
            heap1.Add(75);
            heap1.Add(100);
            heap1.Add(125);
            heap1.Add(150);

            heap1.Add(5000);
            heap1.ExtractMax();
            Console.WriteLine(heap1.Peek());
            Console.WriteLine(heap1.Count);
            Console.WriteLine( (heap1.Contains(5000)));
            Console.WriteLine(heap1.ExtractMin());*/

        }
    }
}

