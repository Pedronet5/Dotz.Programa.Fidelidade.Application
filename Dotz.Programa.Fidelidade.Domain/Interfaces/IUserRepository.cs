using Dotz.Programa.Fidelidade.Domain.Commands;
using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IUserRepository
    {
        GetUserAccountQueryResult GetUserAccount(UserAccountCommand userAccountCommand);
        GetUserAccountQueryResult GetValidAccount(UserValidAccountModel userValidAccountCommand);
        bool CheckExistingEmail(string Email);
        bool PostUserAccount(UserAccountModel userAccountDTO);
        bool PutUserAccount(UserAccountModel userAccountDTO);
        bool DeleteUserAccount(string Email);
    }
}
