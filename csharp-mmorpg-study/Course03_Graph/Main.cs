using System;
using System.Collections.Generic;
using System.Text;

namespace Course03_Graph
{
    class Main
    {

        /*
         * Queue: FIFO
         * Stack: LIFO
         * 
         * 
         */
        public void Run()
        {
            Stack<int> stack = new();
            Queue<int> queue = new();

            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            int data = queue.Dequeue();
            int dataPeek = queue.Peek();
        }
    }
}
