using System;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.14) Boolean Evaluation:
    /// Given a boolean expression consisting of the symbols 0 (false), 1 (true), & (AND), | (OR), and ^ (XOR), and a desired boolean result value result,
    /// implement a function to count the number of ways of parenthesizing the expression such that it evaluates to result.
    /// </summary>
    public static class Question_8_14
    {
        /// <summary>
        /// Using Pure Recursion
        /// <para>Time Complexity: O()</para>
        /// <para>Space Complexity: O()</para>
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static int CountEvalRecursion(string expression, bool expectedResult)
        {
            if (string.IsNullOrEmpty(expression))
            {
                // Invalid Cases
                return 0;
            }

            if (expression.Length == 1)
            {
                // Base Case
                bool result = "1".Equals(expression);
                return expectedResult.Equals(result) ? 1 : 0;
            }

            int count = 0;
            // Iterate through the operators and divide the expression into 2 parts - runtime O(p)
            for (int i = 1; i < expression.Length; i += 2)
            {
                // Substring operations are O(n) runtime in total
                string leftExp = expression.Substring(0, i);
                string rightExp = expression.Substring(i + 1);

                // Largest recursion depth O(p)
                count += Evaluate(leftExp, rightExp, expression[i], expectedResult);
            }
            return count;
        }

        /// <summary>
        /// Using Memoization
        /// <para>Time Complexity: O()</para>
        /// <para>Space Complexity: O()</para>
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public static int CountEvalMemoization(string expression, bool expectedResult)
        {
            var memo = new Dictionary<(string, bool), int>();
            return CountEvalMemoization(expression, expectedResult, memo);
        }

        private static int CountEvalMemoization(string expression, bool expectedResult, Dictionary<(string, bool), int> memo)
        {
            if (string.IsNullOrEmpty(expression))
            {
                // Invalid Cases
                return 0;
            }

            if (expression.Length == 1)
            {
                // Base Case
                bool result = "1".Equals(expression);
                return expectedResult.Equals(result) ? 1 : 0;
            }

            if (memo.ContainsKey((expression, expectedResult)))
            {
                return memo[(expression, expectedResult)];
            }

            int count = 0;
            // Iterate through the operators and divide the expression into 2 parts - runtime O(p)
            for (int i = 1; i < expression.Length; i += 2)
            {
                // Substring operations are O(n) runtime in total
                string leftExp = expression.Substring(0, i);
                string rightExp = expression.Substring(i + 1);

                // Largest recursion depth O(p)
                count += Evaluate(leftExp, rightExp, expression[i], expectedResult, memo);
            }

            // Cache result before returning
            memo.Add((expression, expectedResult), count);
            return count;
        }

        private static int Evaluate(string leftExp, string rightExp, char op, bool expectedResult)
        {
            int leftTrue = CountEvalRecursion(leftExp, true);
            int leftFalse = CountEvalRecursion(leftExp, false);
            int rightTrue = CountEvalRecursion(rightExp, true);
            int rightFalse = CountEvalRecursion(rightExp, false);
            if (expectedResult)
            {
                return op switch
                {
                    '&' => leftTrue * rightTrue,
                    '|' => leftTrue * rightTrue + leftTrue * rightFalse + leftFalse * rightTrue,
                    '^' => leftTrue * rightFalse + leftFalse * rightTrue,
                    _ => throw new InvalidOperationException($"Operator {op} is not one of '&', '|', and '^'."),
                };
            }
            else
            {
                return op switch
                {
                    '&' => leftFalse * rightFalse + leftTrue * rightFalse + leftFalse * rightTrue,
                    '|' => leftFalse * rightFalse,
                    '^' => leftTrue * rightTrue + leftFalse * rightFalse,
                    _ => throw new InvalidOperationException($"Operator {op} is not one of '&', '|', and '^'."),
                };
            }
        }

        private static int Evaluate(string leftExp, string rightExp, char op, bool expectedResult, Dictionary<(string, bool), int> memo)
        {
            int leftTrue = CountEvalMemoization(leftExp, true, memo);
            int leftFalse = CountEvalMemoization(leftExp, false, memo);
            int rightTrue = CountEvalMemoization(rightExp, true, memo);
            int rightFalse = CountEvalMemoization(rightExp, false, memo);
            if (expectedResult)
            {
                return op switch
                {
                    '&' => leftTrue * rightTrue,
                    '|' => leftTrue * rightTrue + leftTrue * rightFalse + leftFalse * rightTrue,
                    '^' => leftTrue * rightFalse + leftFalse * rightTrue,
                    _ => throw new InvalidOperationException($"Operator {op} is not one of '&', '|', and '^'."),
                };
            }
            else
            {
                return op switch
                {
                    '&' => leftFalse * rightFalse + leftTrue * rightFalse + leftFalse * rightTrue,
                    '|' => leftFalse * rightFalse,
                    '^' => leftTrue * rightTrue + leftFalse * rightFalse,
                    _ => throw new InvalidOperationException($"Operator {op} is not one of '&', '|', and '^'."),
                };
            }
        }
    }
}
