using System;
using System.Linq;

namespace App.Utils
{
    public static class Utils
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input?.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}