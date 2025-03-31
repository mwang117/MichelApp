using MichelAPP.ViewModels;

namespace MichelAPP.Views.Dernière_Page
{
    public partial class DernierePage
    {
        public DernierePage()
        {
            InitializeComponent();
            BindingContext = new DernierePageViewModel();
        }
    }
}
