using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TreeTraverseTest
    {
        [Test]
        public void EmptyTree()
        {
            var tree = new BinaryTree(null);
            Assert.IsEmpty(tree.Traverse());
        }

        [Test]
        public void TreeWithOneNode()
        {
            var tree = new BinaryTree(new BinaryTreeNode { Value = 1 });
            CollectionAssert.AreEqual(new[] { 1 }, tree.Traverse());
        }

        [Test]
        public void ThreeLevels()
        {
            var root = new BinaryTreeNode { Value = 1 };
            root.Left = new BinaryTreeNode { Value = 2 };
            root.Right = new BinaryTreeNode { Value = 3 };
            root.Left.Left = new BinaryTreeNode { Value = 4 };
            root.Left.Right = new BinaryTreeNode { Value = 5 };
            root.Right.Left = new BinaryTreeNode { Value = 6 };
            root.Right.Right = new BinaryTreeNode { Value = 7 };
            var tree = new BinaryTree(root);
            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7, 2, 3, 1 }, tree.Traverse());
        }
        [Test]
        public void NotBalancedTree()
        {
            var root = new BinaryTreeNode { Value = 1 };
            root.Left = new BinaryTreeNode { Value = 2 };
            root.Right = new BinaryTreeNode { Value = 3 };
            root.Left.Left = new BinaryTreeNode { Value = 4 };
            root.Right.Right = new BinaryTreeNode { Value = 7 };
            var tree = new BinaryTree(root);
            CollectionAssert.AreEqual(new[] { 4, 7, 2, 3, 1 }, tree.Traverse());
        }
    }
}
