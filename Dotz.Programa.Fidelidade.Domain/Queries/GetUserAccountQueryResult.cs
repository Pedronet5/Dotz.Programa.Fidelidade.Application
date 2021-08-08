using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetUserAccountQueryResult
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
