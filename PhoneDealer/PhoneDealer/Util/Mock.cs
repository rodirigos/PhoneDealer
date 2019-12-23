using PhoneDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDealer.Util
{
    public static class Mock
    {
        public static List<TelefoneEmprestimo> TelefonesMock = new List<TelefoneEmprestimo>()
        {
            new TelefoneEmprestimo()
            {
                Codigo = "0001",
                Modelo = "Samsumg J6",
                NomeEmprestador = "Fulano"
            },
             new TelefoneEmprestimo()
            {
                Codigo = "0002",
                Modelo = "Samsumg J7",
                NomeEmprestador = "Beltrano"
            },
            new TelefoneEmprestimo()
            {
                Codigo = "0003",
                Modelo = "Samsumg J8",
                NomeEmprestador = "Ciclano"
            }
        };

        public static List<Telefone> TelefonesModeloMock = new List<Telefone>()
        {
            new Telefone()
            {
                Modelo = "Samsumg J6",
                Id = 1
            },
            new Telefone()
            {
                Modelo = "Samsumg J7",
                Id = 2
            },
            new Telefone()
            {
                Modelo = "Samsumg J8",
                Id = 3
            }
        };
    }
}
