using System.ComponentModel.DataAnnotations;

namespace Predicts.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Team? CurrentTeam { get; set; }
        public int? CurrentTeamId { get; set; }
    }
}
