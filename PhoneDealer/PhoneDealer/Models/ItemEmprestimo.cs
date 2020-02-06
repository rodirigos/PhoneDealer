namespace PhoneDealer.Models
{
    public class ItemEmprestimo : BaseEntity
    {
        public ItemEmprestimo(string id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public ItemEmprestimo()
        {

        }
        public string Id { get; set; }
        public string Descricao { get; set; }

        public bool Devolucao { get; set; }

    }
}
