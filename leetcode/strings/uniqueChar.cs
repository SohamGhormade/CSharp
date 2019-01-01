// 80 % fast
// optimized from 4 % fast by switching over from hashtables to using arrays
public class Solution_15_Dec_2018 {
    public int FirstUniqChar(string s) {

        // S:O(1)
        var frequencyTable = new int[26];
        var indexTable = new int[26];
        //O(n)
        for(var i = 0 ; i < s.Length ; i++)
        {


             frequencyTable[s[i] - 'a']++;

            if(indexTable[s[i] - 'a']==0)
              indexTable[s[i] - 'a'] = i;
        }

        for(var i =0; i < s.Length;i++)
        {
            if(frequencyTable[s[i] - 'a']==1)
                return indexTable[s[i] -'a'];
        }
        return -1;
    }
}