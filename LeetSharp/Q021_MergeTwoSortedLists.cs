using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Merge two sorted linked lists and return it as a new list. 
// The new list should be made by splicing together the nodes of the first two lists.

namespace LeetSharp
{
    [TestClass]
    public class Q021_MergeTwoSortedLists
    {
        public ListNode<int> MergeTwoLists(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var dummy = new ListNode<int>(-1);
            var head = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.Val < l2.Val)
                {
                    head.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    head.Next = l2;
                    l2 = l2.Next;
                }
                head = head.Next;
            }
            head.Next = l1 ?? l2;
            return dummy.Next;
        }

        public string SolveQuestion(string input)
        {
            return MergeTwoLists(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToListNode<int>())
                .SerializeListNode();
        }

        [TestMethod]
        public void Q021_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q021_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
