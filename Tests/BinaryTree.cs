using System.Collections.Generic;

namespace Tests
{
    public class BinaryTreeNode
    {
        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
    }

    public class BinaryTree
    {
        private BinaryTreeNode root;

        public BinaryTree(BinaryTreeNode root)
        {
            this.root = root;
        }

        public bool IsSearchTree()
        {
            return IsSearchTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsSearchTree(BinaryTreeNode node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Value < min || node.Value > max)
                return false;

            return IsSearchTree(node.Left, min, node.Value) &&
                   IsSearchTree(node.Right, node.Value, max);
        }

        public List<int> Traverse()
        {
            var result = new List<int>();
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            do
            {
                var node = queue.Dequeue();
                if (node == null)
                    continue;
                result.Add(node.Value);
                queue.Enqueue(node.Right);
                queue.Enqueue(node.Left);
            } while (queue.Count > 0);

            result.Reverse();
            return result;
        }
    }
}
