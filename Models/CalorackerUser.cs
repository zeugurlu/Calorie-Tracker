using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Caloracker1.Models
{
    public class CalorackerUser : IdentityUser
    {
        public int SecondId { get; set; }
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? EatingHabit { get; set; }

        public string? Target { get; set; }

        public double? Weight { get; set;}

        public double? TargetWeight { get; set; }

        public double? Height { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Gender { get; set; }

        public Track Tracks { get; set; }

        public virtual ICollection<CommentsOfRecipe> CommentsOfRecipes { get; set; } = new List<CommentsOfRecipe>();



    }
}
