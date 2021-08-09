using Dapper;
using Dotz.Programa.Fidelidade.Domain.Enums;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class PointsTransactionRepository : IPointsTransactionRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public PointsTransactionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetExtractQueryResult> GetExtractByUserId(int UserId)
        {
            try
            {
                var query = @"SELECT id, userid, companyid, operationtype, value, updatedate, description
                              FROM pointstransation 
                              WHERE userid = @UserId";

                var entity = _unitOfWork.Connection.Query<GetExtractQueryResult>(query, new { UserId = UserId }, commandType: CommandType.Text);

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public float GetBalanceAccountByUserId(int UserId)
        {
            try
            {
                var query = @"SELECT SUM(COALESCE(valuetransaction, 0)) AS 'balance' FROM (
                                SELECT SUM(value) AS 'valuetransaction' FROM dotz.pointstransation
                                WHERE operationtype = 'C'
                                AND userid = @UserId
                                UNION ALL
                                SELECT SUM(value)*-1 AS 'valuetransaction' FROM dotz.pointstransation
                                WHERE operationtype = 'D'
                                AND userid = @UserId) t1";

                var entity = _unitOfWork.Connection.Query<float>(query, new { UserId = UserId }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostPointsTransation(PointsTransationRequest pointsTransationRequest, EOperationType operationType)
        {
            try
            {
                var query = $@"INSERT INTO dotz.pointstransation (userid, companyid, operationtype, value, updatedate, description) 
                               VALUES (@UserId, @CompanyId, @OperationType, @Value, sysdate(3), @Description)";

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", pointsTransationRequest.UserId);
                parameters.Add("@CompanyId", pointsTransationRequest.CompanyId);
                parameters.Add("@OperationType", Convert.ToInt32(operationType) == 1 ? "C" : "D");
                parameters.Add("@Value", pointsTransationRequest.Value);
                parameters.Add("@Description", pointsTransationRequest.Description);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
