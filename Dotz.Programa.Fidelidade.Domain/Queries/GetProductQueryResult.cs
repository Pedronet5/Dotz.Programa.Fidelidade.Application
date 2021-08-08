namespace Dotz.Programa.Fidelidade.Domain.Queries
{
    public class GetProductQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Valor { get; set; }
        public int CategoryId { get; set; }
    }
}
