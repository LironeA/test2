using System.Collections.Generic;

namespace Laba1.Classes
{
    internal class FrequencyCounter
    {
        public static Dictionary<int, int> CountFrequency(int[] entries)
        {
            var frequencyDictionary = new Dictionary<int, int>();
            foreach (var number in entries)
            {
                if (frequencyDictionary.ContainsKey(number))
                    frequencyDictionary[number]++;
                else
                    frequencyDictionary[number] = 1;
            }

            return frequencyDictionary;
        }
    }
}
