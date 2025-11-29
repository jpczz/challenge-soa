namespace HealthHabits.Api.Models
{
    public class RegistroHabito
    {
        public int Id { get; set; }
        public int HabitoId { get; set; }

        public DateTime Data { get; set; }
        public int Valor { get; set; }     // Ex: 500 ml, 30 min, 7 horas...

        // Relacionamento
        public Habito? Habito { get; set; }
    }
}
