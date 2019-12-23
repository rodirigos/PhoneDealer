using PhoneDealer.Models;
using PhoneDealer.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        }

        #region Propridades
        private List<TelefoneEmprestimo> listaEmprestimo { get; set; }

        private TelefoneEmprestimo emprestimoSelecionado;
        public TelefoneEmprestimo EmprestimoSelecionado
        {
            get => emprestimoSelecionado;
            set => SetValue(ref emprestimoSelecionado, value);
        }

        #endregion

        #region Commandos

        public ICommand SalvarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public ICommand RemoverCommand { get; set; }

        #endregion

        #region Funcoes


        #endregion

    }
}
