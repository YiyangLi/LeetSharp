using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
// Output: 7 -> 0 -> 8

namespace LeetSharp
{
    [TestClass]
    public class Q002_AddTwoNumbers
    {
        public ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            int carry = 0;
            ListNode<int> current = new ListNode<int>(0);
            var answer = current;
            do
            {
                var a = l1 == null? 0 : l1.Val;
                var b = l2 == null? 0 : l2.Val;
                current.Next = new ListNode<int>((a + b + carry) % 10);
                carry = (a + b + carry) / 10;
                current = current.Next;
                l1 = l1 == null ? l1 : l1.Next;
                l2 = l2 == null ? l2 : l2.Next;
            } while (l1 != null || l2 != null);
            while (carry > 0)
            {
                current.Next = new ListNode<int>(carry);
                carry = carry / 10;
                current = current.Next;
            }
            return answer.Next??answer;
        }

        public string SolveQuestion(string input)
        {
            return AddTwoNumbers(input.GetToken(0).ToListNode<int>(), 
                input.GetToken(1).ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q002_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q002_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
