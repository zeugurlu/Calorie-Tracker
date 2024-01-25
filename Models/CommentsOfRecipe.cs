using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caloracker1.Models
{
    public class CommentsOfRecipe
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

    }
}
