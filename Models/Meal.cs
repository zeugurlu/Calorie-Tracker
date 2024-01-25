using System.ComponentModel.DataAnnotations;

namespace Caloracker1.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public double? TotalCalorie { get; set; }

        public double? Amount { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public double? Carbonhydrate { get; set; }

        public double? Protein { get; set; }

        public double? Fat { get; set; }


    }
}
