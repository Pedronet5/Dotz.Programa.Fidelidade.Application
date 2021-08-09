using Dapper;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Data;


namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class ExchangeItemRepository : IExchangeItemRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExchangeItemRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool PostExchangeItem(int ExchangeId, int ProductId)
        {
            try
            {

                var query = $@"INSERT INTO exchangeitens (exchangeid, productid) 
                               VALUES (@ExchangeId, @ProductId)";

                var parameters = new DynamicParameters();
                parameters.Add("@ExchangeId", ExchangeId);
                parameters.Add("@ProductId", ProductId);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<GetExchangeItensQueryResult> GetExchangeItens(int ExchangeId)
        {
            try
            {
                var query = $@"SELECT ei.productid AS ProductId, p.name AS Name, p.valor AS Valor, p.categoryid AS CategoryId
                               FROM exchangeitens ei
                               INNER JOIN product p ON ei.productid = p.id
                               WHERE ei.exchangeid = @ExchangeId";

                var entity = _unitOfWork.Connection.Query<GetExchangeItensQueryResult>(query, new { ExchangeId = ExchangeId }, commandType: CommandType.Text);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}