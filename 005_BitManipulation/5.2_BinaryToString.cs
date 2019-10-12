using System.Text;

namespace _005_BitManipulation
{
    /// <summary>
    /// 5.2) Binary to String:
    /// Given a real number between 0 and 1 (e.g. 0.72) that is passed in as a double, print the binary representation.
    /// If the number cannot be represented accurately in binary with at most 32 characters, print "ERROR."
    /// </summary>
    public static class Question_5_2
    {
        /// <summary>
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string BinaryToString(double number)
        {
            if (number >= 1 || number <= 0)
            {
                return "ERROR";
            }

            var binary = new StringBuilder();
            binary.Append(".");
            while (number > 0d)
            {
                if (binary.Length >= 32)
                {
                    return "ERROR";
                }

                number *= 2;
                if (number >= 1)
                {
                    binary.Append(1);
                    number -= 1;
                }
                else
                {
                    binary.Append(0);
                }
            }
            return binary.ToString();
        }
    }
}
