// 20 mins
// T:O(n)
// S:O(n) n :# of chars
using System.Collections.Generic;

public class ValidAnagram {
    public bool IsAnagram(string s, string t) {
     var charToCount = new Dictionary<char, int>();// unicode
        for(int i = 0 ; i < s.Length; i++)
        {
            if(!charToCount.ContainsKey(s[i]))
              charToCount.Add(s[i], 1);
            else
                charToCount[s[i]] +=1;
        }

        for(int i = 0 ; i < t.Length; i++)
        {
            if(!charToCount.ContainsKey(t[i]))
               return false;
            else
                charToCount[t[i]] -=1;

            if(charToCount[t[i]]==0) charToCount.Remove(t[i]);
        }
        if(charToCount.Count==0) return true;

        return false;

    }
}
// TODO improve runtime
//your runtime beats 30.64 % of csharp submissions.