using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Predicts.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Team? CurrentTeam { get; set; }
        [JsonIgnore]
        public int? CurrentTeamId { get; set; }
    }
}
