using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Caloracker1.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? ContentOfComment { get; set; }

        [Required]
        public int? RecipeId { get; set; }
        [ForeignKey("RecipeId")]

        public virtual Recipe? Recipe { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public CalorackerUser CalorackerUser { get; set; } = null!;


        public int? MealId { get; set; }
        [ForeignKey("MealId")]

        public virtual Meal? Meal { get; set; }

    }
}
