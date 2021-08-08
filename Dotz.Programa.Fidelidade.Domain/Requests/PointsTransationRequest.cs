using System;

namespace Dotz.Programa.Fidelidade.Domain.Requests
{
    public class PointsTransationRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public float Value { get; set; }
        public string Description { get; set; }
    }
}
