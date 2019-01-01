using System.Collections.Generic;
using System.Linq;

public class GroupAnagram {
    public IList<IList<string>> GroupAnagrams(string[] strs) {

        var keysToLists = new Dictionary<string, List<string>>();
        for(int i = 0; i < strs.Length; i++)
        {
            var currentString = strs[i];
            var sortedString = string.Concat(strs[i].OrderBy(c => c));
            if(!keysToLists.ContainsKey(sortedString))
              {
                keysToLists.Add(sortedString, new List<string>());

                }

                keysToLists[sortedString].Add(currentString);


            }
        // convert dictionary to 2D ilist
        // Stack overflow answer:https://stackoverflow.com/a/9006016
        // Remember
      var result = new List<IList<string>>();
      foreach(var key in keysToLists.Keys)
      {
          result.Add(keysToLists[key]);
      }

        return result;
    }
}
//Runtime: 364 ms, faster than 59.90% of C# online submissions for Group Anagrams.