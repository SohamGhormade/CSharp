
using System.Collections.Generic;
 using System.Text;
// my attempt to optimize deteriorated the performance
namespace Strings
{

public class LongestSubString2 {
    private Dictionary<string,bool> stringToIsUnique = new Dictionary<string,bool>();
    public int LengthOfLongestSubstring(string s) {

        var maxLength = 0;
        var subString = new StringBuilder();

        for(var i = 0; i < s.Length; i++)
        {
            subString.Append(s[i]);
            UpdateMaxLength(subString ,ref maxLength);
            for(var j = i + 1; j < s.Length ;j++)
            {
                subString.Append(s[j]);
                UpdateMaxLength(subString ,ref maxLength);
            }
            subString.Clear();

        }

        return maxLength;
    }
    private void UpdateMaxLength(StringBuilder subString,ref int maxLength)
    {
                var tempString = subString.ToString();
                var isUnique = IsUnique(tempString);
                if(isUnique && tempString.Length > maxLength )
                {
                    maxLength = tempString.Length;
                }
    }
    private bool IsUnique(string subString)
    {
        if(stringToIsUnique.ContainsKey(subString))
            return stringToIsUnique[subString] ;

        var hashSet = new HashSet<char>();

        for(var i = 0; i < subString.Length;i++)
        {
            if(!hashSet.Contains(subString[i]))
                hashSet.Add(subString[i]);

            else
               {
                stringToIsUnique.Add(subString, false);
                return false;
                }
        }

        stringToIsUnique.Add(subString, true);

        return true;
    }
  }
}