using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.9) Parens:
    /// Implement an algorithm to print all valid (e.g. properly opened and closed) combinations of n pairs of parentheses.
    /// </summary>
    public static class Question_8_9
    {
        /// <summary>
        /// Recursively build up strings of parenthesis combos
        /// <para>Time Complexity: O(n * 2^n) where n is number of pairs of parentheses</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GenerateAllParenthesisCombos(int nPairs)
        {
            if (nPairs < 0)
            {
                return null;
            }

            var combos = new List<string>();
            if (nPairs > 0)
            {
                var str = new char[nPairs * 2];
                ConstructParenthesisCombos(combos, nPairs, nPairs, str, 0);
            }
            return combos;
        }

        private static void ConstructParenthesisCombos(List<string> combos, int nOpen, int nClose, char[] str, int index)
        {
            if (nOpen < 0 || nClose < nOpen)
            {
                return; // invalid state - do nothing
            }

            if (nOpen == 0 && nClose == 0)
            {
                // Base case - create new string from char[] and add to combos - runtime O(n)
                combos.Add(new string(str));
            }
            else
            {
                str[index] = '(';
                ConstructParenthesisCombos(combos, nOpen - 1, nClose, str, index + 1); // recursion depth 2n

                str[index] = ')';
                ConstructParenthesisCombos(combos, nOpen, nClose - 1, str, index + 1); // recursion depth 2n
            }
        }
    }
}
