/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 // leet code
  public class ListNode {
     public int val;
     public ListNode next;
   public ListNode(int x) { val = x; }
 }
public class Solution {
    public ListNode AddTwoNumbers(ListNode n1, ListNode n2)
    {
        var n = new ListNode(0);
        var l1 = findLength(n1);
        var l2 = findLength(n2);
        var l = Math.Max(l1, l2);
        Console.WriteLine("Max length " + l);
        var sumList = n;
        var carry = 0;

        for (var i = 0; i < l -1 ; i++)// O(n)
        {
            var t = new ListNode(0);
            n.next = t;
            n = n.next;
        }
        n = sumList;
        ListNode prev = null;
        for (var i = 0; i < l; i++)//O(n)
        {
            var result = 0;
            if (n1 != null)
            {
                result += n1.val;
                n1 = n1.next;

            }
            if (n2 != null)
            {
                result += n2.val;
                n2 = n2.next;

            }
            if (carry == 1)
             {
                result += 1;
                carry = 0;
             }

            if (result > 9)
            {
                result = result % 10;
                carry = 1;
            }
            else
                carry = 0;

            n.val = result;
            prev = n;
            n = n.next;


        }
        if (carry == 1)
        {   var t = new ListNode(0);
            t.val = carry;
            prev.next = t;

        }
        return sumList;
    }
    private int findLength(ListNode l)
    {
        int count = 0;
        for(var x = l; x!=null;x=x.next)
        {

            count++;
        }

        return count;
    }
}