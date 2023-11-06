using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace CHILL_WebApp.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        public bool IsLabeled { get; set; }
        public ICollection<Coordinate>? Coordinates { get; set; }
        public ICollection<Expert>? Experts { get; set; }
        public Label? Labels { get; set; }
        public int? LabelId { get; set; }
    }
}