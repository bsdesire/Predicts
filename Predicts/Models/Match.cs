using System.ComponentModel.DataAnnotations;

namespace Predicts.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public Team Team1 { get; set; }
        public int Team1Id { get; set; }
        public Team Team2 { get; set; }
        public int Team2Id { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public List<Map> Maps { get; set; }
        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
    }
}
