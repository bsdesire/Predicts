using System.ComponentModel.DataAnnotations;

namespace Predicts.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
