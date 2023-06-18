using Predicts.Models;

namespace Predicts.DTOs
{
    public class MatchDTO
    {
        public TeamDTO Team1 { get; set; }
        public TeamDTO Team2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public List<MapDTO> Maps { get; set; }
        public TournamentDTO Tournament { get; set; }
    }
}