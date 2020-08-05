using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Mines
{
    internal static class RandomHelper
    {
        private static readonly RandomNumberGenerator RANDOM_GENERATOR = RandomNumberGenerator.Create();
        public static IEnumerable<int> GetUInts(int count, int max = int.MaxValue, int min = 0)
        {
            var byteLength = BitConverter.GetBytes(max).Length;
            var data = new byte[byteLength * count];
            RANDOM_GENERATOR.GetNonZeroBytes(data);
            return data.Select((x, index) => new { x, index })
                .GroupBy(x => x.index / byteLength, x => x.x)
                .Select(x => (BitConverter.ToInt32(x.ToArray(), 0) % (max - min)) + min)
                .Select(Math.Abs);
        }
    }
}
