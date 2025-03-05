using Microsoft.Maui.Controls;

namespace MichelAPP
{
    public partial class AccueilPage : ContentPage
    {
        public AccueilPage()
        {
            InitializeComponent();
        }

        // Aller à la page des GIFs
        private async void OnGifButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GifPage());
        }
    }
}
