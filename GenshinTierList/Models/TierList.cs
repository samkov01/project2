using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApp.Models
{
    public class TierList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public Atribute Atribute { get; set; }

        [Required]
        public string Tier { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Wiki link")]
        public string WikiUrl { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Character")]
        public string ImageUrl { get; set; }
    }
}
