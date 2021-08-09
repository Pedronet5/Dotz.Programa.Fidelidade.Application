using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Requests
{
    public class ExchangeRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}
