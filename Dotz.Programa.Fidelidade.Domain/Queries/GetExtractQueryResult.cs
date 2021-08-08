using System;

namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetExtractQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string OperationType { get; set; }
        public float Value { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }
    }
}
