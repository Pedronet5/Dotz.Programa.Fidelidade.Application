using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IExchangeRepository
    {
        bool PostExchange(ExchangeRequest exchangeRequest);
        GetExchangeListingQueryResult GetExchangeListing(int ExchangeId);
        IEnumerable<GetExchangeByUserQueryResult> GetExchangeByUserId(int UserId);
    }
}
