namespace Predicts.DTOs
{
    public class MapDTO
    {
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public string MapName { get; set; }
        public TeamDTO Team1 { get; set; }
        public TeamDTO Team2 { get; set; }
    }
}
