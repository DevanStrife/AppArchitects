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
        public float X1 { get; set; }
        [Required]
        public float Y1 { get; set; }
        [Required]
        public float X2 { get; set; }
        [Required]
        public float Y2 { get; set; }
        [Required]
        public float X3 { get; set; }
        [Required]
        public float Y3 { get; set; }
        [Required]
        public float X4 { get; set; }
        [Required]
        public float Y4 { get; set; }

        public  Photo? Photos { get; set; }
        public int PhotoId { get; set; }
    }
}
