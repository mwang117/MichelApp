using Microsoft.Maui.Controls;
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
    }
}
