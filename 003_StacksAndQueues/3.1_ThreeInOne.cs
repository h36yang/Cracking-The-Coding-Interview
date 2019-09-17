using System;

namespace _003_StacksAndQueues
{
    /// <summary>
    /// 3.1) Three in One:
    /// Describe how you could use a single array to implement three stacks.
    /// </summary>
    public class Question_3_1
    {
        public class ThreeInOneStacks<T> where T : struct
        {
            private const int DEFAULT_INIT_CAPACITY = 3;

            private T?[] _threeStacks;

            private readonly (int bottomIndex, int topIndex)[] _threeStacksIndexes;

            public ThreeInOneStacks() : this(DEFAULT_INIT_CAPACITY) { }

            public ThreeInOneStacks(int initCapacity)
            {
                _threeStacks = new T?[initCapacity >= DEFAULT_INIT_CAPACITY ? initCapacity : DEFAULT_INIT_CAPACITY];
                _threeStacksIndexes = new (int, int)[3] { (0, 0), (1, 1), (2, 2) };
            }

            public T? Pop(int stackNumber)
            {
                ValidateStackNumber(stackNumber);

                // retrieve top item from stack
                int currTopIndex = _threeStacksIndexes[stackNumber - 1].topIndex;
                T? item = _threeStacks[currTopIndex];
                // return null directly if stack is empty
                if (item == null)
                {
                    return null;
                }

                // decrement current top index if item not null - time O(1)
                _threeStacks[currTopIndex] = null;
                currTopIndex--;
                _threeStacksIndexes[stackNumber - 1].topIndex = currTopIndex;

                // shift all elements after the current top index to the left by one - time O(n)
                ShiftLaterItemsToLeft(stackNumber);

                return item;
            }

            public void Push(T item, int stackNumber)
            {
                ValidateStackNumber(stackNumber);

                // if reached capacity, double it - time O(n)
                int stack3TopIndex = _threeStacksIndexes[2].topIndex;
                if (stack3TopIndex >= _threeStacks.Length - 1)
                {
                    DoubleCapacity();
                }

                // shift all elements after the current top index to the right by one - time O(n)
                ShiftLaterItemsToRight(stackNumber);

                // push the current item onto the stack - time O(1)
                int currTopIndex = _threeStacksIndexes[stackNumber - 1].topIndex;
                currTopIndex++;
                _threeStacks[currTopIndex] = item;
                _threeStacksIndexes[stackNumber - 1].topIndex = currTopIndex;
            }

            public T? Peek(int stackNumber)
            {
                ValidateStackNumber(stackNumber);
                int topIndex = _threeStacksIndexes[stackNumber - 1].topIndex;
                return _threeStacks[topIndex];
            }

            public bool IsEmpty(int stackNumber)
            {
                ValidateStackNumber(stackNumber);
                int topIndex = _threeStacksIndexes[stackNumber - 1].topIndex;
                return _threeStacks[topIndex] == null;
            }

            private void ValidateStackNumber(int stackNumber)
            {
                if (stackNumber < 1 || stackNumber > 3)
                {
                    throw new ArgumentOutOfRangeException($"Invalid stack number {stackNumber} passed in.");
                }
            }

            private void ShiftLaterItemsToRight(int stackNumber)
            {
                // shift items - time O(n)
                int startIndex = _threeStacksIndexes[stackNumber - 1].topIndex + 1;
                int endIndex = _threeStacksIndexes[2].topIndex;
                for (int i = endIndex; i >= startIndex; i--)
                {
                    _threeStacks[i + 1] = _threeStacks[i];
                    _threeStacks[i] = null;
                }

                // increment indexes - time O(1)
                for (int x = stackNumber; x < 3; x++)
                {
                    _threeStacksIndexes[x].bottomIndex++;
                    _threeStacksIndexes[x].topIndex++;
                }
            }

            private void ShiftLaterItemsToLeft(int stackNumber)
            {
                // shift items - time O(n)
                int startIndex = _threeStacksIndexes[stackNumber - 1].topIndex + 2;
                int endIndex = _threeStacksIndexes[2].topIndex;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    _threeStacks[i - 1] = _threeStacks[i];
                    _threeStacks[i] = null;
                }

                // decrement indexes - time O(1)
                for (int x = stackNumber; x < 3; x++)
                {
                    _threeStacksIndexes[x].bottomIndex--;
                    _threeStacksIndexes[x].topIndex--;
                }
            }

            private void DoubleCapacity()
            {
                T?[] tempArray = _threeStacks;
                _threeStacks = new T?[tempArray.Length * 2];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    _threeStacks[i] = tempArray[i];
                }
            }
        }
    }
}
