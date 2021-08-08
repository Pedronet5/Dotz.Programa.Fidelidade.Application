namespace Dotz.Programa.Fidelidade.Domain.Requests
{
    public class AddressPutRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
    }
}
