using System.ComponentModel.DataAnnotations;

namespace Predicts.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public string MapName { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
    }
}
