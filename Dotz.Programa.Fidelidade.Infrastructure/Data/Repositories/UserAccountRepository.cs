using Dapper;
using Dotz.Programa.Fidelidade.Domain.Commands;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class UserAccountRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserAccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetUserAccountQueryResult GetUserAccount(UserAccountCommand userAccountCommand)
        {
            try
            {
                var query = $@"SELECT user.id AS UserId,
                                  user.name AS Name,
                                  user.email AS Email,
                                  user.password As Password,
                                  user.role AS Role,
                                  user.updatedate As UpdateDate
                           FROM useraccount user
                           WHERE user.email = @Email";

                var entity = _unitOfWork.Connection.Query<GetUserAccountQueryResult>(query, new { Email = userAccountCommand.Email }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GetUserAccountQueryResult GetValidAccount(UserValidAccountRequest userValidAccountCommand)
        {
            try
            {
                var query = $@"SELECT user.id AS UserId,
                                  user.name AS Name,
                                  user.email AS Email,
                                  user.password As Password,
                                  user.role AS Role,
                                  user.updatedate As UpdateDate
                           FROM useraccount user
                           WHERE user.email = @Email
                           AND user.password = @Password ";

                var entity = _unitOfWork.Connection.Query<GetUserAccountQueryResult>(query,
                    new { Email = userValidAccountCommand.Email, Password = userValidAccountCommand.Password }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckExistingEmail(string Email)
        {
            try
            {
                var query = $@"SELECT user.id AS UserId,
                                  user.name AS Name,
                                  user.email AS Email,
                                  user.password As Password,
                                  user.role AS Role,
                                  user.updatedate As UpdateDate
                           FROM useraccount user
                           WHERE user.email = @Email ";

                var entity = _unitOfWork.Connection.Query<GetUserAccountQueryResult>(query,
                    new { Email = Email }, commandType: CommandType.Text);

                return entity.Count() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostUserAccount(UserAccountRequest userAccountDTO)
        {
            try
            {
                var query = $@"INSERT INTO useraccount (name, email, password, role, updatedate) 
                               VALUES (@Name, @Email, @Password, @Role, sysdate(3))";

                _unitOfWork.Connection.Query(query,
                    new { Name = userAccountDTO.Name, Email = userAccountDTO.Email, Password = userAccountDTO.Password, Role = userAccountDTO.Role }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PutUserAccount(UserAccountRequest userAccountDTO)
        {
            try
            {
                var query = $@"UPDATE useraccount SET name = @Name, email = @Email, password = @Password, role = @role
                               WHERE email = @Email ";

                _unitOfWork.Connection.Query(query,
                    new { Name = userAccountDTO.Name, Email = userAccountDTO.Email, Password = userAccountDTO.Password, userAccountDTO.Role }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUserAccount(string Email)
        {
            try
            {
                var query = $@"DELETE FROM useraccount WHERE email = @Email ";

                _unitOfWork.Connection.Query(query,
                    new { Email = Email }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
