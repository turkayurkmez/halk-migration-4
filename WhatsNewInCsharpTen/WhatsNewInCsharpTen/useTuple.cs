using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCsharpTen
{
    public class useTuple
    {
        /// <summary>
        /// İki sayıyı böler
        /// </summary>
        /// <param name="number"></param>
        /// <param name="divisor"></param>
        /// <returns>Item1: sonuç, Item2: kalandır</returns>
        public static Tuple<int, int> divide(int number, int divisor)
        {
            var tuple = Tuple.Create<int, int>(number / divisor, divisor % divisor);
            return tuple;
        }
    }
}
