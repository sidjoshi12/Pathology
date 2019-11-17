using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathology
{
    public static class ObjectExtensions
    {

        public static DateTime toDate(this object input, bool throwExceptionIfFailed = false)
        {
            string strdate = input.ToString();
            DateTime result;
            var valid = DateTime.TryParse(strdate, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));
            return result;
        }
    }
}
