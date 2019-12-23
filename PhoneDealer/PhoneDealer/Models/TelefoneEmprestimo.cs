using PhoneDealer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDealer.Models
{
    public class TelefoneEmprestimo : BaseViewModel
    {
        public Guid Id { get; set; }

        private string codigo;
        public string Codigo { get => codigo; set => SetValue(ref codigo, value); }

        private string modelo;
        public string Modelo { get => modelo; set => SetValue(ref modelo, value); }
        public int IdTelefone { get; set; }

        private string nomeEmprestador;
        public string NomeEmprestador { get => nomeEmprestador; set => SetValue(ref nomeEmprestador, value); }
        public int EmprestadorId { get; set; }

        private DateTime dataEmprestada;
        public DateTime DataEmprestada { get => dataEmprestada; set => SetValue(ref dataEmprestada, value); }
        private DateTime dataDevolvida;
        public DateTime DataDevolvida { get => dataDevolvida; set => SetValue(ref dataDevolvida, value); }
        private bool devolvido;
        public bool Devolvido
        {
            get => devolvido; set
            {
                SetValue(ref devolvido, value);
                OnPropertyChanged("DevolvidoString");
            }

        }

        public string DevolvidoString
        {
            get
            {
                return Devolvido ? $"Devolvido em {DataDevolvida.ToString("dd/MM/yyyy")}" : "Não Devolvido";
            }
        }
    }
}
