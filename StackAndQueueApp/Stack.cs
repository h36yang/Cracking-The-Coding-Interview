using System;

namespace StackAndQueueApp
{
    public class Stack<T>
    {
        private StackNode<T> _top;

        public T Pop()
        {
            if (_top == null)
            {
                throw new Exception("Stack is empty.");
            }

            T item = _top.Data;
            _top = _top.Next;
            return item;
        }

        public void Push(T item)
        {
            var temp = new StackNode<T>(item);
            temp.Next = _top;
            _top = temp;
        }

        public T Peek()
        {
            if (_top == null)
            {
                throw new Exception("Stack is empty.");
            }
            return _top.Data;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }
    }

    public class StackNode<T>
    {
        public StackNode<T> Next { get; set; }
        public T Data { get; private set; }

        public StackNode(T data)
        {
            this.Data = data;
        }
    }
}
