using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCsharpTen
{
    public struct Point
    {
        //Artık C#.10'dan itibaren parametresiz constructor'umuzu ekleyebiliriz.
        public Point()
        {
            X = default(int);
        }
        public int X { get; init; }

        public int Y { get; init; } = default(int);
    }

    public record struct Address(string Street, string PostalCode, string City);
}
