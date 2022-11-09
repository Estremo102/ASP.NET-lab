using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Game
    {
        public int? Id { get; set; }
        public string GameName { get; set; }
        public string Studio { get; set; }
        public string Publisher { get; set; }

        public decimal RegularPrice { get; set; }
    }
}
