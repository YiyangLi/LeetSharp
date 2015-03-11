using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list, swap every two adjacent nodes and return its head.

// For example,
// Given 1->2->3->4, you should return the list as 2->1->4->3.

// Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

namespace LeetSharp
{
    [TestClass]
    public class Q024_SwapNodesinPairs
    {
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            if (head == null || head.Next == null) 
                return head;
            var dummy = new ListNode<int>(-1);
            var prev = dummy;
            var n1 = head;
            var n2 = n1.Next;
            var next = n2.Next;
            while (true)
            {
                prev.Next = n2;
                n2.Next = n1;
                n1.Next = next;
                if (next == null || next.Next == null)
                    break;
                prev = n1;
                n1 = next;
                n2 = n1.Next;
                next = n2.Next;
            }
            return dummy.Next;
        }

        public string SolveQuestion(string input)
        {
            return SwapPairs(input.ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q024_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q024_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
