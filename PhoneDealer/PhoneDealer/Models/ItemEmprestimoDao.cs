using Newtonsoft.Json;
using PhoneDealer.ViewModel;
using System;

namespace PhoneDealer.Models
{
    public class ItemEmprestimoDao : BaseViewModel
    {
        public Guid Id { get; set; }

        private string codigo;
        public string Codigo { get => codigo; set => SetValue(ref codigo, value); }

        private string modelo;
        public string Modelo { get => modelo; set => SetValue(ref modelo, value); }
        public string IdTelefone { get; set; }

        private string nomeEmprestador;
        public string NomeEmprestador { get => nomeEmprestador; set => SetValue(ref nomeEmprestador, value); }
        public int EmprestadorId { get; set; }

        private DateTime dataEmprestada;
        public DateTime DataEmprestada { get => dataEmprestada; set => SetValue(ref dataEmprestada, value); }
        private DateTime dataDevolvida;
        public DateTime DataDevolvida { get => dataDevolvida; set => SetValue(ref dataDevolvida, value); }
        public DateTime DataAtualizada { get; set; }

        private bool devolvido;
        public bool Devolvido
        {
            get => devolvido; set
            {
                SetValue(ref devolvido, value);
                OnPropertyChanged("DevolvidoString");
            }

        }

        [JsonIgnore]
        public string DevolvidoStringDetalhe
        {
            get
            {
                return Devolvido ? $"Devolvido por {NomeEmprestador}" : $"Emprestado para {NomeEmprestador} ";
            }
        }

        [JsonIgnore]
        public string DevolvidoString
        {
            get
            {
                return Devolvido ? $"Devolvido por {NomeEmprestador} as {DataDevolvida.ToString("dd/MM/yyyy")}" : $"Emprestado para {NomeEmprestador} as {DataEmprestada.ToString("dd/MM/yyyy")}";
            }
        }

        [JsonIgnore]
        public string EstadoCor
        {
            get
            {
                if (Devolvido)
                    return "#10ee1f";
                else
                    return "#f22929";
            }
        }
    }
}
