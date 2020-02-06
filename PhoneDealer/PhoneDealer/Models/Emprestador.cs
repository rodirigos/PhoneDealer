namespace PhoneDealer.Models
{
    public class Emprestador : BaseEntity
    {
        public Emprestador(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Emprestador()
        {

        }
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool emDebito { get; set; }
    }
}
