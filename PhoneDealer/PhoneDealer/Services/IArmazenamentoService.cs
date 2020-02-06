using PhoneDealer.Models;
using System.Collections.Generic;

namespace PhoneDealer.Services
{
    public interface IArmazenamentoService
    {    
        void AdicionarEmprestimo(ItemEmprestimoDao itemEmprestimoDao);
        void RemoverEmprestimo(ItemEmprestimoDao itemEmprestimoDao);
        void AtualizarEmprestimo(ItemEmprestimoDao itemEmprestimoDao);
        List<ItemEmprestimoDao> ResgatarListaEmprestimo();

        void AdicionarItem(ItemEmprestimo item);
        void RemoverItem(ItemEmprestimo item);
        void AtualizarItem(ItemEmprestimo item);
        List<ItemEmprestimo> ResgatarListaItens();


        void AdicionarEmprestador(Emprestador emprestador);
        void RemoverEmprestador(Emprestador emprestador);
        List<Emprestador> ResgatarListaEmprestador();
    }
}
