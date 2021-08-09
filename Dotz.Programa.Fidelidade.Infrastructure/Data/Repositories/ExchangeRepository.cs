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
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExchangeItemRepository _exchangeItemRepository;
        public ExchangeRepository(IUnitOfWork unitOfWork, IExchangeItemRepository exchangeItemRepository)
        {
            _unitOfWork = unitOfWork;
            _exchangeItemRepository = exchangeItemRepository;
        }

        public bool PostExchange(ExchangeRequest exchangeRequest)
        {
            try
            {
                var query = $@"INSERT INTO exchange (userid, companyid, addressid, deliverystatus, exchangedate, updatedate) 
                               VALUES (@UserId, @CompanyId, @AddressId, @DeliveryStatus, sysdate(3), sysdate(3))";

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", exchangeRequest.UserId);
                parameters.Add("@CompanyId", exchangeRequest.CompanyId);
                parameters.Add("@AddressId", exchangeRequest.AddressId);
                parameters.Add("@DeliveryStatus", EDeliveryStatus.ExchangeSeparation);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                query = "SELECT LAST_INSERT_ID()";
                var exchangeid = _unitOfWork.Connection.QueryFirst<int>(query, parameters, commandType: CommandType.Text);

                foreach (var item in exchangeRequest.ProductsIds)
                {
                    _exchangeItemRepository.PostExchangeItem(exchangeid, item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GetExchangeListingQueryResult GetExchangeListing(int ExchangeId)
        {
            try
            {
                var query = @"SELECT e.id AS ExchangeId, e.deliverystatus AS DeliveryStatusId, ds.name AS DeliveryStatus, e.userid AS Userid, 
                                usr.name AS UserName, usr.email AS UserEmail, e.companyid AS CompanyId, c.cnpj AS Cnpj, c.name AS CompanyName, 
                                c.category AS CompanyCategory, a.city AS City, a.address AS Address, a.number AS Number, a.district AS District, 
                                a.state AS State, a.cep AS Cep, a.complement AS Complemnt
                                FROM exchange e
                                INNER JOIN company c ON e.companyid = c.id
                                INNER JOIN useraccount usr ON e.userid = usr.id
                                INNER JOIN address a ON a.id = e.addressid
                                INNER JOIN deliverystatus ds ON e.deliverystatus = ds.id
                                WHERE e.id = @ExchangeId
                                ORDER BY e.exchangedate ASC";

                var parameters = new DynamicParameters();
                parameters.Add("@ExchangeId", ExchangeId);

                var entity = _unitOfWork.Connection.Query<GetExchangeListingQueryResult>(query, parameters, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GetExchangeByUserQueryResult> GetExchangeByUserId(int UserId)
        {
            try
            {
                var query = @"SELECT id AS Id, userid AS UserId, companyid AS CompanyId, addressid As AddressId,
                              deliverystatus AS DeliveryStatus, exchangedate AS ExchangeDate
                              FROM exchange
                              WHERE userid = @Userid
                              ORDER BY id ASC";

                var entity = _unitOfWork.Connection.Query<GetExchangeByUserQueryResult>(query, new { UserId = UserId }, commandType: CommandType.Text);

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}