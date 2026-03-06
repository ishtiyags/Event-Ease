using System.ComponentModel.DataAnnotations;

namespace SnackTrackMvc.Models
{
    public class Snack
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Range(1, 100)]
        public double Price { get; set; }

        public string Description { get; set; }
    }
}