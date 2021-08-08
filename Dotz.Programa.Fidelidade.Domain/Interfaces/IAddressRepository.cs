using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IAddressRepository
    {
        bool PostAddress(AddressRequest addressRequest);
        IEnumerable<GetAddressQueryResult> GetAddress(int userId);
        bool PutAddress(AddressPutRequest addressPutRequest);
        bool DeleteAddress(int AddressId);
    }
}
