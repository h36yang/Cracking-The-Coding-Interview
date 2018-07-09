using System;

namespace StackAndQueueApp
{
    public class Queue<T>
    {
        private QueueNode<T> _first;
        private QueueNode<T> _last;

        public void Add(T item)
        {
            var temp = new QueueNode<T>(item);
            if (_last != null)
            {
                _last.Next = temp;
            }
            _last = temp;
            if (_first == null)
            {
                _first = _last;
            }
        }

        public T Remove()
        {
            if (_first == null)
            {
                throw new Exception("Queue is empty.");
            }

            T item = _first.Data;
            _first = _first.Next;
            if (_first == null)
            {
                _last = null;
            }
            return item;
        }

        public T Peek()
        {
            if (_first == null)
            {
                throw new Exception("Queue is empty.");
            }
            return _first.Data;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }
    }

    public class QueueNode<T>
    {
        public QueueNode<T> Next { get; set; }
        public T Data { get; private set; }

        public QueueNode(T data)
        {
            this.Data = data;
        }
    }
}
