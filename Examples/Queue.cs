using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Examples {
    public class MyQueue<T>: IEnumerable<T> {
        private const int MIN_SIZE = 10;
        private int head = 0;
        private int tail = 0;
        private int size = 0;
        private T[] items = new T[MIN_SIZE];

        public int Count { get => size; }

        private bool ShouldIncreaseArraySize() => size + 1 == items.Length;
        
        private bool ShouldDecreaseArraySize() => items.Length > MIN_SIZE && size <= items.Length / 4;

        private void TryResizeInternalArray() {
            int newLength = 0;
            if (ShouldIncreaseArraySize())
                newLength = items.Length * 2;
            else if (ShouldDecreaseArraySize())
                newLength = items.Length / 2;
            else 
                return;
            
            T[] newArray = new T[newLength];
            
            for (var i = 0; i < size; i++) {
                newArray[i] = items[head++ % items.Length];
            }

            head = 0;
            tail = size;
            items = newArray;
        }

        public void Enqueue(T item) {
            if (item == null)
                throw new NullReferenceException($"{nameof(item)} cannot be null");

            TryResizeInternalArray();

            items[tail++ % items.Length] = item;
            size++;
        }

        public T Dequeue() {
            if (size == 0)
                throw new InvalidOperationException("The queue is empty");
            
            T item = items[head % items.Length];
            items[head % items.Length] = default(T);
            head++;
            size--;

            TryResizeInternalArray();

            return item;
        }

        public T Peek() => items[head % items.Length];

        public IEnumerator<T> GetEnumerator() {
            for (var i = 0; i < size; i++) {
                yield return items[head + i % items.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }
    }
}