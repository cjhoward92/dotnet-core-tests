using System;
using Xunit;
using Examples;

namespace Tests
{
    public class MyQueueTests
    {
        [Fact]
        public void CanAddItem()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void CanAddSeveralItems()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            Assert.Equal(5, queue.Count);
        }

        [Fact]
        public void CanDequeueAnItem()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            int item = queue.Dequeue();
            Assert.Equal(0, queue.Count);
            Assert.Equal(1, item);
        }

        [Fact]
        public void CanPeekItem()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1000);
            int item = queue.Peek();
            Assert.Equal(1, queue.Count);
            Assert.Equal(1000, item);
        }

        [Fact]
        public void WillKeepTrackOfItemsWithDequeueEnqueue() {
            var queue = new MyQueue<int>();

            queue.Enqueue(1000);
            queue.Enqueue(1001);
            queue.Enqueue(1002);

            var item1 = queue.Dequeue();

            queue.Enqueue(5000);

            var item2 = queue.Dequeue();
            var item3 = queue.Dequeue();
            var item4 = queue.Peek();

            Assert.Equal(1, queue.Count);
            Assert.Equal(1000, item1);
            Assert.Equal(1001, item2);
            Assert.Equal(1002, item3);
            Assert.Equal(5000, item4);
        }

        [Fact]
        public void WillHoldMoreThan10Items() {
            var queue = new MyQueue<int>();

            for (var i = 0; i < 100; i++) {
                queue.Enqueue(i);
            }

            Assert.Equal(100, queue.Count);
        }
    }
}
