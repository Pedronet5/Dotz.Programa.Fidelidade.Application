using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IExchangeRepository
    {
        bool PostExchange(ExchangeRequest exchangeRequest);
        GetExchangeListingQueryResult GetExchangeListing(int ExchangeId);
    }
}
