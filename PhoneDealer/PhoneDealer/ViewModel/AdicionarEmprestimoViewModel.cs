using PhoneDealer.Models;
using PhoneDealer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class AdicionarEmprestimoViewModel : BaseViewModel
    {
        readonly IArmazenamentoService servicoArmazenamento;
        public AdicionarEmprestimoViewModel()
        {
            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            ListaTelefones = new ObservableCollection<Telefone>();
            OnAppearingCommand = new Command(() =>  NoAparecimento());
            AdicionarEmprestimoCommand = new Command(async() => await  AdicionarEmprestimo());
            VoltarTelaDeEmprestimoCommand = new Command(async () => await App.navigationPage.PopAsync());
            ListaHistoricoTelefone = servicoArmazenamento.ResgatarListaEmprestimo();
        }


        #region Propriedades

        public ObservableCollection<Telefone> ListaTelefones { get; set; }
        public Telefone TelefoneSelecionado { get => ListaTelefones[Indice]; }

        public int Indice { get; set; }

        private List<TelefoneEmprestimo> ListaHistoricoTelefone { get; set; }

        public string NomeEmprestador { get; set; }
         


        #endregion

        #region Comandos

        public ICommand VoltarTelaDeEmprestimoCommand { get; set; }
        public ICommand AdicionarEmprestimoCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }

        #endregion

        #region Funcoes

        public async Task AdicionarEmprestimo()
        {

            TelefoneEmprestimo telefoneEmprestimo = new TelefoneEmprestimo()
            {
                Modelo = TelefoneSelecionado.Modelo,
                DataEmprestada = DateTime.Now,
                Devolvido = false,
                NomeEmprestador = NomeEmprestador,
                Id = Guid.NewGuid()
            };
            ListaHistoricoTelefone.Add(telefoneEmprestimo);
            servicoArmazenamento.SalvarListaEmprestimo(ListaHistoricoTelefone);
            await App.navigationPage.PopAsync();
        }

        public void NoAparecimento()
        {
            ListaTelefones.Clear();
            Util.Mock.TelefonesModeloMock.ForEach(x => ListaTelefones.Add(x));
        }

        #endregion

    }
}
