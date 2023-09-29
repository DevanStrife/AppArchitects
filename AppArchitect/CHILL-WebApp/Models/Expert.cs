using System.ComponentModel.DataAnnotations;

namespace CHILL_WebApp.Models
{
    public class Expert
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }

        public Photo? Photos { get; set; }
        public int? PhotoId { get; set; }

    }
}
