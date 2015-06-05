namespace BK.WPF.Graphs.Utility
{
    public static partial class ExtensionMethods
    {
        public static int GetBaseValue(this int num)
        {
            int baseNum;
            for (baseNum = 1000000000; baseNum > 0; baseNum /= 10)
            {
                var remainder = num % baseNum;
                if (remainder < num)
                {
                    break;
                }
            }

            return baseNum;
        }

        public static int GetBaseValue(this double num)
        {
            int baseNum;
            for (baseNum = 1000000000; baseNum > 0; baseNum /= 10)
            {
                var remainder = num % baseNum;
                if (remainder < num)
                {
                    break;
                }
            }

            return baseNum;
        }
    }
}
