using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHILL_WebApp.Models
{
    public class Coordinate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string X1 { get; set; }
        [Required]
        public string Y1 { get; set; }
        [Required]
        public string X2 { get; set; }
        [Required]
        public string Y2 { get; set; }
        [Required]
        public string X3 { get; set; }
        [Required]
        public string Y3 { get; set; }
        [Required]
        public string X4 { get; set; }
        [Required]
        public string Y4 { get; set; }

        public  Photo? Photos { get; set; }
        public int PhotoId { get; set; }
    }
}
