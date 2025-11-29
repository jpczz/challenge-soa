namespace HealthHabits.Api.Models
{
    public class Habito
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string Tipo { get; set; } = string.Empty;      // "agua", "sono", "exercicio"...
        public string Unidade { get; set; } = string.Empty;   // "litros", "minutos", "horas"...
        public int MetaDiaria { get; set; }                   // 2000 ml, 8 horas, etc.

        // Relacionamentos
        public Usuario? Usuario { get; set; }
        public List<RegistroHabito> Registros { get; set; } = new();
    }
}
