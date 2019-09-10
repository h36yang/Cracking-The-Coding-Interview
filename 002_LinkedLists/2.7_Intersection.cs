using System;

namespace _002_LinkedLists
{
    /// <summary>
    /// 2.7) Intersection:
    /// Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting node.
    /// Note that the intersection is defined based on reference, not value.
    /// That is, if the kth node of the first linked list is the exact same node (by reference) as the jth node of the second linked list, then they are intersecting.
    /// </summary>
    public class Question_2_7
    {
        /// <summary>
        /// Two intersecting singly linked list must share the same tail
        /// Loop to the tails of both lists and check if they are the same node
        /// <para>Time Complexity: O(m + n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static Node FindIntersection(LinkedList list1, LinkedList list2)
        {
            if (!Helper.IsValidList(list1) || !Helper.IsValidList(list2))
            {
                return null;
            }

            // find the tails of both lists - time O(m + n)
            (int length1, Node tail1) = list1.GetLengthAndTail();
            (int length2, Node tail2) = list2.GetLengthAndTail();

            if (tail1 != tail2)
            {
                // if lists are not intersecting, return null
                return null;
            }

            LinkedList longerList = (length1 > length2) ? list1 : list2;
            LinkedList shorterList = (length1 > length2) ? list2 : list1;
            Node longer = longerList.Head;
            Node shorter = shorterList.Head;
            // catch up shorter list with the longer list
            int lengthDiff = Math.Abs(length1 - length2);
            for (int i = 0; i < lengthDiff; i++)
            {
                longer = longer.Next;
            }

            // loop through the rest of the lists to compare each node - time O(n)
            while (longer != shorter)
            {
                longer = longer.Next;
                shorter = shorter.Next;
            }
            return longer;
        }
    }
}
