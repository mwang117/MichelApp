using MichelAPP.Models;
using MichelAPP.ViewModels;

namespace MichelAPP.Views.Deuxième_Page
{
    public partial class DeuxiemePage
    {
        private readonly CoffeeViewModel _viewModel;

        public DeuxiemePage()
        {
            InitializeComponent();

            _viewModel = this.Handler?.MauiContext?.Services.GetService<CoffeeViewModel>()
                         ?? throw new InvalidOperationException("CoffeeViewModel not found");
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnPropertyChanged(nameof(_viewModel.Coffees)); // Rafraîchit la liste
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

