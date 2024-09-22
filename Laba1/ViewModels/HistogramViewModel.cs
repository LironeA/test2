using System.ComponentModel;
using Laba1.Classes;
using Microcharts;
using SkiaSharp;

namespace Laba1.ViewModels
{
    public class HistogramViewModel : INotifyPropertyChanged
    {
        private Chart _initialChart;
        public Chart InitialChart
        {
            get => _initialChart;
            set
            {
                _initialChart = value;
                OnPropertyChanged(nameof(InitialChart));
            }
        }

        private Chart _sortedChart;
        public Chart SortedChart
        {
            get => _sortedChart;
            set
            {
                _sortedChart = value;
                OnPropertyChanged(nameof(SortedChart));
            }
        }

        public void GenerateCharts(int[] initialArray, int[] sortedArray)
        {
            var initialBuilder = new ChartBuilder();
            initialBuilder.FillEntriesUsingData(initialArray);
            InitialChart = initialBuilder.BuildBarChart();

            var sortedBuilder = new ChartBuilder();
            sortedBuilder.FillEntriesUsingData(sortedArray);
            SortedChart = sortedBuilder.BuildBarChart();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
