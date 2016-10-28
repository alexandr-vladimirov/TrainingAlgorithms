using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IsSearchBinaryTreeTest
    {
        [Test]
        public void EmptyTree()
        {
            var tree = new BinaryTree(null);
            Assert.IsTrue(tree.IsSearchTree());
        }

        [Test]
        public void TreeWithOneNode()
        {
            var tree = new BinaryTree(new BinaryTreeNode {Value = 1});
            Assert.IsTrue(tree.IsSearchTree());
        }

        [Test]
        public void BinarySearchTree()
        {
            var root = new BinaryTreeNode { Value = 2 };
            root.Left = new BinaryTreeNode {Value = 1};
            root.Right = new BinaryTreeNode {Value = 3};
            var tree = new BinaryTree(root);
            Assert.IsTrue(tree.IsSearchTree());
        }
        
        [Test]
        public void BinarySearchTreeWithDuplicates()
        {
            var root = new BinaryTreeNode { Value = 2 };
            root.Left = new BinaryTreeNode {Value = 2};
            root.Right = new BinaryTreeNode {Value = 2};
            var tree = new BinaryTree(root);
            Assert.IsTrue(tree.IsSearchTree());
        }
        
        [Test]
        public void NotBinarySearchTreeWithDuplicates()
        {
            var root = new BinaryTreeNode { Value = 1 };
            root.Left = new BinaryTreeNode {Value = 2};
            root.Right = new BinaryTreeNode {Value = 2};
            var tree = new BinaryTree(root);
            Assert.IsFalse(tree.IsSearchTree());
        }
    }
}
