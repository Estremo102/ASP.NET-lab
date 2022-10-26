using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class PromotionModel
    {
        public PromotionModel(int id, string gameName, string studio, string publisher, decimal regularPrice, int discount, DateTime endOfPromotion)
        {
            Id = id;
            GameName = gameName;
            Studio = studio;
            Publisher = publisher;
            RegularPrice = regularPrice;
            Discount = discount;
            StartOfPromotion = DateTime.Now;
            EndOfPromotion = endOfPromotion;
            PriceOnSale = RegularPrice / 100 * Discount;
        }

        public PromotionModel(int id, string gameName, string studio, string publisher, decimal regularPrice, int discount, DateTime endOfPromotion, DateTime startOfPromotion)
            : this(id, gameName, studio, publisher, regularPrice, discount, endOfPromotion)
        {
            StartOfPromotion = startOfPromotion;
        }

        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę gry!")]
        public string GameName { get; set; }
        [Required(ErrorMessage = "Proszę podać twórców gry!")]
        public string Studio { get; set; }
        [Required(ErrorMessage = "Proszę podać wydawcę!")]
        public string Publisher { get; set; }

        public decimal RegularPrice { get; set; }
        [Range(1, 100, ErrorMessage = "Promocja musi wynosić pomiędzy 1% a 100%")]
        public int Discount { get; set; }
        [Required(ErrorMessage = "Proszę określić do kiedy trwa promocja!")]
        [DataType(DataType.Date)]
        public DateTime EndOfPromotion { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartOfPromotion { get; }
        [HiddenInput]
        public decimal PriceOnSale { get; }
    }
}
