namespace Predicts.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TeamDTO? CurrentTeam { get; set; }
    }
}
