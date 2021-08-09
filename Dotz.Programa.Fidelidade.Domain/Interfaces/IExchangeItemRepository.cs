using Dotz.Programa.Fidelidade.Domain.Queries;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IExchangeItemRepository
    {
        bool PostExchangeItem(int ExchangeId, int ProductId);
        IEnumerable<GetExchangeItensQueryResult> GetExchangeItens(int ExchangeId);
    }
}
