using System.ComponentModel.DataAnnotations.Schema;

namespace Caloracker1.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? CreditCardNo { get; set; }

        public int? CVV { get; set; }

        public DateOnly ExpiredDate { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public CalorackerUser CalorackerUser { get; set; } = null!;


    }
}
