using System;
using System.Collections.Generic;

//Q:print all permutations of a given input string.
public class PermuteSolution
{
    public void permute(string s)
    {
        var alreadyPrinted = new HashSet<string>();
        permuteHelper(s,"",alreadyPrinted);
        foreach(var k in alreadyPrinted)
        {
            Console.Write(k);
        }
    }

    private void permuteHelper(string s, string chosen, HashSet<string> alreadyPrinted)
    {
       if(s=="")
       {
           if(!alreadyPrinted.Contains(chosen))
            alreadyPrinted.Add(chosen);

       }
       else
       {
           //choose/explore/unchoose
           for(int i = 0;i < s.Length;i++)
           {
               // choose char
               char c = s[i];
               chosen +=c;

               s = s.Remove(i,1);
               // explore/recurse
               permuteHelper(s, chosen, alreadyPrinted);
               // unchoose
               s =s.Insert(0,c.ToString());
               chosen = chosen.Remove(chosen.Length - 1 ,1);


           }

       }
    }


}