using System.ComponentModel.DataAnnotations;

namespace Caloracker1.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? imageUrl { get; set; }

        public int? Calorie { get; set; }

        public decimal? Amount { get; set; }

        public int? Portion { get; set; }

        public int? Minute { get; set; }

        public int? Person { get; set; }

        public string? Type { get; set; }

        public decimal? Karbs { get; set; }

        public decimal? Fats { get; set; }

        public decimal? Proteins { get; set; }

        public string? Ingredients { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<CommentsOfRecipe> CommentsOfRecipes { get; set; } = new List<CommentsOfRecipe>();
    }
}