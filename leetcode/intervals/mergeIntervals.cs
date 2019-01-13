
using System.Collections.Generic;
using System.Linq;
/**
* Definition for an interval.
* public class Interval {
*     public int start;
*     public int end;
*     public Interval() { start = 0; end = 0; }
*     public Interval(int s, int e) { start = s; end = e; }
* }
*/
public class Interval {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
     public Interval(int s, int e) { start = s; end = e; }
public class Merge_Solution
{
    public IList<Interval> Merge(IList<Interval> intervals)
    {
        // Use SQL query
        intervals =intervals.OrderBy(x=>x.start).ToList();
        var merged = new List<Interval>();
        // Remember ,Use Count for IList
        // Use Length for Array
        for(int i = 0; i < intervals.Count;i++)
        {
            var a = intervals[i];
            var last = merged.LastOrDefault();
            //no overlap
            if( last== default(Interval) || last.end < a.start)
                merged.Add(a);

            else
            {
                if(merged.Last().end < a.end)
                  merged.Last().end = a.end;
             }
        }

        return merged;
    }

}}
