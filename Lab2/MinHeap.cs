﻿using System;
using System.Linq;
using System.Reflection;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }
        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;

        public MinHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }

        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(1).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(log N).
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }

        }

        /// <summary>
        ///  Extract
        /// </summary>
        /// <returns></returns>
        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O( N ).
        /// </summary>
        public T ExtractMax()
        {
            var max = array[0];
            foreach (var item in array)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }

        // TODO
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O( log(n) ).
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            Remove(min);

            return min;
        }

        // TODO
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N ).
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        // TODO
        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O( log N )
        /// </summary>
        public void Update(T oldValue, T newValue)
        {

            if (Contains(oldValue))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (array[i].CompareTo(oldValue) == 0)
                    {
                        array[i] = newValue;
                        if (newValue.CompareTo(oldValue) > 0)
                        {
                            TrickleDown(i);
                        }

                        if (newValue.CompareTo(oldValue) < 0)
                        {
                            TrickleUp(i);
                        }
                        return;
                    }

                }
            }
            else
            {
                throw new Exception("Value not in the array");
            }

        }

        // TODO
        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O( log N )
        /// </summary>
        public void Remove(T value)
        {
            if (Contains(value))
            {
                int index = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (array[i].CompareTo(value) == 0)
                    {
                        index = i;
                        break;
                    }
                }

                Swap(index, Count - 1);

                Count--;

                TrickleDown(index);
            }
            else
            {
                throw new Exception("Value not in the array");
            }


        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            if (array[index].CompareTo(array[Parent(index)]) < 0)
            {
                Swap(index, Parent(index));
                TrickleUp(Parent(index));
            }

        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {
           if (LeftChild(index) < Count && array[index].CompareTo(array[LeftChild(index)]) > 0)
           {
                Swap(LeftChild(index), index);
                TrickleDown(LeftChild(index));
           }

           if (RightChild(index) < Count && array[index].CompareTo(array[RightChild(index)]) > 0)
           {
                Swap(RightChild(index), index);
                TrickleDown(RightChild(index));
           }
        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            return (position - 1) / 2;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            return (position * 2) + 1;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            return (position * 2) + 2;
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}


