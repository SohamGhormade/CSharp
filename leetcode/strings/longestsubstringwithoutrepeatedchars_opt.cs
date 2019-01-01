
using System;
using System.Collections.Generic;

namespace Strings
{
    public class LongestSubString1
    {
        public int LengthOfLongestSubstring(string s)
        {
            // use sliding window technique
            var hashSet = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            // extend range (i, j)
            while (i < s.Length && j < s.Length)
            {
                if (!hashSet.Contains(s[j]))
                {
                    hashSet.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                    hashSet.Remove(s[i++]);
            }
            return ans;

        }
    }
}