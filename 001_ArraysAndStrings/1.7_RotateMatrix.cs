namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.7) Rotate Matrix:
    /// Given an image represented by an NxN matrix, where each pixel in the image is bytes, write a method to rotate the image by 90 degrees.
    /// Can you do this in place?
    /// </summary>
    public class Question_1_7
    {
        /// <summary>
        /// Given an image represented by an NxN matrix, where each pixel in the image is bytes, write a method to rotate the image by 90 degrees.
        /// <para>Time Complexity: O(N^2)</para>
        /// <para>Space Complexity: O(N^2)</para>
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        public static int[,] RotateMatrix(int[,] inputMatrix)
        {
            // assuming the matrix has same length in both dimensions
            int n = inputMatrix.GetLength(0);
            int[,] rotatedMatrix = new int[n, n];
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    // assuming clockwise rotation
                    rotatedMatrix[n - 1 - y, x] = inputMatrix[x, y];
                }
            }
            return rotatedMatrix;
        }

        /// <summary>
        /// Can you do this in place?
        /// <para>Time Complexity: O(N^2)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        public static int[,] RotateMatrixInplace(int[,] inputMatrix)
        {
            // assuming the matrix has same length in both dimensions
            int n = inputMatrix.GetLength(0);
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - layer - 1;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    // save the top element first
                    int top = inputMatrix[i, first];

                    // left -> top
                    inputMatrix[i, first] = inputMatrix[first, last - offset];

                    // bottom -> left
                    inputMatrix[first, last - offset] = inputMatrix[last - offset, last];

                    // right -> bottom
                    inputMatrix[last - offset, last] = inputMatrix[last, i];

                    // top -> right
                    inputMatrix[last, i] = top;
                }
            }
            return inputMatrix;
        }
    }
}
