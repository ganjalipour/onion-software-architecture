using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Common.Utility.Extentions
{
    public static class StringExtention
    {
        public static string ReplaceAll(this string input, char target)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(target);
            }

            return sb.ToString();
        }
    }
}
