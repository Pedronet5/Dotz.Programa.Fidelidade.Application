using Dapper;
using Dotz.Programa.Fidelidade.Domain.Commands;
using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetAddressQueryResult GetAddress(int userId)
        {
            try
            {
                var query = $@"SELECT a.id AS Id, a.address AS Address, a.number AS Number, a.city AS City,
                                      a.district As District, a.state AS State, a.cep AS Cep,
                                      a.complement AS Complement, a.updatedate AS UpdateDate
                               From address a 
                               WHERE a.userid = @UserId";

                var entity = _unitOfWork.Connection.Query<GetAddressQueryResult>(query, new { UserId = userId }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostAddressAccount(AddressModel addressModel)
        {
            try
            {
                var query = $@"INSERT INTO address (userid, address, number, city, district, state, cep, complement, updatedate) 
                               VALUES (@UserId, @Address, @Number, @City, @District, @State, @Cep, @Complement, sysdate(3))";

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", addressModel.UserId);
                parameters.Add("@Address", addressModel.Address);
                parameters.Add("@Number", addressModel.Number);
                parameters.Add("@City", addressModel.City);
                parameters.Add("@District", addressModel.District);
                parameters.Add("@State", addressModel.State);
                parameters.Add("@Cep", addressModel.Cep);
                parameters.Add("@Complement", addressModel.Complement);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
