using System;

namespace LinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2.4

            // 2.4 Test Case 1
            var head241 = new Node(3);
            head241.Next = new Node(5);
            head241.Next.Next = new Node(8);
            head241.Next.Next.Next = new Node(5);
            head241.Next.Next.Next.Next = new Node(10);
            head241.Next.Next.Next.Next.Next = new Node(2);
            head241.Next.Next.Next.Next.Next.Next = new Node(1);
            Console.WriteLine($"Before Partition: {head241}");

            var newHead241 = PartitionLinkedList.Partition(head241, 5);
            Console.WriteLine($"After Partition: {newHead241}");

            // 2.4 Test Case 2
            var head242 = new Node(3);
            Console.WriteLine($"Before Partition: {head242}");

            var newHead242 = PartitionLinkedList.Partition(head242, 5);
            Console.WriteLine($"After Partition: {newHead242}");

            // 2.4 Test Case 3
            var head243 = new Node(5);
            Console.WriteLine($"Before Partition: {head243}");

            var newHead243 = PartitionLinkedList.Partition(head243, 5);
            Console.WriteLine($"After Partition: {newHead243}");

            // 2.4 Test Case 4
            var head244 = new Node(15);
            head244.Next = new Node(5);
            head244.Next.Next = new Node(3);
            head244.Next.Next.Next = new Node(4);
            head244.Next.Next.Next.Next = new Node(10);
            head244.Next.Next.Next.Next.Next = new Node(2);
            head244.Next.Next.Next.Next.Next.Next = new Node(1);
            Console.WriteLine($"Before Partition: {head244}");

            var newHead244 = PartitionLinkedList.Partition(head244, 5);
            Console.WriteLine($"After Partition: {newHead244}");

            // 2.4 Test Case 5
            Console.WriteLine($"Before Partition: null");

            var newHead245 = PartitionLinkedList.Partition(null, 5);
            string result245 = newHead245 == null ? "null" : newHead245.ToString();
            Console.WriteLine($"After Partition: {result245}");

            #endregion

            #region 2.5

            // 2.5 Test Case 1
            var head251_1 = new Node(7);
            head251_1.Next = new Node(1);
            head251_1.Next.Next = new Node(6);
            var head251_2 = new Node(5);
            head251_2.Next = new Node(9);
            head251_2.Next.Next = new Node(2);
            Console.WriteLine($"Operand 1: {head251_1}");
            Console.WriteLine($"Operand 2: {head251_2}");

            var sum251 = SumLinkedList.SumBackward(head251_1, head251_2);
            Console.WriteLine($"Sum List: {sum251}");

            // 2.5 Test Case 2
            var head252_1 = new Node(7);
            head252_1.Next = new Node(1);
            head252_1.Next.Next = new Node(6);
            head252_1.Next.Next.Next = new Node(3);
            var head252_2 = new Node(5);
            head252_2.Next = new Node(9);
            head252_2.Next.Next = new Node(5);
            Console.WriteLine($"Operand 1: {head252_1}");
            Console.WriteLine($"Operand 2: {head252_2}");

            var sum252 = SumLinkedList.SumBackward(head252_1, head252_2);
            Console.WriteLine($"Sum List: {sum252}");

            // 2.5 Test Case 3
            var head253_1 = new Node(7);
            head253_1.Next = new Node(1);
            head253_1.Next.Next = new Node(6);
            head253_1.Next.Next.Next = new Node(3);
            Console.WriteLine($"Operand 1: {head253_1}");
            Console.WriteLine($"Operand 2: null");

            var sum253 = SumLinkedList.SumBackward(head253_1, null);
            Console.WriteLine($"Sum List: {sum253}");

            // 2.5 Test Case 4
            Console.WriteLine($"Operand 1: null");
            Console.WriteLine($"Operand 2: null");

            var sum254 = SumLinkedList.SumBackward(null, null);
            string result254 = sum254 == null ? "null" : sum254.ToString();
            Console.WriteLine($"Sum List: {result254}");

            #endregion
        }
    }
}
