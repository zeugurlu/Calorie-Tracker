using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caloracker1.Models
{
    public class Track
    {

        [Key]
        public int Id { get; set; }

        public int? DailyCalorie { get; set; }

        public int? TotalBudget { get; set; }

        public int? Breakfast { get; set; }

        public int? Lunch { get; set; }

        public int? Dinner { get; set; }

        public int? CupWater { get; set; }

        public decimal? TotalKarbs { get; set; }

        public decimal? TotalProteins { get; set; }

        public decimal? TotalFats { get; set; }

        public string? UserId { get; set; }

        public CalorackerUser? CalorackerUser { get; set; } = null!;
    }
}
