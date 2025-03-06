using MichelAPP.Models;
using Microsoft.Maui.Controls;

namespace MichelAPP
{
    public partial class DeuxiemePage : ContentPage
    {
        public DeuxiemePage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedCoffee = button?.CommandParameter as CoffeeModel;

            if (selectedCoffee != null)
            {
                await Navigation.PushAsync(new DetailPage(selectedCoffee));
            }
        }
    }
}
