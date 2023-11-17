using System;
using System.Collections.Generic;


namespace Agents
{
    internal class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Range(int Start, int End) 
        {
            this.Start = Start;
            this.End = End;
        }

        public Range()
        {

        }

        public static ICollection<T> GetRange<T>(List<T> Arr, Range range) 
        {
            List<T> list = new List<T>();

            for (; range.Start < range.End; range.Start++) 
            {
                list.Add(Arr.ToArray()[range.Start]);
            }

            return list;
        }
    }
}
