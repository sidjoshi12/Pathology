using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathology.Classes
{
    public static class IntegerExtensions
    {
        public static int Mod(this int input)
        {
            const int CHAR_BIT = 64;
            int v = 20;
            int r;
            int mask = v >> sizeof(int) * CHAR_BIT - 1;
            r = v*(v + mask) ^ mask;
            return r;
        }
    }
}
