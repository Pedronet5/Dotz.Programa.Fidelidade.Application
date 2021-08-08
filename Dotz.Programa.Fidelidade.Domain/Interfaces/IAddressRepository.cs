using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Queries;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IAddressRepository
    {
        bool PostAddressAccount(AddressModel addressModel);
        GetAddressQueryResult GetAddress(int userId);
    }
}
