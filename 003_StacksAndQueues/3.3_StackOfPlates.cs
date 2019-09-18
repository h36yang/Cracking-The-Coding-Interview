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
        public class SetOfStacks<T>
        {
            private const int DEFAULT_THRESHOLD = 10;

            private readonly Stack<Stack<T>> _setOfStacks;
            private readonly int _threshold;

            public SetOfStacks() : this(DEFAULT_THRESHOLD) { }

            public SetOfStacks(int threshold)
            {
                _threshold = threshold;
                _setOfStacks = new Stack<Stack<T>>();
            }

            public T Pop()
            {
                if (_setOfStacks.Count == 0)
                {
                    throw new ArgumentNullException("Stack is empty.", innerException: null);
                }

                Stack<T> topStack = _setOfStacks.Pop();
                T item = topStack.Pop();
                if (topStack.Count > 0)
                {
                    _setOfStacks.Push(topStack);
                }
                return item;
            }

            public void Push(T item)
            {
                Stack<T> topStack = (_setOfStacks.Count > 0 && _setOfStacks.Peek().Count < _threshold) ? _setOfStacks.Pop() : new Stack<T>();
                topStack.Push(item);
                _setOfStacks.Push(topStack);
            }
        }
    }
}
