using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

namespace LeetSharp
{
    [TestClass]
    public class Q023_MergekSortedLists
    {
        public ListNode<int> MergeKLists(ListNode<int>[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];
            //*************************
            //     First Solution O(nk)
            //*************************
            var tool = new Q021_MergeTwoSortedLists();
            var current = tool.MergeTwoLists(lists[0], lists[1]);
            for (int i = 2; i < lists.Length; i++)
            {
                current = tool.MergeTwoLists(current, lists[i]);
            }
            return current;

            //*************************
            //    Second Solution O(nk * ln(nk) )
            //*************************
            //var PQ = new PriorityQueue<int>(lists[0]);
            //var dummy = new ListNode<int>(-1);
            //var current = dummy;
            //for (int i = 1; i < lists.Length; i++ )
            //{
            //    while (lists[i] != null)
            //    {
            //        PQ.Push(lists[i].Val);
            //        lists[i] = lists[i].Next;
            //    }
            //}
            //while (!PQ.Empty())
            //{
            //    var ln = new ListNode<int>(PQ.Top());
            //    PQ.Pop();
            //    current.Next = ln;
            //    current = current.Next;
            //}
            //return dummy.Next;
        }

        public string SolveQuestion(string input)
        {
            return MergeKLists(input.ToListNodeArray<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q023_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q023_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }

    public class YLiHeap<T> where T : IComparable<T>
    {
        private static void Swap(ref T[] obj, int a, int b)
        {
            T temp = obj[a];
            obj[a] = obj[b];
            obj[b] = temp;
        }
        public static void HeapSort(ref T[] obj)
        {
            for (int i = obj.Length / 2 - 1; i >= 0; --i)
                AdjustFromTop(ref obj, i, obj.Length);
            for (int i = obj.Length - 1; i > 0; --i)
            {
                Swap(ref obj, i, 0);
                AdjustFromTop(ref obj, 0, i);
            }
        }
        public static void AdjustFromBottom(ref T[] obj, int n)
        {
            int m = (n - 1) / 2;
            while (n > 0 && obj[m].CompareTo(obj[n]) > 0)
            {
                Swap(ref obj, n, m);
                n = m;
                m = (n - 1) / 2;
            }
        }
        public static void AdjustFromTop(ref T[] obj, int n, int len)
        {
            while (n * 2 + 1 < len)
            {
                int m = n * 2 + 1;
                if (m + 1 < len && obj[m].CompareTo(obj[m + 1]) > 0)
                {
                    m = m + 1;
                }
                if (obj[n].CompareTo(obj[m]) < 0)
                    break;
                Swap(ref obj, n, m);
                n = m;
            }
        }

    }
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 16;
        private int len;
        private T[] buffer;
        private void Expand()
        {
            Array.Resize<T>(ref buffer, buffer.Length * 2);
        }
        private void swap(int a, int b)
        {
            T temp = buffer[a];
            buffer[a] = buffer[b];
            buffer[b] = temp;
        }
        public PriorityQueue()
        {
            buffer = new T[DEFAULT_CAPACITY];
            len = 0;
        }
        public PriorityQueue(T[] sortedCollection)
        {
            buffer = sortedCollection;
            len = sortedCollection.Length;
        }

        public PriorityQueue(LeetSharp.ListNode<T> sortedLinkedList)
            : this()
        {
            var lst = new List<T>();
            while (sortedLinkedList != null)
            {
                lst.Add(sortedLinkedList.Val);
                sortedLinkedList = sortedLinkedList.Next;
            }
            while (lst.Count > buffer.Length)
                Expand();
            foreach (var num in lst)
            {
                buffer[len] = num;
                len++;
            }
        }
        public bool Empty()
        {
            return len.Equals(0);
        }
        public T Top()
        {
            if (Empty())
            {
                throw new OverflowException("The queue is empty, unable to return the top element. ");
            }
            return buffer[0];
        }
        public void Push(T obj)
        {
            if (len.Equals(buffer.Length))
                Expand();
            buffer[len] = obj;
            YLiHeap<T>.AdjustFromBottom(ref buffer, len);
            len = len + 1;
        }
        public void Pop()
        {
            if (Empty())
            {
                throw new OverflowException("The queue is empty, unable to pop elements. ");
            }
            len = len - 1;
            swap(0, len);
            YLiHeap<T>.AdjustFromTop(ref buffer, 0, len);
        }
    }
}
