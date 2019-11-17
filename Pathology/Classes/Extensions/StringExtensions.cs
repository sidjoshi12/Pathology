using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Pathology
{
    public static class StringExtensions
    {        
        public static DateTime toDate(this string input, bool throwExceptionIfFailed = false)
        {
            DateTime result;
            var valid = DateTime.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));
            return result;
        }

        public static int toInt(this string input, bool throwExceptionIfFailed = false)
        {
            int result;
            var valid = int.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", input));
            return result;
        }
        public static double toDouble(this string input, bool throwExceptionIfFailed = false)
        {
            double result;
            var valid = double.TryParse(input, NumberStyles.AllowDecimalPoint, new NumberFormatInfo { NumberDecimalSeparator = "." }, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as double", input));
            return result;
        }





        public static string toSentence(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            //return as is if the input is just an abbreviation
            if (Regex.Match(input, "[0-9A-Z]+$").Success)
                return input;
            //add a space before each capital letter, but not the first one.
            var result = Regex.Replace(input, "(\\B[A-Z])", " $1");
            return result;
        }


       
        public static bool isNumber(this string input)
        {
            var match = Regex.Match(input, @"^[0-9]+$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static int extractNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var match = Regex.Match(input, "[0-9]+", RegexOptions.IgnoreCase);
            return match.Success ? match.Value.toInt() : 0;
        }

        



        public static string toProper(this string input)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(input);
             
        }
        public static string toExpression(this string input)
        {
            input = Regex.Replace(input, @"[^\u0000-\u007f]", string.Empty);
            return input;
        }
        public static string toSentance(this string input)
        {
            var sourceString = input;
            var lowerCase = sourceString.ToLower();
            var r = new Regex( @"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
            var result = r.Replace(lowerCase, s => s.Value.ToUpper());
            return result;
        }
        
        public static string Asc(this string src)
        {
            string tar = "";
            for (int k = 0; k < src.Length; k++)
            {
                tar = tar + Chr(255 - Asc(src.Substring(k, 1)[0]));
            }
            return tar;
        }
        private static int Asc(char ch)
        {
            char[] arr = new char[1];
            arr[0] = ch;
            byte i1 = Encoding.Default.GetBytes(arr)[0];
            return i1;
        }
        private static string Chr(int ascii)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var encoding = Encoding.GetEncoding(culture.TextInfo.ANSICodePage);
            char[] buffer = new char[1];

            encoding.GetChars(new byte[] { (byte)ascii }, 0, 1, buffer, 0);
            return buffer[0].ToString();
        }

    }
}
