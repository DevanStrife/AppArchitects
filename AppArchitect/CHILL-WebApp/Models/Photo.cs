﻿using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace CHILL_WebApp.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string? Path { get; set; }
        public bool IsLabeled { get; set; }
        public virtual ICollection<Label>? Labels { get; set; }
        public virtual ICollection<Expert>? Experts { get; set; }
    }
}