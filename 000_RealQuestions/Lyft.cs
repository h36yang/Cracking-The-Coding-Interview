using System;

namespace _000_RealQuestions
{
    public static class Lyft
    {
        #region Intersection Iterator

        /// <summary>
        /// Given two sorted iterators. Implement IntersectionIterator which returns only common elements in both iterators.
        /// </summary>
        public class IntersectionIterator
        {
            private readonly int[] _arr1;
            private readonly int[] _arr2;
            private int _i1 = 0;
            private int _i2 = 0;

            public IntersectionIterator(int[] arr1, int[] arr2)
            {
                _arr1 = arr1;
                _arr2 = arr2;
                MoveToNextItem();
            }

            private void MoveToNextItem()
            {
                while (_i1 < _arr1.Length && _i2 < _arr2.Length && _arr1[_i1] != _arr2[_i2])
                {
                    if (_arr1[_i1] < _arr2[_i2])
                    {
                        _i1++;
                    }
                    else
                    {
                        _i2++;
                    }
                }
            }

            /// <summary>
            /// Returns the next element in the iteration (common element in the two iterators).
            /// </summary>
            /// <returns></returns>
            public bool HasNext()
            {
                return _i1 < _arr1.Length && _i2 < _arr2.Length;
            }

            /// <summary>
            /// Returns true if the iteration has more elements (common elements in the two interators).
            /// </summary>
            /// <returns></returns>
            public int Next()
            {
                if (_i1 >= _arr1.Length || _i2 >= _arr2.Length)
                {
                    throw new InvalidOperationException("No next item");
                }

                int item = _arr1[_i1];
                _i1++;
                _i2++;
                MoveToNextItem();
                return item;
            }
        }

        #endregion
    }
}
