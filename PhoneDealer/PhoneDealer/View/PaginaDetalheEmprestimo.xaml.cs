using PhoneDealer.Models;
using PhoneDealer.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaDetalheEmprestimo : ContentPage
    {

        public PaginaDetalheEmprestimo(ItemEmprestimoDao telefoneEmprestimo)
        {
            InitializeComponent();
            BindingContext = new DetalhesEmprestimoViewModel();
            (BindingContext as DetalhesEmprestimoViewModel).EmprestimoSelecionado = telefoneEmprestimo;

        }
    }
}