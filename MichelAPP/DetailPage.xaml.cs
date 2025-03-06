using Microsoft.Maui.Controls;
using MichelAPP.Models;
using System.Linq;

namespace MichelAPP
{
    public partial class DetailPage : ContentPage
    {
        public CoffeeModel Coffee { get; set; }

        public DetailPage(CoffeeModel selectedCoffee)
        {
            InitializeComponent();
            Coffee = selectedCoffee;
            Coffee.IngredientsList = string.Join(", ", Coffee.Ingredients);
            BindingContext = Coffee;
        }
    }
}
