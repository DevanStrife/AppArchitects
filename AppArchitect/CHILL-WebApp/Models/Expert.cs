using System.ComponentModel.DataAnnotations;

namespace CHILL_WebApp.Models
{
    public class Expert
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public virtual ICollection<Photo>? Photos { get; set; }
    }
}
