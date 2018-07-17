using System.Collections.Generic;

namespace TreeAndGraphApp
{
    public static class SequenceBinarySearchTree
    {
        public static List<LinkedList<int>> AllSequences(TreeNode<int> node)
        {
            var results = new List<LinkedList<int>>();
            if (node == null)
            {
                results.Add(new LinkedList<int>());
                return results;
            }

            var prefix = new LinkedList<int>();
            prefix.AddFirst(node.Data);

            List<LinkedList<int>> leftSeq = AllSequences(node.Left);
            List<LinkedList<int>> rightSeq = AllSequences(node.Right);

            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    var weaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    results.AddRange(weaved);
                }
            }
            return results;
        }

        private static void WeaveLists(LinkedList<int> first, LinkedList<int> second,
            List<LinkedList<int>> results, LinkedList<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> copyPrefix = Clone(prefix);
                copyPrefix = Merge(copyPrefix, first);
                copyPrefix = Merge(copyPrefix, second);
                results.Add(copyPrefix);
                return;
            }

            int headFirst = first.First.Value;
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            int headSecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            WeaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }

        private static LinkedList<int> Clone(LinkedList<int> original)
        {
            var copy = new LinkedList<int>();
            copy.AddFirst(new LinkedListNode<int>(original.First.Value));
            LinkedListNode<int> orignalNode = original.First;
            LinkedListNode<int> copyNode = copy.First;
            while (orignalNode.Next != null)
            {
                copy.AddAfter(copyNode, orignalNode.Next.Value);
                copyNode = copyNode.Next;
                orignalNode = orignalNode.Next;
            }
            return copy;
        }

        private static LinkedList<int> Merge(LinkedList<int> first, LinkedList<int> second)
        {
            if (second == null || second.Count == 0)
            {
                return first;
            }
            else if (first == null || first.Count == 0)
            {
                return second;
            }

            var node = second.First;
            while (node != null)
            {
                first.AddLast(node.Value);
                node = node.Next;
            }
            return first;
        }
    }
}
