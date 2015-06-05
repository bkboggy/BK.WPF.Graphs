using System;

namespace BK.WPF.Graphs.Utility
{
    public static partial class ExtensionMethods
    {
        public static int RoundUp(this int num)
        {
            var baseNum = num.GetBaseValue();

            if (num > 100 && num % baseNum * 2 < num)
            {
                baseNum /= 10;
            }

            return (int)(Math.Ceiling(num / (double)baseNum) * baseNum);
        }

        public static int RoundUp(this double num)
        {
            var baseNum = num.GetBaseValue();

            if (num > 100 && (int)num % baseNum * 2 < num)
            {
                baseNum /= 10;
            }

            return (int)(Math.Ceiling(num / baseNum) * baseNum);
        }
    }
}
