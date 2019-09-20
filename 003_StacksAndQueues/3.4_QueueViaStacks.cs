using System;
using System.Collections.Generic;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.4) Queue via Stacks:
    /// Implement a MyQueue class which implements a queue using two stacks.
    /// </summary>
    public class Question_3_4
    {
        public class MyQueue<T>
        {
            /// <summary>
            /// Stack with first item on top
            /// </summary>
            private readonly Stack<T> _stackFirst;

            /// <summary>
            /// Stack with last item on top
            /// </summary>
            private readonly Stack<T> _stackLast;

            public MyQueue()
            {
                _stackFirst = new Stack<T>();
                _stackLast = new Stack<T>();
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public bool IsEmpty()
            {
                return (_stackFirst.Count == 0 && _stackLast.Count == 0);
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public T Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty.");
                }

                // Move everything to the stack with first item on top - O(n)
                while (_stackLast.Count > 0)
                {
                    _stackFirst.Push(_stackLast.Pop());
                }
                return _stackFirst.Peek();
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public T Remove()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty.");
                }

                // Move everything to the stack with first item on top - O(n)
                while (_stackLast.Count > 0)
                {
                    _stackFirst.Push(_stackLast.Pop());
                }
                return _stackFirst.Pop();
            }

            /// <summary>
            /// Runtime O(n)
            /// </summary>
            /// <param name="item"></param>
            public void Add(T item)
            {
                // Move everything to the stack with last item on top - O(n)
                while (_stackFirst.Count > 0)
                {
                    _stackLast.Push(_stackFirst.Pop());
                }
                _stackLast.Push(item);
            }
        }
    }
}
