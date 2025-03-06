using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MichelAPP.Models;
using MichelAPP.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MichelAPP.ViewModels
{
    public class CoffeeViewModel : INotifyPropertyChanged
    {
        private readonly CoffeeService _coffeeService;
        public ObservableCollection<CoffeeModel> Coffees { get; set; }
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

        public CoffeeViewModel() 
        {
            _coffeeService = new CoffeeService();
            Coffees = new ObservableCollection<CoffeeModel>();
            LoadCoffees();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
