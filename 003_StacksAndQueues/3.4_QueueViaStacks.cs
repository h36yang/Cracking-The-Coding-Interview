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
            private readonly Stack<T> _queue;
            private readonly Stack<T> _buffer;

            public MyQueue()
            {
                _queue = new Stack<T>();
                _buffer = new Stack<T>();
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <returns></returns>
            public bool IsEmpty()
            {
                return _queue.Count == 0;
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
                return _queue.Peek();
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
                return _queue.Pop();
            }

            /// <summary>
            /// Runtime O(n)
            /// </summary>
            /// <param name="item"></param>
            public void Add(T item)
            {
                // Move all items from Queue stack to Buffer stack - O(n)
                while (_queue.Count > 0)
                {
                    _buffer.Push(_queue.Pop());
                }

                // Push the new item to Queue stack
                _queue.Push(item);

                // Move everything back from Buffer stack to Queue stack - O(n)
                while (_buffer.Count > 0)
                {
                    _queue.Push(_buffer.Pop());
                }
            }
        }
    }
}
