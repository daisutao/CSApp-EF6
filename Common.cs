using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSApp
{
    internal static class Common
    {
        /// <summary>
        ///     获取日期是一年中第几个星期
        /// </summary>
        /// <param name="date">需要计算的时间</param>
        /// <returns>一年中第几个星期</returns>
        public static int GetWeekOfYear(DateTime date)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
        public static string ConvertDecimalToBase34(int i)
        {
            string chars = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            string returnValue = string.Empty;
            do
            {
                int j = i % 34;
                i = i / 34;
                returnValue = chars[j] + returnValue;
            } while (i > 0);

            if (returnValue.Length > 4)
                return returnValue.Substring(returnValue.Length - 4);
            else
                return returnValue.PadLeft(4, '0');
        }
        /// <summary>
        ///     34进制转10进制
        /// </summary>
        /// <param name="strBase34"></param>
        /// <returns></returns>
        private static int ConvertBase34ToBase10(string strBase34)
        {
            int result;
            char[] ch = strBase34.ToUpper().ToCharArray();
            switch (ch[0])
            {
                case 'A': result = 10; break;
                case 'B': result = 11; break;
                case 'C': result = 12; break;
                case 'D': result = 13; break;
                case 'E': result = 14; break;
                case 'F': result = 15; break;
                case 'G': result = 16; break;
                case 'H': result = 17; break;
                case 'J': result = 18; break;
                case 'K': result = 19; break;
                case 'L': result = 20; break;
                case 'M': result = 21; break;
                case 'N': result = 22; break;
                case 'P': result = 23; break;
                case 'Q': result = 24; break;
                case 'R': result = 25; break;
                case 'S': result = 26; break;
                case 'T': result = 27; break;
                case 'U': result = 28; break;
                case 'V': result = 29; break;
                case 'W': result = 30; break;
                case 'X': result = 31; break;
                case 'Y': result = 32; break;
                case 'Z': result = 33; break;
                default: result = Convert.ToInt32(strBase34); break;
            }
            return result;
        }
        /// <summary>
        ///     10进制转34进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ConvertBase10ToBase34(int num)
        {
            string result;
            int i = num % 34;
            switch (i)
            {
                case 10: result = "A"; break;
                case 11: result = "B"; break;
                case 12: result = "C"; break;
                case 13: result = "D"; break;
                case 14: result = "E"; break;
                case 15: result = "F"; break;
                case 16: result = "G"; break;
                case 17: result = "H"; break;
                case 18: result = "J"; break;
                case 19: result = "K"; break;
                case 20: result = "L"; break;
                case 21: result = "M"; break;
                case 22: result = "N"; break;
                case 23: result = "P"; break;
                case 24: result = "Q"; break;
                case 25: result = "R"; break;
                case 26: result = "S"; break;
                case 27: result = "T"; break;
                case 28: result = "U"; break;
                case 29: result = "V"; break;
                case 30: result = "W"; break;
                case 31: result = "X"; break;
                case 32: result = "Y"; break;
                case 33: result = "Z"; break;
                default: result = (i).ToString(); break;
            }
            return result;
        }

        /// <summary>
        ///     计算检验码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetCheckSum(string str)
        {
            int i;
            int oddSum = 0;
            int evenSum = 0;
            for (i = 1; i <= str.Length; i++)
                if (i % 2 == 1)
                    evenSum += ConvertBase34ToBase10(str.Substring(i - 1, 1));
                else
                    oddSum += ConvertBase34ToBase10(str.Substring(i - 1, 1));
            return 34 - (oddSum * 3 + evenSum) % 34;
        }
    }
}
