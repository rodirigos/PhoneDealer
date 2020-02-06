using PhoneDealer.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaTelefones : ContentPage
    {
        public PaginaListaTelefones()
        {
            InitializeComponent();
            BindingContext = new ListaTelefonesViewModel();
        }
    }
}