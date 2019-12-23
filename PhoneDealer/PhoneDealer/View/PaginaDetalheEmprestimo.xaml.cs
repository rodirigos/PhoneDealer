using PhoneDealer.Models;
using PhoneDealer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaDetalheEmprestimo : ContentPage
    {
       
        public PaginaDetalheEmprestimo(TelefoneEmprestimo telefoneEmprestimo)
        {
            InitializeComponent();
            BindingContext = new DetalhesEmprestimoViewModel();
            (BindingContext as DetalhesEmprestimoViewModel).EmprestimoSelecionado = telefoneEmprestimo;
            
        }
    }
}