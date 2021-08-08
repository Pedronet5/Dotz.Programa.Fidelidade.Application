namespace Dotz.Programa.Fidelidade.Domain.Requests
{
    public class UserAccountRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
