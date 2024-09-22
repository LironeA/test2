using Microsoft.Maui.Controls;
using Laba1.Views;

namespace Laba1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Реєструємо маршрути
            Routing.RegisterRoute(nameof(HistogramPage), typeof(HistogramPage));
        }
    }
}
