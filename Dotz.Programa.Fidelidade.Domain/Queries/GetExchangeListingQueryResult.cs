using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetExchangeListingQueryResult
    {
        public int ExchangeId { get; set; }
        public int DeliveryStatusId { get; set; }
        public string DeliveryStatus { get; set; }
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int CompanyId { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCategory { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Complemnt { get; set; }
        public IEnumerable<GetExchangeItensQueryResult> Itens { get; set; }
    }
}
