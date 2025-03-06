using System.Collections.ObjectModel;
using MichelAPP.Models;
using MichelAPP.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MichelAPP.ViewModels
{
    public class CoffeeViewModel : INotifyPropertyChanged
    {
        private readonly CoffeeService _coffeeService;
        public ObservableCollection<CoffeeModel> Coffees { get; set; } = new();
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(); 
            }
        }

        // Propriétés utilisées pour ajouter un nouveau café via le formulaire
        public string NewTitle { get; set; } = "";
        public string NewDescription { get; set; } = "";
        public string NewImage { get; set; } = "";
        public string NewIngredients { get; set; } = "";
        public ICommand AddCoffeeCommand { get; }
        public ICommand PickImageCommand { get; }

        // Constructeur du ViewModel
        public CoffeeViewModel()
        {
            _coffeeService = new CoffeeService();
            LoadCoffees();

            // Initialisation des commandes
            AddCoffeeCommand = new Command(AddCoffee);
            PickImageCommand = new Command(async () => await AvoirImage());
        }

        // Charge les cafés depuis l'API et met à jour la liste observable Coffees.
        private async void LoadCoffees()
        {
            IsLoading = true;
            var coffeeList = await _coffeeService.GetCoffeesAsync();
            Coffees.Clear();

            foreach (var coffee in coffeeList)
            {
                Coffees.Add(coffee); // Ajoute chaque café dans la liste observable
            }

            IsLoading = false;
        }

        // Ajoute un nouveau café à la liste des cafés affichés.
        private void AddCoffee()
        {
            if (string.IsNullOrWhiteSpace(NewTitle) || string.IsNullOrWhiteSpace(NewDescription))
                return;

            // Création d'un nouvel objet CoffeeModel
            var newCoffee = new CoffeeModel
            {
                Id = Coffees.Count + 1,
                Title = NewTitle,
                Description = NewDescription,
                Image = string.IsNullOrWhiteSpace(NewImage) ? "default.png" : NewImage, // Image par défaut si l'utilisateur ne fournit pas d'image
                Ingredients = NewIngredients.Split(',')
            };

            Coffees.Add(newCoffee);
            OnPropertyChanged(nameof(Coffees));

            // Réinitialisation des champs après l'ajout
            NewTitle = "";
            NewDescription = "";
            NewImage = "";
            NewIngredients = "";

            // Notifie l'interface utilisateur que les champs ont été réinitialisés
            OnPropertyChanged(nameof(NewTitle));
            OnPropertyChanged(nameof(NewDescription));
            OnPropertyChanged(nameof(NewImage));
            OnPropertyChanged(nameof(NewIngredients));
        }

        // Notifie l'interface utilisateur lorsqu'une propriété change.
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Permet à l'utilisateur de choisir une image depuis son appareil.
        public async Task AvoirImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choisissez une image"
            });

            if (result != null)
            {
                NewImage = result.FullPath;
                OnPropertyChanged(nameof(NewImage));
            }
        }
    }
}
