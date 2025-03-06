using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MichelAPP
{
    public partial class TroisiemePage : ContentPage
    {
        public TroisiemePage()
        {
            InitializeComponent();
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
