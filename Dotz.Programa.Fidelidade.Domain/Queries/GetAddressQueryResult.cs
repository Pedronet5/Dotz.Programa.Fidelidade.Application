using System;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetAddressQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
