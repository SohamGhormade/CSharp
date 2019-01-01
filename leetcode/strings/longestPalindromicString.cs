public class Palindrome_Solution {
     // T:O(n^3)
    // S:O(n)
    public string LongestPalindromeNaive(string s) {

        if(s.Length == 0 || s.Length == 1)
            return s;

        var maxLength = 0;
        var longestPalindrome = string.Empty;
        var palindromes = new HashSet<string>();
        for(int i =0 ;i < s.Length; i++)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(s[i]);
            var temp = stringBuilder.ToString();
            if(temp.Length > maxLength && isPalindrome(temp, palindromes)  )
                {
                    maxLength = temp.Length;
                    longestPalindrome = temp;
                }

            for(int j = i + 1; j < s.Length;j++)
            {
                 stringBuilder.Append(s[j]);
                 temp = stringBuilder.ToString();
                if(temp.Length > maxLength && isPalindrome(temp, palindromes))
                {
                    maxLength = temp.Length;
                    longestPalindrome = temp;
                }


            }
            }


    return longestPalindrome;
    }

    // T:O(n)
    // S:O(1)
    public bool isPalindrome(string s, HashSet<string> palindromes)

    {
        if(s.Length == 0 || s.Length == 1)
            return true;


        for(int i = 0; i <= s.Length/2;i++)
        {
            if(s[i]!= s[s.Length -i - 1])
                return false;
             else
             {
                 if(palindromes.Contains(s.Substring(1,s.Length -1 )))
                     return true;
             }
        }

        if(!palindromes.Contains(s))
            palindromes.Add(s);

        return true;
    }
    }