using System;
using System.Collections.Generic;

namespace Laba1.Classes.Helpers
{
    public static class StringExtensions
    {
        public static bool TryParseArray(this string str, out int[] array)
        {
            array = null;
            if (string.IsNullOrWhiteSpace(str))
                return false;

            string[] tokens = str.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> integers = new List<int>();
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                    integers.Add(number);
                else
                    return false;
            }
            array = integers.ToArray();
            return true;
        }
    }
}
