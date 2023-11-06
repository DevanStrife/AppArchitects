using System.ComponentModel.DataAnnotations;

namespace CHILL_WebApp.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Colour { get; set; }
        public Expert? Experts { get; set; }
    }
}
