
using System.Collections.Generic;
 using System.Text;
// not optimized
// 986/987 cases passed.
namespace Strings
{
    public class LongestSubString3 {
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
        var hashSet = new HashSet<char>();

        for(var i = 0; i < subString.Length;i++)
        {
            if(!hashSet.Contains(subString[i]))
                hashSet.Add(subString[i]);

            else
                return false;

        }

        return true;
    }
}
}
