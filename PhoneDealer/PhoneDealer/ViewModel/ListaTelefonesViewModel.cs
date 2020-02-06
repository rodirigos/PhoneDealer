using PhoneDealer.Models;
using PhoneDealer.Services;
using PhoneDealer.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class ListaTelefonesViewModel : BaseViewModel
    {

        readonly IArmazenamentoService servicoArmazenamento;
        readonly ILeitorQrService servicoLeitorQr;

        public ListaTelefonesViewModel()
        {
            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            servicoLeitorQr = DependencyService.Get<ILeitorQrService>();
            OnAppearingCommand = new Command(() => NoAparecimento());
            AbrirConfiguracaoCommand = new Command(async () => await AbrirConfiguracao());
            AbrirAjudaCommand = new Command(async () => await App.navigationPage.PushAsync(new PaginaAjuda()));
            DetalhesEmprestimoCommand = new Command<ItemEmprestimoDao>(async (telefone) => await IrParaDetalhesEmprestimo(telefone));
            EmprestarDevolverCommand = new Command(async () => await EmprestarDevolver());
            ListaTelefone = new ObservableCollection<ItemEmprestimoDao>();
            MessagingCenter.Subscribe<string>(this, "Update", (sender) =>
            {
                NoAparecimento();
            });
        }

        #region Propriedades
        public ObservableCollection<ItemEmprestimoDao> ListaTelefone { get; set; }
        private List<ItemEmprestimo> itensPossiveis { get; set; }


        #endregion

        #region Propriedades de visibilidade

      
        public bool ItensVazios
        {
            get => (!ListaTelefone.Any());
        }


        #endregion

        #region Comandos

        public ICommand OnAppearingCommand { get; set; }
        public ICommand IrParaRegistroCommand { get; set; }
        public ICommand DetalhesEmprestimoCommand { get; set; }
        public ICommand EmprestarDevolverCommand { get; set; }
        public ICommand AbrirConfiguracaoCommand { get; set; }
        public ICommand AbrirAjudaCommand { get; set; }

        #endregion

        #region Funções

        public void NoAparecimento()
        {
            itensPossiveis = servicoArmazenamento.ResgatarListaItens();
            ListaTelefone.Clear();
            servicoArmazenamento.ResgatarListaEmprestimo()
                .GroupBy(x => x.IdTelefone)
                .Select(x => x.OrderByDescending(y => y.DataAtualizada).FirstOrDefault())
                .ToList().ForEach(x => ListaTelefone.Add(x));
            OnPropertyChanged("ItensVazios");
        }

        //public async Task IrPaginaRegistro()
        //{
        //    await App.navigationPage.PushAsync(new PaginaAdicionarEmprestimo());
        //}

        public async Task IrParaDetalhesEmprestimo(ItemEmprestimoDao telefoneEmprestimo)
        {
            await App.navigationPage.PushAsync(new PaginaDetalheEmprestimo(telefoneEmprestimo));
        }

        public async Task EmprestarDevolver()
        {
            try
            {
                string resultado = await servicoLeitorQr.LerQrCode();

                var item = itensPossiveis.FirstOrDefault(x => x.Id == resultado);
                if (item != null)
                    await App.navigationPage.PushAsync(new PaginaAdicionarEmprestimo(item));
                else
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Item Não cadastrado", "Cancelar");

            }
            catch (System.Exception e)
            {
            }

        }

        public async Task AbrirConfiguracao()
        {
            await App.navigationPage.PushAsync(new PaginaConfiguracao());
        }

        #endregion
    }
}
