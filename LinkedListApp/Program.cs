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

            #region 2.6

            // 2.6 Test Case 1
            var head261 = new Node(1);
            head261.Next = new Node(2);
            head261.Next.Next = new Node(3);
            head261.Next.Next.Next = new Node(4);
            head261.Next.Next.Next.Next = new Node(3);
            head261.Next.Next.Next.Next.Next = new Node(2);
            head261.Next.Next.Next.Next.Next.Next = new Node(1);
            Console.WriteLine($"Linked List: {head261}");

            bool result261 = PalindromeLinkedList.IsPalindrome(head261);
            Console.WriteLine($" is Palindrome? {result261}");

            // 2.6 Test Case 2
            var head262 = new Node(1);
            head262.Next = new Node(2);
            head262.Next.Next = new Node(3);
            head262.Next.Next.Next = new Node(4);
            head262.Next.Next.Next.Next = new Node(5);
            head262.Next.Next.Next.Next.Next = new Node(2);
            head262.Next.Next.Next.Next.Next.Next = new Node(1);
            Console.WriteLine($"Linked List: {head262}");

            bool result262 = PalindromeLinkedList.IsPalindrome(head262);
            Console.WriteLine($" is Palindrome? {result262}");

            #endregion

            #region 2.7

            // 2.7 Test Case 1
            var head271_1 = new Node(1);
            head271_1.Next = new Node(2);
            head271_1.Next.Next = new Node(3);
            head271_1.Next.Next.Next = new Node(4);
            head271_1.Next.Next.Next.Next = new Node(5);
            head271_1.Next.Next.Next.Next.Next = new Node(6);
            head271_1.Next.Next.Next.Next.Next.Next = new Node(7);
            var head271_2 = new Node(10);
            head271_2.Next = new Node(9);
            head271_2.Next.Next = new Node(8);
            head271_2.Next.Next.Next = head271_1.Next.Next.Next.Next.Next.Next;
            Console.WriteLine($"List 1: {head271_1}");
            Console.WriteLine($"List 2: {head271_2}");

            var newHead271 = IntersectingLinkedList.Intersection(head271_1, head271_2);
            Console.WriteLine($"Intersection: {newHead271}");

            // 2.7 Test Case 2
            var head272_1 = new Node(1);
            head272_1.Next = new Node(2);
            head272_1.Next.Next = new Node(3);
            head272_1.Next.Next.Next = new Node(4);
            head272_1.Next.Next.Next.Next = new Node(5);
            head272_1.Next.Next.Next.Next.Next = new Node(6);
            head272_1.Next.Next.Next.Next.Next.Next = new Node(7);
            var head272_2 = new Node(10);
            head272_2.Next = new Node(9);
            head272_2.Next.Next = new Node(8);
            head272_2.Next.Next.Next = new Node(7);
            Console.WriteLine($"List 1: {head272_1}");
            Console.WriteLine($"List 2: {head272_2}");

            var newHead272 = IntersectingLinkedList.Intersection(head272_1, head272_2);
            string result272 = newHead272 == null ? "does not exist" : newHead272.ToString();
            Console.WriteLine($"Intersection: {result272}");

            // 2.7 Test Case 3
            var head273_1 = new Node(1);
            head273_1.Next = new Node(2);
            head273_1.Next.Next = new Node(3);
            head273_1.Next.Next.Next = new Node(4);
            head273_1.Next.Next.Next.Next = new Node(5);
            head273_1.Next.Next.Next.Next.Next = new Node(6);
            head273_1.Next.Next.Next.Next.Next.Next = new Node(7);
            var head273_2 = new Node(10);
            head273_2.Next = new Node(9);
            head273_2.Next.Next = new Node(8);
            head273_2.Next.Next.Next = head273_1.Next.Next.Next.Next;
            Console.WriteLine($"List 1: {head273_1}");
            Console.WriteLine($"List 2: {head273_2}");

            var newHead273_1 = IntersectingLinkedList.Intersection(head273_1, head273_2);
            Console.WriteLine($"Intersection: {newHead273_1}");
            var newHead273_2 = IntersectingLinkedList.Intersection(head273_2, head273_1);
            Console.WriteLine($"Intersection: {newHead273_2}");

            #endregion

            #region 2.8

            // 2.8 Test Case 1
            var head281 = new Node(3);
            head281.Next = new Node(5);
            head281.Next.Next = new Node(8);
            head281.Next.Next.Next = new Node(5);
            head281.Next.Next.Next.Next = new Node(10);
            head281.Next.Next.Next.Next.Next = new Node(2);
            head281.Next.Next.Next.Next.Next.Next = new Node(1);
            var node281 = CircularLinkedList.GetLoopStartsAt(head281);
            if (node281 == null)
            {
                Console.WriteLine($"No loop detected.");
            }
            else
            {
                Console.WriteLine($"Loop starts at node {node281.Data}");
            }

            // 2.8 Test Case 2
            var head282 = new Node(3);
            head282.Next = new Node(5);
            head282.Next.Next = new Node(8);
            head282.Next.Next.Next = new Node(5);
            head282.Next.Next.Next.Next = new Node(10);
            head282.Next.Next.Next.Next.Next = new Node(2);
            head282.Next.Next.Next.Next.Next.Next = head282.Next.Next.Next;
            var node282 = CircularLinkedList.GetLoopStartsAt(head282);
            if (node282 == null)
            {
                Console.WriteLine($"No loop detected.");
            }
            else
            {
                Console.WriteLine($"Loop starts at node {node282.Data}");
            }

            #endregion
        }
    }
}
