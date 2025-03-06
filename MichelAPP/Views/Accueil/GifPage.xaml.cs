using Microsoft.Maui.Controls;

namespace MichelAPP
{
    public partial class GifPage : ContentPage
    {
        public GifPage()
        {
            InitializeComponent();
        }

        // Revenir à la page précédente (Accueil)
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
