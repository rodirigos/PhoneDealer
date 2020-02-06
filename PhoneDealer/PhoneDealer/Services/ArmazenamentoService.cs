using LiteDB;
using Newtonsoft.Json;
using PhoneDealer.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhoneDealer.Services
{
    public class ArmazenamentoService : IArmazenamentoService
    {

        LiteDatabase _database;
        LiteCollection<Emprestador> Emprestadores;
        LiteCollection<ItemEmprestimoDao> HistoricoEmprestimos;
        LiteCollection<ItemEmprestimo> ListaItensEmprestimo;
        readonly IDbFolder dbFolder;


        public ArmazenamentoService()
        {
            dbFolder = DependencyService.Get<IDbFolder>();
            _database = new LiteDatabase(dbFolder.CaminhoArquivo());
            Emprestadores = _database.GetCollection<Emprestador>();
            HistoricoEmprestimos = _database.GetCollection<ItemEmprestimoDao>();
            ListaItensEmprestimo = _database.GetCollection<ItemEmprestimo>();

        }

        public List<ItemEmprestimoDao> ResgatarListaEmprestimo()
        {
            return HistoricoEmprestimos.FindAll().ToList();
        }
        public List<ItemEmprestimo> ResgatarListaItens()
        {
            return ListaItensEmprestimo.FindAll().ToList();
        }
        public List<Emprestador> ResgatarListaEmprestador()
        {
            return Emprestadores.FindAll().ToList();
        }

        public void AdicionarEmprestimo(ItemEmprestimoDao itemEmprestimoDao)
        {
            HistoricoEmprestimos.Insert(itemEmprestimoDao);
        }

        public void RemoverEmprestimo(ItemEmprestimoDao itemEmprestimoDao)
        {
            HistoricoEmprestimos.Delete(x=> x.DbId == itemEmprestimoDao.DbId);
        }

        public void AtualizarEmprestimo(ItemEmprestimoDao itemEmprestimoDao)
        {
            try
            {
                var itemEmprestadoEncontrado = HistoricoEmprestimos.Find(x => x.DbId == itemEmprestimoDao.DbId).FirstOrDefault();
                itemEmprestadoEncontrado = itemEmprestimoDao;
                HistoricoEmprestimos.Update(itemEmprestadoEncontrado);
            }
            catch (System.Exception)
            {

            }
            


        }
        public void AdicionarItem(ItemEmprestimo item)
        {
            ListaItensEmprestimo.Insert(item);
        }

        public void RemoverItem(ItemEmprestimo item)
        {
            ListaItensEmprestimo.Delete(x => x.DbId == item.DbId);
        }

        public void AtualizarItem(ItemEmprestimo item)
        {
            ListaItensEmprestimo.Update(item);
        }

        public void AdicionarEmprestador(Emprestador emprestador)
        {
            Emprestadores.Insert(emprestador);
        }

        public void RemoverEmprestador(Emprestador emprestador)
        {
            Emprestadores.Delete(x=> x.DbId ==emprestador.DbId);
        }
    }
}
