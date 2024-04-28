using System;
using System.Collections.Generic;
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
        
        public static void AddIfNotEmpty(this List<string> list, string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                list.Add(item);
            }
        }
    }
}