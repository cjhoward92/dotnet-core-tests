using System;
using System.Collections.Generic;

namespace Examples {
    public class Node {
        public Node(int value) {
            this.Value = value;
        }

        public int Value { get; private set; }

        public Node Next { get; set; }
    }

    public static class LinkedListHelpers {
        // Prints all nodes in the list and detects cyclical lists
        public static void Print(Node head) {
            var refSet = new HashSet<Node>();
            while (head != null) {
                if (refSet.Contains(head))
                    break;
                
                Console.WriteLine($"This node's value is {head.Value}");
                refSet.Add(head);
                head = head.Next;
            }
        }

        public static Node Reverse(Node head) {
            var refSet = new HashSet<Node>();
            Node next = null;
            Node tmp = null;
            while (head != null) {
                if (refSet.Contains(head))
                    break;
                
                next = head.Next;
                head.Next = tmp;
                tmp = head;
                head = next;
            }
            return tmp;
        }
    }
}