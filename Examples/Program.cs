using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static List<TestData> testData = new List<TestData>() {
            new TestData() {
                Id = 1,
                Name = "Carson",
                IsTestable = true
            },
            new TestData() {
                Id = 2,
                Name = "Joe",
                IsTestable = false
            },
            new TestData() {
                Id = 3,
                Name = "Mark",
                IsTestable = true
            },
            new TestData() {
                Id = 4,
                Name = "Sally",
                IsTestable = true
            },
            new TestData() {
                Id = 5,
                Name = "Cindy",
                IsTestable = false
            }
        };

        static Node BuildNodes() {
            var n = new Node(1);
            n.Next = new Node(2);
            n.Next.Next = new Node(3);
            n.Next.Next.Next = new Node(4);
            return n;
        }

        static Node BuildCyclicalList() {
            var n = new Node(1);
            n.Next = new Node(2);
            n.Next.Next = new Node(3);
            n.Next.Next.Next = new Node(4);
            n.Next.Next.Next.Next = n;
            return n;
        }

        static void PrintPropertyValue(object o, PropertyInfo p) {
            Console.WriteLine($"Value for {p.Name} is {p.GetValue(o)}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This is the start of the tests");

            var filteredData = LinqTest.Filter(testData, (d) => d.Id < 4);
            Console.WriteLine($"The list has {filteredData.Count} elements");

            var transformedData = LinqTest.Transform(testData);
            List<PropertyInfo> props = null;
            foreach (var o in transformedData) {
                if (props == null) {
                    props = o.GetType().GetProperties().ToList();
                }
                props.ForEach(p => PrintPropertyValue(o, p));
            }

            Console.WriteLine("this is the end of the Linq tests\n\n\n");

            var n = BuildNodes();
            LinkedListHelpers.Print(n);
            var m = LinkedListHelpers.Reverse(n);
            LinkedListHelpers.Print(m);

            Console.WriteLine("Testing Cyclical Linked List");
            var c = BuildCyclicalList();
            LinkedListHelpers.Print(c);
        }
    }
}
