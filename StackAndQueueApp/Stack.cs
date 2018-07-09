using System;
using System.Text;

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

        public bool IsEmpty() => _top == null;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(_top);
            var node = _top.Next;
            while (node != null)
            {
                stringBuilder.Append(" --> ");
                stringBuilder.Append(node);
                node = node.Next;
            }
            return stringBuilder.ToString();
        }
    }

    public class StackNode<T>
    {
        public StackNode<T> Next { get; set; }
        public T Data { get; private set; }

        public StackNode(T data) => this.Data = data;

        public override string ToString() => $"{Data}";
    }
}
