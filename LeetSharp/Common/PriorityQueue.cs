using System;
using System.Collections;
using System.Collections.Generic;

namespace YLiDataStructure
{
    //public class Heap<T> where T : IComparable<T>
    //{
    //    private static void Swap(ref T[] obj, int a, int b)
    //    {
    //        T temp = obj[a];
    //        obj[a] = obj[b];
    //        obj[b] = temp;
    //    }
    //    public static void HeapSort(ref T[] obj)
    //    {
    //        for (int i = obj.Length / 2 - 1; i >= 0; --i)
    //            AdjustFromTop(ref obj, i, obj.Length);
    //        for (int i = obj.Length - 1; i > 0; --i)
    //        {
    //            Swap(ref obj, i, 0);
    //            AdjustFromTop(ref obj, 0, i);
    //        }
    //    }
    //    public static void AdjustFromBottom(ref T[] obj, int n)
    //    {
    //        int m = (n - 1) / 2;
    //        while (n > 0 && obj[m].CompareTo(obj[n]) < 0)
    //        {
    //            Swap(ref obj, n, m);
    //            n = m;
    //            m = (n - 1) / 2;
    //        }
    //    }
    //    public static void AdjustFromTop(ref T[] obj, int n, int len)
    //    {
    //        while (n * 2 + 1 < len)
    //        {
    //            int m = n * 2 + 1;
    //            if (m + 1 < len && obj[m].CompareTo(obj[m + 1]) < 0)
    //            {
    //                m = m + 1;
    //            }
    //            if (obj[n].CompareTo(obj[m]) > 0)
    //                break;
    //            Swap(ref obj, n, m);
    //            n = m;
    //        }
    //    }

    //}
    //public class PriorityQueue<T> where T : IComparable<T>
    //{
    //    private const int DEFAULT_CAPACITY = 16;
    //    private int len;
    //    private T[] buffer;
    //    private void Expand()
    //    {
    //        Array.Resize<T>(ref buffer, buffer.Length * 2);
    //    }
    //    private void swap(int a, int b)
    //    {
    //        T temp = buffer[a];
    //        buffer[a] = buffer[b];
    //        buffer[b] = temp;
    //    }
    //    public PriorityQueue()
    //    {
    //        buffer = new T[DEFAULT_CAPACITY];
    //        len = 0;
    //    }
    //    public PriorityQueue(T[] sortedCollection)
    //    {
    //        buffer = sortedCollection;
    //        len = sortedCollection.Length;
    //    }

    //    public PriorityQueue(LeetSharp.ListNode<T> sortedLinkedList)
    //    {
    //        var lst = new List<T>();
    //        while (sortedLinkedList != null)
    //        {
    //            lst.Add(sortedLinkedList.Val);
    //            sortedLinkedList = sortedLinkedList.Next;
    //        }
    //        buffer = lst.ToArray();
    //        len = lst.Count;
    //    }
    //    public bool Empty()
    //    {
    //        return len.Equals(0);
    //    }
    //    public T Top()
    //    {
    //        if (Empty())
    //        {
    //            throw new OverflowException("The queue is empty, unable to return the top element. ");
    //        }
    //        return buffer[0];
    //    }
    //    public void Push(T obj)
    //    {
    //        if (len.Equals(buffer.Length))
    //            Expand();
    //        buffer[len] = obj;
    //        Heap<T>.AdjustFromBottom(ref buffer, len);
    //        len = len + 1;
    //    }
    //    public void Pop()
    //    {
    //        if (Empty())
    //        {
    //            throw new OverflowException("The queue is empty, unable to pop elements. ");
    //        }
    //        len = len - 1;
    //        swap(0, len);
    //        Heap<T>.AdjustFromTop(ref buffer, 0, len);
    //    }
    //}
}