using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetExchangeItensQueryResult
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Valor { get; set; }
        public string CategoryId { get; set; }
    }
}
