using PhoneDealer.Models;
using PhoneDealer.Services;
using PhoneDealer.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class ConfiguracaoViewModel : BaseViewModel
    {
        readonly IArmazenamentoService servicoArmazenamento;
        public ConfiguracaoViewModel()
        {

            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            ItensAtivoCommand = new Command(() => AtivarItens());
            UsuariosAtivoCommand = new Command(() => AtivarUsuarios());
            VoltarCommand = new Command(async () => await App.navigationPage.PopAsync());
            OnAppearingCommand = new Command(() => NoAparecimento());
            CadastrarCommand = new Command(() => Cadastrar());
            CopiarItemCommand = new Command<ItemEmprestimo>(async (x) => await CopiarItem(x));
            RemoverItemCommand = new Command<ItemEmprestimo>((x) => RemoverItem(x));
            RemoverEmprestadorCommand = new Command<Emprestador>((x) => RemoverEmprestador(x));

            ListaEmprestador = new ObservableCollection<Emprestador>();
            ListaItemEmprestimo = new ObservableCollection<ItemEmprestimo>();

            listaEmprestador = servicoArmazenamento.ResgatarListaEmprestador();
            listaItemEmprestimo = servicoArmazenamento.ResgatarListaItens();
            ItensAtivo = true;

            
        }

        #region Propriedades

        private List<Emprestador> listaEmprestador;
        private List<ItemEmprestimo> listaItemEmprestimo;
       
        public ObservableCollection<Emprestador> ListaEmprestador { get; set; }
        public ObservableCollection<ItemEmprestimo> ListaItemEmprestimo { get; set; }
        private bool usuarioAtivo;
        
        public bool UsuarioAtivo
        {
            get => usuarioAtivo;
            set
            {
                SetValue(ref usuarioAtivo, value);

            }
        }

        private bool itensAtivo;
        public bool ItensAtivo
        {
            get => itensAtivo;
            set
            {
                SetValue(ref itensAtivo, value);

            }
        }

        private string nomeItem;
        public string NomeItem
        {
            get => nomeItem;
            set => SetValue(ref nomeItem, value);
        }


        #endregion

        #region Commands
        public ICommand ItensAtivoCommand { get; set; }
        public ICommand UsuariosAtivoCommand { get; set; }
        public ICommand VoltarCommand { get; set; }
        public ICommand CadastrarCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }
        public ICommand CopiarItemCommand { get; set; }
        public ICommand RemoverItemCommand { get; set; }
        public ICommand RemoverEmprestadorCommand { get; set; }
        

        #endregion

        #region Funções

        private void AtivarItens()
        {
            ItensAtivo = true;
            UsuarioAtivo = false;
            OnPropertyChanged("CorFundoItens");
            OnPropertyChanged("CorFundoUsuarios");
            OnPropertyChanged("CorTextoItens");
            OnPropertyChanged("CorTextoUsuarios");
        }

        private void AtivarUsuarios()
        {
            UsuarioAtivo = true;
            ItensAtivo = false;
            OnPropertyChanged("CorFundoItens");
            OnPropertyChanged("CorFundoUsuarios");
            OnPropertyChanged("CorTextoItens");
            OnPropertyChanged("CorTextoUsuarios");
        }

        private void Cadastrar()
        {
            if (ItensAtivo)
            {
                if (!string.IsNullOrEmpty(NomeItem))
                {
                    ItemEmprestimo itemEmprestimo = new ItemEmprestimo(Guid.NewGuid().ToString(), NomeItem);
                    ListaItemEmprestimo.Add(itemEmprestimo);
                    listaItemEmprestimo.Add(itemEmprestimo);
                    servicoArmazenamento.AdicionarItem(itemEmprestimo);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(NomeItem) && UsuarioAtivo)
                {
                    Emprestador emprestador = new Emprestador(Guid.NewGuid().ToString(), NomeItem);
                    ListaEmprestador.Add(emprestador);
                    listaEmprestador.Add(emprestador);
                    servicoArmazenamento.AdicionarEmprestador(emprestador);
                }
            }
            NomeItem = string.Empty;

        }

        private void NoAparecimento()
        {

            ListaEmprestador.Clear();
            ListaItemEmprestimo.Clear();

            listaEmprestador.ForEach(x => ListaEmprestador.Add(x));
            listaItemEmprestimo.ForEach(x => ListaItemEmprestimo.Add(x));
        }

        private async Task CopiarItem(ItemEmprestimo item)
        {
            await Clipboard.SetTextAsync(item.Id);
            await App.navigationPage.PushAsync(new PaginaExibirQrCode(item));
        }
        private async Task RemoverItem(ItemEmprestimo item)
        {
            var resp = await App.navigationPage.DisplayAlert("Alerta", "Você tem certeza que deseja remover esse Item?", "Sim", "Cancelar");
            if(resp)
            {
                ListaItemEmprestimo.Remove(item);
                listaItemEmprestimo.Remove(item);
                servicoArmazenamento.RemoverItem(item);
            }
            
            
        }

        private async Task RemoverEmprestador(Emprestador emprestador)
        {

            var resp = await App.navigationPage.DisplayAlert("Alerta", "Você tem certeza que deseja remover esse usuário?", "Sim", "Cancelar");
            if(resp)
            {
                ListaEmprestador.Remove(emprestador);
                listaEmprestador.Remove(emprestador);
                servicoArmazenamento.RemoverEmprestador(emprestador);
            }
            
        }


        #endregion

        #region Propriedades de visibilidade

        public Color CorFundoItens
        {
            get
            {
                if (ItensAtivo)
                    return (Color)Application.Current.Resources["BackgroundSelected"];
                else
                    return (Color)Application.Current.Resources["BackgroundUnselected"];
            }
        }
        public Color CorFundoUsuarios
        {
            get
            {
                if (UsuarioAtivo)
                    return (Color)Application.Current.Resources["BackgroundSelected"];
                else
                    return (Color)Application.Current.Resources["BackgroundUnselected"];
            }
        }

        public Color CorTextoItens
        {
            get
            {
                if (ItensAtivo)
                    return Color.White;
                else
                    return (Color)Application.Current.Resources["TextColor"];
            }
        }

        public Color CorTextoUsuarios
        {
            get
            {
                if (UsuarioAtivo)
                    return Color.White;
                else
                    return (Color)Application.Current.Resources["TextColor"];
            }
        }


        #endregion

    }
}
