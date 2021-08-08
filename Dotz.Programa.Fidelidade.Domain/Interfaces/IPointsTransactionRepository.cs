using Dotz.Programa.Fidelidade.Domain.Enums;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IPointsTransactionRepository
    {
        bool PostPointsTransation(PointsTransationRequest pointsTransationRequest, EOperationType operationType);
        IEnumerable<GetExtractQueryResult> GetExtractByUserId(int UserId);
        float GetBalanceAccountByUserId(int UserId);

    }
}
