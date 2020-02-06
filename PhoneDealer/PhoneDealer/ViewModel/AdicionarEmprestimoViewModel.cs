using PhoneDealer.Models;
using PhoneDealer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class AdicionarEmprestimoViewModel : BaseViewModel
    {

        readonly IArmazenamentoService servicoArmazenamento;
        public AdicionarEmprestimoViewModel(ItemEmprestimo itemEncontrado)
        {
            ItemEncontrado = itemEncontrado;
            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            ListaTelefones = new ObservableCollection<ItemEmprestimo>();
            ListaEmprestador = new ObservableCollection<Emprestador>();

            OnAppearingCommand = new Command(() => NoAparecimento());

            AdicionarDevolverEmprestimoCommand = new Command(async () => await AdicionarDevolverEmprestimo());
            VoltarTelaDeEmprestimoCommand = new Command(async () => await App.navigationPage.PopAsync());

            ListaHistoricoTelefone = servicoArmazenamento.ResgatarListaEmprestimo();
            listaItens = servicoArmazenamento.ResgatarListaItens();
            listaEmprestador = servicoArmazenamento.ResgatarListaEmprestador();

            Devolucao = itemEncontrado.Devolucao;
        }


        #region Propriedades

        private ItemEmprestimo itemEncontrado;
        public ItemEmprestimo ItemEncontrado
        {
            get => itemEncontrado;
            set => SetValue(ref itemEncontrado, value);
        }
        public ObservableCollection<Emprestador> ListaEmprestador { get; set; }
        public ObservableCollection<ItemEmprestimo> ListaTelefones { get; set; }
        public int Indice { get; set; }
        private List<ItemEmprestimoDao> ListaHistoricoTelefone { get; set; }
        private List<ItemEmprestimo> listaItens { get; set; }
        private List<Emprestador> listaEmprestador { get; set; }

        private bool devolucao;
        public bool Devolucao
        {
            get => devolucao;
            set
            {
                SetValue(ref devolucao, value);
                OnPropertyChanged("Emprestimo");
            }

        }

        public bool Emprestimo
        {
            get => !Devolucao;
        }


        #endregion

        #region Comandos

        public ICommand VoltarTelaDeEmprestimoCommand { get; set; }
        public ICommand AdicionarDevolverEmprestimoCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }

        #endregion

        #region Funcoes

        public async Task AdicionarDevolverEmprestimo()
        {
            if (Emprestimo)
            {
                var itemEmprestado = listaItens.FirstOrDefault(x => x.Id == ItemEncontrado.Id);
                itemEmprestado.Devolucao = true;
                servicoArmazenamento.AtualizarItem(itemEmprestado);
                

                ItemEmprestimoDao telefoneEmprestimo = new ItemEmprestimoDao()
                {
                    Modelo = ItemEncontrado.Descricao,
                    DataEmprestada = DateTime.Now,
                    DataAtualizada = DateTime.Now,
                    Devolvido = false,
                    NomeEmprestador = ListaEmprestador[Indice].Nome,
                    IdTelefone = ItemEncontrado.Id,
                    Id = Guid.NewGuid()
                };
                ListaHistoricoTelefone.Add(telefoneEmprestimo);
                servicoArmazenamento.AdicionarEmprestimo(telefoneEmprestimo);

            }
            else
            {
                var itemEmprestado = listaItens.FirstOrDefault(x => x.Id == ItemEncontrado.Id);
                itemEmprestado.Devolucao = false;
                servicoArmazenamento.AtualizarItem(itemEmprestado);
                var encontrado = ListaHistoricoTelefone.OrderByDescending(x => x.DataAtualizada).FirstOrDefault(x => x.IdTelefone == ItemEncontrado.Id);
                encontrado.Devolvido = true;
                encontrado.DataDevolvida = DateTime.Now;
                encontrado.DataAtualizada = DateTime.Now;
                servicoArmazenamento.AtualizarEmprestimo(encontrado);
            }
            await App.navigationPage.PopAsync();

        }

        public void NoAparecimento()
        {
            ListaEmprestador.Clear();
            ListaTelefones.Clear();
            listaEmprestador.ForEach(x => ListaEmprestador.Add(x));
            listaItens.ForEach(x => ListaTelefones.Add(x));
        }

        #endregion

    }
}
