using PhoneDealer.Models;
using PhoneDealer.Services;
using PhoneDealer.Util;
using PhoneDealer.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class ListaTelefonesViewModel : BaseViewModel
    {

        readonly IArmazenamentoService servicoArmazenamento;
        public ListaTelefonesViewModel()
        {
            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            OnAppearingCommand = new Command(() => NoAparecimento());
            IrParaRegistroCommand = new Command(async() => await IrPaginaRegistro());
            DetalhesEmprestimoCommand = new Command<TelefoneEmprestimo>(async (telefone) => await IrParaDetalhesEmprestimo(telefone));
            ListaTelefone = new ObservableCollection<TelefoneEmprestimo>();       
        }

        #region Propriedades

        public ObservableCollection<TelefoneEmprestimo> ListaTelefone { get; set; }

        #endregion

        #region Comandos

        public ICommand OnAppearingCommand { get; set; }
        public ICommand IrParaRegistroCommand { get; set; }
        public ICommand DetalhesEmprestimoCommand { get; set; }

        #endregion

        #region Funções

        public void NoAparecimento() 
        {
            ListaTelefone.Clear();
            servicoArmazenamento.ResgatarListaEmprestimo().ForEach(x => ListaTelefone.Add(x));
        }

        public async Task IrPaginaRegistro()
        {
            await App.navigationPage.PushAsync(new PaginaAdicionarEmprestimo());
        }

        public async Task IrParaDetalhesEmprestimo(TelefoneEmprestimo telefoneEmprestimo)
        {
            await App.navigationPage.PushAsync(new PaginaDetalheEmprestimo(telefoneEmprestimo));
        }

        #endregion
    }
}
