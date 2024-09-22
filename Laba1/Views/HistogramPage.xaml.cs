using Microsoft.Maui.Controls;
using Laba1.ViewModels;
using Laba1.Classes.Helpers;
using System;

namespace Laba1.Views
{
    [QueryProperty(nameof(InitialArray), "initialArray")]
    [QueryProperty(nameof(SortedArray), "sortedArray")]
    public partial class HistogramPage : ContentPage
    {
        private HistogramViewModel viewModel;

        private string initialArray;
        public string InitialArray
        {
            get => initialArray;
            set
            {
                initialArray = Uri.UnescapeDataString(value);
                OnPropertyChanged(nameof(InitialArray));
                LoadCharts();
            }
        }

        private string sortedArray;
        public string SortedArray
        {
            get => sortedArray;
            set
            {
                sortedArray = Uri.UnescapeDataString(value);
                OnPropertyChanged(nameof(SortedArray));
                LoadCharts();
            }
        }

        public HistogramPage()
        {
            InitializeComponent();
            viewModel = BindingContext as HistogramViewModel;
        }

        private void LoadCharts()
        {
            if (InitialArray.TryParseArray(out int[] initial) && SortedArray.TryParseArray(out int[] sorted))
            {
                viewModel.GenerateCharts(initial, sorted);
            }
        }
    }
}
