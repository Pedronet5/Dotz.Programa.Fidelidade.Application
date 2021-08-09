using System;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetExchangeByUserQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        public int DeliveryStatus { get; set; }
        public DateTime ExchangeDate { get; set; }
    }
}