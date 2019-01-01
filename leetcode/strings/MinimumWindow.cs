using System;
using System.Collections.Generic;

// Given a string S and a string T, find the minimum window in S which will contain all the characters
// in T in complexity O(n).
// Example:
// Input: S = "ADOBECODEBANC", T = "ABC"
// Output: "BANC"
// Note:
// If there is no such window in S that covers all characters in T, return the empty string "".
// If there is such window, you are guaranteed that there will always be
// only one unique minimum window in S.
namespace Strings
{
    public class MinimumWindow
    {
        public string minimumWindowSubString(string s, string t)
        {
            // 1.count the # of chars in string t
            //i. populate frequency table
            var charToCount = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (!charToCount.ContainsKey(t[i]))
                    charToCount.Add(t[i], 1);
                else
                    charToCount[t[i]] += 1;
            }

            // initialize the sliding window
            var counter = charToCount.Count;
            var begin = 0;
            var end = 0;
            var len = Int32.MaxValue;
            string ans = "";
            // 2.start the sliding window
            while (end < s.Length)
            {
                var endChar = s[end];
                if (charToCount.ContainsKey(endChar))
                {
                    charToCount[endChar]--;
                    if (charToCount[endChar] == 0)
                    {
                        counter--;
                    }
                }

                end++;
                // window found .
                //trim that window by sliding "begin" to right
                while (counter == 0)
                {
                    if (end - begin < len)
                    {
                        len = end - begin;
                        ans = s.Substring(begin, end - begin);
                    }

                    var startChar = s[begin];
                    if (charToCount.ContainsKey(startChar))
                    {
                        charToCount[startChar]++;
                        if (charToCount[startChar] > 0)
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
}