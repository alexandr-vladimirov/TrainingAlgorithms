using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
