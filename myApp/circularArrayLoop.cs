using System.Collections.Generic;

namespace GoogleCandidateCoaching
{
    public class Problem
    {
        public bool hasCompleteCycle(int[] a)
        {
            var l= a.Length;
            var set = new HashSet<int>();
            int i = 0;
            while (true)
            {
                var hop = a[i];
                i += hop;
                i = i % l;
                if (!set.Contains(i))
                    set.Add(i);
                else
                    return true;
            }
            return false;

        }

    }

}