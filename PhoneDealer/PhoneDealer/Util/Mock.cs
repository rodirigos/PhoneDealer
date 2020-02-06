using PhoneDealer.Models;
using System;
using System.Collections.Generic;

namespace PhoneDealer.Util
{
    public static class Mock
    {
        public static List<ItemEmprestimoDao> TelefonesMock = new List<ItemEmprestimoDao>()
        {
            new ItemEmprestimoDao()
            {
                Codigo = "0001",
                Modelo = "Samsumg J6",
                NomeEmprestador = "Fulano"
            },
             new ItemEmprestimoDao()
            {
                Codigo = "0002",
                Modelo = "Samsumg J7",
                NomeEmprestador = "Beltrano"
            },
            new ItemEmprestimoDao()
            {
                Codigo = "0003",
                Modelo = "Samsumg J8",
                NomeEmprestador = "Ciclano"
            }
        };

        public static List<ItemEmprestimo> TelefonesModeloMock = new List<ItemEmprestimo>()
        {
            new ItemEmprestimo("5d3b97c0-d4da-46ba-addb-49473bfdb318","Samsumg J6")
        };
    }
}
