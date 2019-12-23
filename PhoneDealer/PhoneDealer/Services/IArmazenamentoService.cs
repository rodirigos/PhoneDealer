using PhoneDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDealer.Services
{
    public interface IArmazenamentoService
    {
        void SalvarListaEmprestimo(List<TelefoneEmprestimo> listaTelefoneEmprestimo);
        List<TelefoneEmprestimo> ResgatarListaEmprestimo();   
    }
}
