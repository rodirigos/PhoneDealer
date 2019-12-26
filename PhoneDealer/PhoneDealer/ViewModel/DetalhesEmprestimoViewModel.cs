using PhoneDealer.Models;
using PhoneDealer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhoneDealer.ViewModel
{
    public class DetalhesEmprestimoViewModel : BaseViewModel
    {
        IArmazenamentoService servicoArmazenamento;
        public DetalhesEmprestimoViewModel()
        {
            servicoArmazenamento = DependencyService.Get<IArmazenamentoService>();
            listaEmprestimo = servicoArmazenamento.ResgatarListaEmprestimo();
            OnAppearingCommand = new Command(() => NoAparecimento());
            DevolverCommand = new Command(async () => await Devolver());
            RemoverCommand = new Command(async () => await Remover());
            CancelarCommand = new Command(async () => await App.navigationPage.PopAsync());
          
          
        }

        #region Propridades
        private List<TelefoneEmprestimo> listaEmprestimo { get; set; }

        private TelefoneEmprestimo emprestimoSelecionado;
        public TelefoneEmprestimo EmprestimoSelecionado
        {
            get => emprestimoSelecionado;
            set => SetValue(ref emprestimoSelecionado, value);
        }

        private bool naoDevolvido;
        public bool NaoDevolvido { get => naoDevolvido; set => SetValue(ref naoDevolvido, value); }

        #endregion

        #region Commandos

        public ICommand CancelarCommand { get; set; }
        public ICommand RemoverCommand { get; set; }
        public ICommand DevolverCommand { get; set; }
        public ICommand OnAppearingCommand { get; set; }

        #endregion

        #region Funcoes
        
        public void NoAparecimento()
        {
            NaoDevolvido = !emprestimoSelecionado.Devolvido;
            
        }

        public async Task Devolver()
        {
            var emprestado =listaEmprestimo.FirstOrDefault(x => x.Id == EmprestimoSelecionado.Id);
            emprestado.Devolvido = true;
            emprestado.DataDevolvida = DateTime.Now;
            servicoArmazenamento.SalvarListaEmprestimo(listaEmprestimo);
            MessagingCenter.Send<string>("Update", "");
            await App.navigationPage.PopAsync();
        }

        public async Task Remover()
        {
            listaEmprestimo.RemoveAll(x => x.Id == EmprestimoSelecionado.Id);
            servicoArmazenamento.SalvarListaEmprestimo(listaEmprestimo);
            MessagingCenter.Send<string>("Update", "");
            await App.navigationPage.PopAsync();
        }

        #endregion

    }
}
