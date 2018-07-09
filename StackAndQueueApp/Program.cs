using System;

namespace StackAndQueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3.3
            
            // 3.3 Test Case 1
            var stack331 = new SetOfStacks<int>(3);
            for (int i = 1; i <= 20; i++)
            {
                stack331.Push(i);
            }
            Console.WriteLine(stack331);

            Console.Write("Poped: ");
            for (int i = 1; i <= 8; i++)
            {
                Console.Write($"{stack331.Pop()} ");
            }
            Console.WriteLine($"\n{stack331}");

            #endregion
        }
    }
}
