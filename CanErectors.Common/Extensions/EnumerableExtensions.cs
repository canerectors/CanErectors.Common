﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class EnumerableExtensions
    {
        static Random random = new Random();

        public static T GetRandomElement<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return default(T);

            var l = list.ToList();

            if (!l.Any())
                return default(T);

            return l.ElementAt(random.Next(l.Count));
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var rng = new Random();
            return source.Shuffle(rng);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();

            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
