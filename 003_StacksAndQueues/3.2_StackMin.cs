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
        /// <summary>
        /// Keeping a local min within each stack node to keep track
        /// </summary>
        public class MinStack
        {
            private class StackNode
            {
                public int Data { get; private set; }

                public int LocalMin { get; private set; }

                public StackNode Below { get; set; }

                public StackNode(int data, int localMin)
                {
                    Data = data;
                    LocalMin = localMin;
                }
            }

            private StackNode _top;

            public int Pop()
            {
                if (_top == null)
                {
                    throw new ApplicationException("Stack is empty.");
                }
                int item = _top.Data;
                _top = _top.Below;
                return item;
            }

            public void Push(int item)
            {
                int min = (_top == null) ? item : Math.Min(item, _top.LocalMin);
                var node = new StackNode(item, min)
                {
                    Below = _top
                };
                _top = node;
            }

            public int Min()
            {
                if (_top == null)
                {
                    throw new ApplicationException("Stack is empty.");
                }
                return _top.LocalMin;
            }
        }

        /// <summary>
        /// Having a separate stack to track the min values - more optimized for larger number of nodes
        /// </summary>
        public class MinStackOptimized
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

            private readonly Stack<int> _minStack = new Stack<int>();

            public int Pop()
            {
                if (_top == null)
                {
                    throw new ApplicationException("Stack is empty.");
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
                    throw new ApplicationException("Stack is empty.");
                }
                return _minStack.Peek();
            }
        }
    }
}
