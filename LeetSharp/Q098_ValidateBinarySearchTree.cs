using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, determine if it is a valid binary search tree (BST).

// Assume a BST is defined as follows:

// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.

namespace LeetSharp
{
    [TestClass]
    public class Q098_ValidateBinarySearchTree
    {
        public bool IsValidBST(BinaryTree root)
        {
            return false;
        }

        public string SolveQuestion(string input)
        {
            return IsValidBST(input.ToBinaryTree()).ToString().ToLower();
        }

        [TestMethod]
        public void Q098_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q098_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
