using MichelAPP.Models;

namespace MichelAPP.Views.Deuxième_Page
{
    public partial class DetailPage
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
