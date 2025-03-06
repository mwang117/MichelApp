using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MichelAPP.Models;
using MichelAPP.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

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

        // Propriétés pour le formulaire
        public string NewTitle { get; set; } = "";
        public string NewDescription { get; set; } = "";
        public string NewImage { get; set; } = "";
        public string NewIngredients { get; set; } = "";

        // Commande pour ajouter un café
        public ICommand AddCoffeeCommand { get; }

        public CoffeeViewModel()
        {
            _coffeeService = new CoffeeService();
            LoadCoffees();

            // Définition de la commande Ajouter
            AddCoffeeCommand = new Command(AddCoffee);
        }

        private async void LoadCoffees()
        {
            IsLoading = true;
            var coffeeList = await _coffeeService.GetCoffeesAsync();
            Coffees.Clear();
            foreach (var coffee in coffeeList)
            {
                Coffees.Add(coffee);
            }
            IsLoading = false;
        }

        // Méthode pour ajouter un café à la liste
        private void AddCoffee()
        {
            if (string.IsNullOrWhiteSpace(NewTitle) || string.IsNullOrWhiteSpace(NewDescription))
                return;

            var newCoffee = new CoffeeModel
            {
                Id = Coffees.Count + 1,
                Title = NewTitle,
                Description = NewDescription,
                Image = string.IsNullOrWhiteSpace(NewImage) ? "default.png" : NewImage,
                Ingredients = NewIngredients.Split(',')
            };

            Coffees.Add(newCoffee);

            // Réinitialisation des champs
            NewTitle = "";
            NewDescription = "";
            NewImage = "";
            NewIngredients = "";
            OnPropertyChanged(nameof(NewTitle));
            OnPropertyChanged(nameof(NewDescription));
            OnPropertyChanged(nameof(NewImage));
            OnPropertyChanged(nameof(NewIngredients));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
