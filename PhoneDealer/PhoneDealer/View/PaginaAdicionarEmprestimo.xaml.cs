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
    public partial class PaginaAdicionarEmprestimo : ContentPage
    {
        public PaginaAdicionarEmprestimo()
        {
            InitializeComponent();
            BindingContext = new AdicionarEmprestimoViewModel();
        }
    }
}