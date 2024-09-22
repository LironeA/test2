using Microsoft.Maui.Controls;
using System;

namespace Laba1.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void LearnMore_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Дізнатися більше", "Цей додаток демонструє різні методи сортування масивів, їх ефективність та візуалізацію результатів.", "OK");
        }
    }
}
