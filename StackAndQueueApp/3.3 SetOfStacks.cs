using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackAndQueueApp
{
    public class SetOfStacks<T>
    {
        private int _capacity;
        private List<Stack<T>> _stackList;
        private int _counter;

        public SetOfStacks(int capacity)
        {
            this._capacity = capacity;
            this._counter = capacity - 1;
            this._stackList = new List<Stack<T>>();
        }

        public void Push(T item)
        {
            if (_counter < _capacity - 1)
            {
                var temp = _stackList[_stackList.Count - 1];
                temp.Push(item);
                _stackList[_stackList.Count - 1] = temp;
                _counter++;
            }
            else
            {
                var temp = new Stack<T>();
                temp.Push(item);
                _stackList.Add(temp);
                _counter = 0;
            }
        }

        public T Pop()
        {
            int count = _stackList.Count;
            var temp = _stackList[count - 1];
            T item = temp.Pop();
            if (temp.IsEmpty())
            {
                _stackList.RemoveAt(count - 1);
                _counter = _capacity - 1;
            }
            else
            {
                _stackList[count - 1] = temp;
                _counter--;
            }
            return item;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < _stackList.Count; i++)
            {
                stringBuilder.Append(i + 1).Append(") ");
                stringBuilder.AppendLine(_stackList[i].ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
