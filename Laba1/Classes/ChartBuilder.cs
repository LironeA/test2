using Microcharts;
using SkiaSharp;
using System.Collections.Generic;

namespace Laba1.Classes
{
    internal class ChartBuilder
    {
        private List<ChartEntry> _entries = new List<ChartEntry>();

        public void FillEntriesUsingData(int[] entries)
        {
            var frequencyDictionary = FrequencyCounter.CountFrequency(entries);

            _entries.Clear();
            foreach (var frequencyPair in frequencyDictionary)
            {
                _entries.Add(new ChartEntry(frequencyPair.Value)
                {
                    Label = frequencyPair.Key.ToString(),
                    ValueLabel = frequencyPair.Value.ToString(),
                    Color = SKColor.Parse("#266489")
                });
            }
        }

        public Chart BuildBarChart()
        {
            return new BarChart()
            {
                Entries = _entries,
                LabelTextSize = 15,
            };
        }
    }
}
