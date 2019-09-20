using System;
using System.Collections.Generic;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.5) Sort Stack:
    /// Write a program to sort a stack such that the smallest items are on the top.
    /// You can use an additional temporary stack, but you may not copy the elements into any other data structure (such as an array).
    /// The stack supports the following operations: push, pop, peek, and isEmpty.
    /// </summary>
    public class Question_3_5
    {
        /// <summary>
        /// Use another stack to sort the items in nested loop
        /// <para>Time Complexity: O(n^2)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="inputStack"></param>
        /// <returns></returns>
        public static Stack<int> SortStack(Stack<int> inputStack)
        {
            if (inputStack.Count <= 1)
            {
                return inputStack;
            }

            var resultStack = new Stack<int>();
            while (inputStack.Count > 0)
            {
                int currItem = inputStack.Pop();
                while (resultStack.Count > 0 && resultStack.Peek() < currItem)
                {
                    inputStack.Push(resultStack.Pop());
                }
                resultStack.Push(currItem);
            }
            return resultStack;
        }
    }
}
