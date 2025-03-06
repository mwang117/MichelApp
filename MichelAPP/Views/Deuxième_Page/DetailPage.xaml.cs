using MichelAPP.Models;

namespace MichelAPP
{
    public partial class DetailPage : ContentPage
    {
        public CoffeeModel Coffee { get; set; }

        public DetailPage(CoffeeModel selectedCoffee)
        {
            InitializeComponent();
            Coffee = selectedCoffee;
            BindingContext = Coffee;
        }

        private async void OnRetourButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
