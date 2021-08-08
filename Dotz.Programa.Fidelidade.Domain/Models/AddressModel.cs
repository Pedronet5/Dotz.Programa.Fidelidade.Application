using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Models
{
    public class AddressModel
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
    }
}
