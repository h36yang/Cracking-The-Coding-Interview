using System.Collections.Generic;

namespace _003_StacksAndQueuesTest
{
    public class TestHelper
    {
        public static Stack<T> ConvertArrayToStack<T>(T[] array)
        {
            var stack = new Stack<T>();
            foreach (T item in array)
            {
                stack.Push(item);
            }
            return stack;
        }
    }
}
