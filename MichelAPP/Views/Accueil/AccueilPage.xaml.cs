namespace MichelAPP.Views.Accueil

{
    public partial class AccueilPage
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
