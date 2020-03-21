using System;
using System.Collections.Generic;

namespace laba05
{
    class Functions
    {
        public static string systemFrac(decimal fraction, int system)
        {
            var fractionList = new List<decimal>();
            var result = String.Empty;
            int i = 0;
            while (fraction >= (decimal)0.001 && i++ <= 100)
            {
                if (fractionList.Contains(fraction))
                {
                    var temp = result.Substring(fractionList.IndexOf(fraction));
                    result = result.Substring(0, fractionList.IndexOf(fraction));
                    result += "(" + temp + ")";
                    break;
                }
                fractionList.Add(fraction);
                fraction *= system;
                if (Math.Truncate(fraction) <= 9)
                    result += (char)(Math.Truncate(fraction) + '0');
                else if (Math.Truncate(fraction) >= 10)
                    result += (char)(Math.Truncate(fraction) + 'A' - 10);
                fraction -= Math.Truncate(fraction);
            }
            return result;
        }
        public static string NumtoSystem(int number, decimal fraction, int system)
        {
            List<char> iList = new List<char>();
           
            while ((number / system) != 0)
            {
                if (number % system > 9)
                    iList.Add((char)(number % system + 'A' - 10));
                else
                    iList.Add((char)(number % system + '0'));
                number /= system;
            }

            if (number % system > 9)
                iList.Add((char)(number % system + 'A' - 10));
            else
                iList.Add((char)(number % system + '0'));

            iList.Reverse();
            var res = String.Empty;
            res = String.Concat(iList);
            res += ',';
            res += systemFrac(fraction, system);
            return res;
        }

        
    }
}
