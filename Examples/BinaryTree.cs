using System;

namespace Examples {
    public class TreeNode {
        public int Value { get; private set; }
        public TreeNode Left { get; private set; }
        public TreeNode Right { get; private set; }

        public TreeNode(int val) {
            this.Value = val;
        }

        public void Print() {
            this.Left?.Print();
            Console.WriteLine($"(The value of this node is {this.Value})");
            this.Right?.Print();
        }

        public int Count() {
            if (!this.HasChildren())
                return 1;

            int leftcount = this.Left?.Count() ?? 0;
            int rightCount = this.Right?.Count() ?? 0;
            return 1 + leftcount + rightCount;
        }

        public void Insert(int value) {            
            if (value == this.Value)
                throw new InvalidOperationException($"Duplicate key collision at {value}");

            if (value < this.Value) {
                if (this.Left == null) {
                    this.Left = new TreeNode(value);
                    return;
                }

                this.Left.Insert(value);
                return;
            }

            if (this.Right == null) {
                this.Right = new TreeNode(value);
                return;
            }

            this.Right.Insert(value);
        }

        public TreeNode Find(int value) {
            if (value == this.Value) {
                return this;
            } else if (value < this.Value) {
                if (this.Left == null)
                    return null;
                return this.Left.Find(value);
            }

            if (this.Right == null)
                return null;
            return this.Right.Find(value);
        }

        private bool HasChildren() => this.Left != null || this.Right != null;

        public void Remove(int value) {
            if (value < this.Value) {
                if (this.Left == null)
                    throw new InvalidOperationException($"{value} does not exist in the tree");

                this.Left.Remove(value);
                return;
            } else if (value > this.Value) {
                if (this.Right == null)
                    throw new InvalidOperationException($"{value} does not exist in the tree");

                this.Right.Remove(value);
                return;
            }   

            if (this.Right == null) {
                this.Value = this.Left.Value;
                this.Right = this.Left.Right;
                this.Left = this.Left.Left;
                return;
            }

            if (this.Left == null) {
                this.Value = this.Right.Value;
                this.Left = this.Right.Left;
                this.Right = this.Right.Right;
                return;
            }

            if (!this.Right.HasChildren()) {
                this.Value = this.Right.Value;
                this.Right = null;
                return;
            }

            TreeNode child = this.Right;
            while (true) {
                if (child.Left != null) {
                    if (child.Left.HasChildren()) {
                        child = child.Left;
                        continue;
                    }
                    this.Value = child.Left.Value;
                    child.Left = null;
                    break;
                }

                if (child.Right != null) {
                    if (child.Right.HasChildren()) {
                        child = child.Right;
                        continue;
                    }
                    this.Value = child.Right.Value;
                    child.Right = null;
                    break;
                }
                throw new InvalidOperationException("Woops");
            }
        }
    }
}