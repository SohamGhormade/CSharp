// T:O(n)
// S:O(n)
// attempt 3 83 % fast
// attempt 2 with char array (no in place swap )
// attempt  1 with StringBuilder 50 % fast
    public class Solution11 {
    public string ReverseString(string s) {

        // strings are immutable ,convert to char array
            char[] charArray = s.ToCharArray();

        var i = 0;
         var j = s.Length - 1;
        while( i < s.Length /2 && j >= 0)
        {
            var temp = charArray[i];// function call for swap has overhead for every call inside for loop.Consider it if used in multiple places in code
            // 96 ms to 140 ms with swap() method
            charArray[i] = charArray[j];
            charArray[j] = temp;
            i++;
            j--;
        }


        return new string(charArray);

    }

}