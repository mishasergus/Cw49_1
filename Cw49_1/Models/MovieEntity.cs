using System.ComponentModel.DataAnnotations;

namespace Cw49_1.Models
{
    public class MovieEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
