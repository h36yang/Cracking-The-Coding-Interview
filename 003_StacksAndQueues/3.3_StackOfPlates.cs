using System;
using System.Collections.Generic;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.3) Stack of Plates:
    /// Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
    /// Therefore, in real life, we would likely start a new stack when the previous stack exceeds some threshold.
    /// Implement a data structure SetOfStacks that mimics this.
    /// SetOfStacks should be composed of several stacks and should create a new stack once the previous one exceeds capacity.
    /// SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack (that is, pop() should return the same values as it would if there were just a single stack).
    /// FOLLOW UP
    /// Implement a function popAt(int index) which performs a pop operation on a specific sub-stack.
    /// </summary>
    public class Question_3_3
    {
        class StackNode
        {
            public int Data { get; set; }
            public StackNode Above { get; set; }
            public StackNode Below { get; set; }

            public StackNode(int data)
            {
                Data = data;
            }
        }

        class Stack
        {
            private readonly int _capacity;
            private int _size = 0;
            public StackNode Top { get; private set; }
            public StackNode Bottom { get; private set; }

            public Stack(int capacity)
            {
                _capacity = capacity;
            }

            public bool IsFull()
            {
                return _size == _capacity;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public void Push(int item)
            {
                if (IsFull())
                {
                    throw new ApplicationException("Stack is at capacity.");
                }

                if (IsEmpty())
                {
                    Top = new StackNode(item);
                    Bottom = Top;
                }
                else
                {
                    var newNode = new StackNode(item)
                    {
                        Below = Top
                    };
                    Top.Above = newNode;
                    Top = newNode;
                }
                _size++;
            }

            public int Pop()
            {
                if (IsEmpty())
                {
                    throw new ApplicationException("Stack is empty.");
                }

                int item = Top.Data;
                if (Top == Bottom)
                {
                    Top = null;
                    Bottom = null;
                }
                else
                {
                    StackNode temp = Top.Below;
                    Top.Below = null;
                    Top = temp;
                    Top.Above = null;
                }
                _size--;
                return item;
            }

            public int Peek()
            {
                if (IsEmpty())
                {
                    throw new ApplicationException("Stack is empty.");
                }
                return Top.Data;
            }

            public int PopBottom()
            {
                if (IsEmpty())
                {
                    throw new ApplicationException("Stack is empty.");
                }

                int item = Bottom.Data;
                if (Top == Bottom)
                {
                    Top = null;
                    Bottom = null;
                }
                else
                {
                    StackNode temp = Bottom.Above;
                    Bottom.Above = null;
                    Bottom = temp;
                    Bottom.Below = null;
                }
                _size--;
                return item;
            }
        }

        public class SetOfStacks
        {
            private const int DEFAULT_THRESHOLD = 10;

            private readonly List<Stack> _listOfStacks;
            private readonly int _threshold;

            public SetOfStacks() : this(DEFAULT_THRESHOLD) { }

            public SetOfStacks(int threshold)
            {
                _threshold = threshold;
                _listOfStacks = new List<Stack>();
            }

            public int PopAt(int index)
            {
                if (_listOfStacks.Count == 0)
                {
                    throw new ApplicationException("Stack is empty.");
                }

                if (index < 0 || index > _listOfStacks.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.", innerException: null);
                }

                Stack currStack = _listOfStacks[index];
                int item = currStack.Pop();
                for (int i = index + 1; i < _listOfStacks.Count; i++)
                {
                    int tempItem = _listOfStacks[i].PopBottom();
                    _listOfStacks[i - 1].Push(tempItem);

                    if (i == _listOfStacks.Count - 1 && _listOfStacks[i].IsEmpty())
                    {
                        _listOfStacks.RemoveAt(i);
                    }
                }
                return item;
            }

            public int Pop()
            {
                if (_listOfStacks.Count == 0)
                {
                    throw new ApplicationException("Stack is empty.");
                }

                Stack topStack = _listOfStacks[_listOfStacks.Count - 1];
                int item = topStack.Pop();
                if (topStack.IsEmpty())
                {
                    _listOfStacks.RemoveAt(_listOfStacks.Count - 1);
                }
                return item;
            }

            public void Push(int item)
            {
                Stack topStack;
                if (_listOfStacks.Count > 0 && !_listOfStacks[_listOfStacks.Count - 1].IsFull())
                {
                    topStack = _listOfStacks[_listOfStacks.Count - 1];
                    topStack.Push(item);
                }
                else
                {
                    topStack = new Stack(_threshold);
                    topStack.Push(item);
                    _listOfStacks.Add(topStack);
                }
            }
        }
    }
}
