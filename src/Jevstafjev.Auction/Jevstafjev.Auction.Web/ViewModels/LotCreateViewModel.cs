using System.ComponentModel.DataAnnotations;

namespace Jevstafjev.Auction.Web.ViewModels
{
    public class LotCreateViewModel
    {
        [Required]
        [Length(2, 256)]
        public string Name { get; set; } = null!;

        [Required]
        [Length(2, 1000)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity)]
        [Display(Name = "Starting bid")]
        public decimal StartingBid { get; set; }

        [Required]
        [Display(Name = "Expiration date(UTC)")]
        public DateTime ExpirationDate { get; set; }
    }
}
