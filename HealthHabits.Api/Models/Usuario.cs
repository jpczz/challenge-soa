namespace HealthHabits.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relacionamento 1:N
        public List<Habito> Habitos { get; set; } = new();
    }
}
