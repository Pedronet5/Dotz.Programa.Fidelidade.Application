using Dapper;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetAddressQueryResult> GetAddress(int userId)
        {
            try
            {
                var query = $@"SELECT a.id AS Id, a.userid AS UserId, a.address AS Address, a.number AS Number, a.city AS City,
                                      a.district As District, a.state AS State, a.cep AS Cep,
                                      a.complement AS Complement, a.updatedate AS UpdateDate
                               From address a 
                               WHERE a.userid = @UserId";

                var entity = _unitOfWork.Connection.Query<GetAddressQueryResult>(query, new { UserId = userId }, commandType: CommandType.Text);

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostAddress(AddressRequest addressRequest)
        {
            try
            {
                var query = $@"INSERT INTO address (userid, address, number, city, district, state, cep, complement, updatedate) 
                               VALUES (@UserId, @Address, @Number, @City, @District, @State, @Cep, @Complement, sysdate(3))";

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", addressRequest.UserId);
                parameters.Add("@Address", addressRequest.Address);
                parameters.Add("@Number", addressRequest.Number);
                parameters.Add("@City", addressRequest.City);
                parameters.Add("@District", addressRequest.District);
                parameters.Add("@State", addressRequest.State);
                parameters.Add("@Cep", addressRequest.Cep);
                parameters.Add("@Complement", addressRequest.Complement);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PutAddress(AddressPutRequest addressPutRequest)
        {
            try
            {
                var query = $@"UPDATE address SET address = @Address, number = @Number, district = @District, state = @State,
                                      city = @City, cep = @Cep, complement = @Complement, updatedate = sysdate(3)                             
                               WHERE id = @Id AND userid = @UserId ";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", addressPutRequest.Id);
                parameters.Add("@UserId", addressPutRequest.UserId);
                parameters.Add("@Address", addressPutRequest.Address);
                parameters.Add("@Number", addressPutRequest.Number);
                parameters.Add("@City", addressPutRequest.City);
                parameters.Add("@District", addressPutRequest.District);
                parameters.Add("@State", addressPutRequest.State);
                parameters.Add("@Cep", addressPutRequest.Cep);
                parameters.Add("@Complement", addressPutRequest.Complement);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAddress(int AddressId)
        {
            try
            {
                var query = $@"DELETE FROM address WHERE id = @Id ";

                _unitOfWork.Connection.Query(query,
                    new { Id = AddressId }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
