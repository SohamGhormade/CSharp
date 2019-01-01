
using System;
using System.Collections.Generic;
// 35 % fast.
// converted C++ solution into C#
public class Solution1 {
public string MinWindow(string s, string t)
{
        var table = new Dictionary<char,int>();

        // initialize frequency table for t
        for(var i =0;i < t.Length;i++)
        {
            char c = t[i];
            if(!table.ContainsKey(c))
              table.Add(c,1);
            else
              table[c] += 1;
        }

        // initialize sliding window
        int begin = 0, end = 0;
        int counter = table.Count;
        int len = Int32.MaxValue;

        string ans = "";

        // start sliding window
        while(end < s.Length)
        {
            char endchar = s[end];

            // if current char found in table, decrement count
            if(table.ContainsKey(endchar))
            {
                table[endchar]--;
                if(table[endchar] == 0)
                {
                    counter--;
                }
            }

            end++;

            // if counter == 0, means we found an answer, now try to trim that window by  sliding begin to right.
            while(counter == 0)
            {
                // store new answer if smaller than previously best
                if(end-begin < len){
                    len = end - begin;
                    ans = s.Substring(begin, end - begin);
                }

                // begin char could be in table or not,
                // if not then good for us, it was a wasteful char and we shortened the previously found substring.

                // if found in table increment count in table, as we are leaving it out of window and moving ahead,
                // so it would no longer be a part of the substring marked by begin-end window
                // table only has count of chars required to make the present substring a valid candidate
                // if the count goes above zero means that the current window is missing one char to be an answer candidate
                var startchar = s[begin];

                if(table.ContainsKey(startchar))
                {
                   table[startchar]++;
                   if(table[startchar] > 0)
                    {
                       counter++;
                    }
                }

                begin++;
            }
        }

        return ans;
    }
}
