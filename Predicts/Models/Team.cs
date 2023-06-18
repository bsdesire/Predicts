using System.ComponentModel.DataAnnotations;

namespace Predicts.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Player>? Players { get; set; }
        public string? Country { get; set; }
    }
}
