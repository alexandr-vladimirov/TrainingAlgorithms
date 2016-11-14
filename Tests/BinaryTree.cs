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
            if (root == null)
                return result;

            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            do
            {
                var node = queue.Dequeue();
                result.Add(node.Value);

                if (node.Right != null)
                    queue.Enqueue(node.Right);

                if (node.Left != null)
                    queue.Enqueue(node.Left);
            } while (queue.Count > 0);

            result.Reverse();
            return result;
        }
    }
}
