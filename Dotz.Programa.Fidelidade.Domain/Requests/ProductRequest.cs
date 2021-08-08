namespace Dotz.Programa.Fidelidade.Domain.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Valor { get; set; }
        public int CategoryId { get; set; }
    }
}
