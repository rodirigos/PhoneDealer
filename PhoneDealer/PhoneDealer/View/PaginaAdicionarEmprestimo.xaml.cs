using PhoneDealer.Models;
using PhoneDealer.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaAdicionarEmprestimo : ContentPage
    {
        public PaginaAdicionarEmprestimo(ItemEmprestimo emprestimo)
        {
            InitializeComponent();
            BindingContext = new AdicionarEmprestimoViewModel(emprestimo);
        }
    }
}