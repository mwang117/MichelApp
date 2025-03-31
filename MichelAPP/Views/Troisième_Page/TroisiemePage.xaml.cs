using MichelAPP.ViewModels;

namespace MichelAPP.Views.Troisième_Page
{
    public partial class TroisiemePage
    {
        private readonly CoffeeViewModel _viewModel;
        
        public TroisiemePage()
        {
            InitializeComponent();

            _viewModel = this.Handler?.MauiContext?.Services.GetService<CoffeeViewModel>()
                         ?? throw new InvalidOperationException("CoffeeViewModel not found");
            BindingContext = _viewModel;
        }

        private async void OnSelectImage(object sender, EventArgs e)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images, // Filtre uniquement les images
                PickerTitle = "Choisissez une image"
            });

            if (result != null)
            {
                var viewModel = BindingContext as ViewModels.CoffeeViewModel;
                if (viewModel != null)
                {
                    viewModel.NewImage = result.FullPath; // Stocke le chemin de l'image
                    viewModel.OnPropertyChanged(nameof(viewModel.NewImage)); // Mise à jour UI
                }
            }
        }
    }
}
