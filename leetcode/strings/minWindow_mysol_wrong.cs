using System;
using System.Collections.Generic;

public class MinWindowSolution {
    public string MinWindow(string s, string t) {
        // handle trivial case
        if(t.Length < s.Length )
        {
            if(s.Contains(t))
                return t;
        }


        // create a frequency table
        var charToCount = new Dictionary<char, int>();

        for(int i = 0; i < t.Length; i++)
        {
            if(!charToCount.ContainsKey(t[i]))
             {
                charToCount.Add(t[i], 1);
             }
            else
              {
                charToCount[t[i]] +=1;
               }
        }

        //# of unique chars in t
        var counter = charToCount.Count;

        var begin = 0;
        var end = 0;

        // Traverse s.
        //find substring
        // start sliding the window toward right
        while( end < s.Length)
        {
            var endChar = s[end];

            if(charToCount.ContainsKey(endChar))
            {
                charToCount[endChar]--;
                if(charToCount[endChar] ==0) counter--;
            }
            end++;
        }


        var ans = string.Empty;
        var len = Int32.MaxValue;
        // trim the sliding window
        while(counter ==0)
        {
            if(end - begin < len)
            {

               len = end - begin;
               ans = s.Substring(begin, len);

                if(!charToCount.ContainsKey(ans[ans.Length -1]))
                    ans = ans.Remove(ans.Length -1);

            }

            var startChar = s[begin];
            if(charToCount.ContainsKey(startChar))
            {
                charToCount[startChar]++;

                if(charToCount[startChar]>0)
                    counter++;
            }
            begin++;
        }


        return ans;


    }
}