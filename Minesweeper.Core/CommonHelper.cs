using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Minesweeper
{
    public static class CommonHelper
    {
        public static IEnumerable<T> Emit<T>(this T t)
        {
            yield return t;
        }
        

        public static void Each<T>(this IEnumerable<T> seq, Action<T> action)
        {
            foreach(var t in seq)
            {
                action(t);
            }
        }

        public static TSeed AggregateAction<T, TSeed>(this IEnumerable<T> seq, TSeed seed, Action<TSeed, T> action)
        {
            return seq.Aggregate(seed, reduce);
            TSeed reduce(TSeed seed, T t)
            {
                action(seed, t);
                return seed;
            };
        }
    }

}
