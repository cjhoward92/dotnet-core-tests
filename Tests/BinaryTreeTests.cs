using System;
using System.Collections;
using Xunit;
using Examples;

namespace Tests
{
    public class BinaryTreeTests {
        [Fact]
        public void CanInsertIntoTree() {
            var tree = new TreeNode(10);
            tree.Insert(5);
            tree.Insert(12);
            Assert.Equal(3, tree.Count());
        }

        [Fact]
        public void CanFindNode() {
            var tree = new TreeNode(10);
            tree.Insert(5);
            tree.Insert(12);
            tree.Insert(3);

            var node = tree.Find(5);

            Assert.Equal(5, node.Value);
            Assert.NotNull(node.Left);
            Assert.Null(node.Right);
        }

        [Fact]
        public void CanRemoveRootNode() {
            var tree = new TreeNode(10);
            tree.Insert(5);
            tree.Insert(12);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(100);
            tree.Insert(11);
            tree.Insert(120);

            tree.Remove(10);

            Assert.Equal(11, tree.Value);
            Assert.Equal(8, tree.Count());
        }

        [Fact]
        public void CanRemoveNode() {
            var tree = new TreeNode(10);
            tree.Insert(5);
            tree.Insert(12);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(100);
            tree.Insert(11);
            tree.Insert(120);

            tree.Remove(3);

            Assert.Equal(10, tree.Value);
            Assert.Equal(9, tree.Count());
        }
    }
}