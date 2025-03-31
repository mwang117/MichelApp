using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;

namespace MichelAPP.ViewModels
{
    public class DernierePageViewModel : INotifyPropertyChanged
    {
        private bool _modeSombre = false;
        private string _citationActuelle = "Appuyez sur le bouton pour obtenir un conseil !";

        public string CitationActuelle
        {
            get => _citationActuelle;
            set
            {
                _citationActuelle = value;
                OnPropertyChanged(nameof(CitationActuelle));
            }
        }

        public Color CouleurFond => _modeSombre ? Colors.Black : Colors.Gray;

        public ICommand ChangerThemeCommande { get; }
        public ICommand ObtenirCitationCommande { get; }

        public DernierePageViewModel()
        {
            ChangerThemeCommande = new Command(ChangerMode);
            ObtenirCitationCommande = new Command(async () => await ObtenirCitationAleatoire());
        }

        // Méthode pour changer le mode sombre ou clair
        private void ChangerMode()
        {
            _modeSombre = !_modeSombre;
            OnPropertyChanged(nameof(CouleurFond));
        }

        // Méthode pour obtenir depuis l'API une citation aléatoire
        private async Task ObtenirCitationAleatoire()
        {
            try
            {
                using var client = new HttpClient();
                var reponse = await client.GetStringAsync("https://api.adviceslip.com/advice");
                var json = JsonSerializer.Deserialize<JsonElement>(reponse);

                CitationActuelle = json.GetProperty("slip").GetProperty("advice").GetString();
            }
            catch (Exception)
            {
                CitationActuelle = "Impossible de récupérer un conseil.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
