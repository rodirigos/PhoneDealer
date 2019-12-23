using Newtonsoft.Json;
using PhoneDealer.Models;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace PhoneDealer.Services
{
    public class ArmazenamentoService : IArmazenamentoService
    {
     
        public void SalvarListaEmprestimo(List<TelefoneEmprestimo> listaTelefoneEmprestimo)
        {
            var json = JsonConvert.SerializeObject(listaTelefoneEmprestimo);
            Preferences.Set("ListaTelefoneUsuario", json);
        }

        public List<TelefoneEmprestimo> ResgatarListaEmprestimo()
        {
            if (Preferences.ContainsKey("ListaTelefoneUsuario"))
            {
                return JsonConvert.DeserializeObject<List<TelefoneEmprestimo>>(Preferences.Get("ListaTelefoneUsuario", ""));
            } else
            {
                return new List<TelefoneEmprestimo>();
            }
        }
    }
}
