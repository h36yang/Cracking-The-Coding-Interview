using System;
using System.Collections.Generic;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.2) Stack Min:
    /// How would you design a stack which, in addition to push and pop, has a function min which returns the minimum element?
    /// Push, pop and min should all operate in 0(1) time.
    /// </summary>
    public class Question_3_2
    {
        public class MinStack
        {
            private class StackNode
            {
                public int Data { get; private set; }

                public StackNode Below { get; set; }

                public StackNode(int data)
                {
                    Data = data;
                }
            }

            private StackNode _top;

            private Stack<int> _minStack = new Stack<int>();

            public int Pop()
            {
                if (_top == null)
                {
                    throw new ArgumentNullException("Stack is empty.", innerException: null);
                }
                int item = _top.Data;
                _top = _top.Below;

                if (item == _minStack.Peek())
                {
                    _minStack.Pop();
                }
                return item;
            }

            public void Push(int item)
            {
                var node = new StackNode(item)
                {
                    Below = _top
                };
                _top = node;

                if (_minStack.Count == 0 || item <= _minStack.Peek())
                {
                    _minStack.Push(item);
                }
            }

            public int Min()
            {
                if (_minStack.Count == 0)
                {
                    throw new ArgumentNullException("Stack is empty.", innerException: null);
                }
                return _minStack.Peek();
            }
        }
    }
}
