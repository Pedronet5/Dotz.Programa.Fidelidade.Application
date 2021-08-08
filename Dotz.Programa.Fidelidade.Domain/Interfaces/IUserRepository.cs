using Dotz.Programa.Fidelidade.Domain.Commands;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IUserRepository
    {
        GetUserAccountQueryResult GetUserAccount(UserAccountCommand userAccountCommand);
        GetUserAccountQueryResult GetValidAccount(UserValidAccountRequest userValidAccountCommand);
        bool CheckExistingEmail(string Email);
        bool PostUserAccount(UserAccountRequest userAccountDTO);
        bool PutUserAccount(UserAccountRequest userAccountDTO);
        bool DeleteUserAccount(string Email);
    }
}
