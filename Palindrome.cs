using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Console.WriteLine ("Hello World :"+isPalindrome("Hello World"));
  Console.WriteLine ("dada :"+isPalindrome("dada"));
  Console.WriteLine ("daada :"+isPalindrome("daada"));
  
  }


  public static bool isPalindrome(string str)
  {
    var dict = new Dictionary<char,int>();
    for(int i = 0;i<str.Length;i++)
    {
      char ch = str[i];
      if(!dict.ContainsKey(ch))
         dict.Add(ch,1);
      else
         dict[ch] +=1;
    }
    var foundOdd = false;
    foreach(var key in dict.Keys)
    {
      if(dict[key]%2==1)
      {
        if(foundOdd)
           return false;
      foundOdd = true;
      }
    } 
      
      return true;
  }

}
