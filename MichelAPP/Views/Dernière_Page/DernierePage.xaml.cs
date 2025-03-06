using MichelAPP.ViewModels;

namespace MichelAPP
{
    public partial class DernierePage : ContentPage
    {
        public DernierePage()
        {
            InitializeComponent();
            BindingContext = new DernierePageViewModel();
        }
    }
}
