using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class PromotionsController : Controller
    {
        public static List<PromotionModel> promotions = new List<PromotionModel>()
        {
            new PromotionModel(1, "Lorem Ipsum", "Yacoper INC", "ZSHT", 10, 50, new DateTime(2022, 12, 12)),
            new PromotionModel(2, "The Variant", "Yacoper INC", "Yacoper", 100, 10, new DateTime(2022, 10, 30)),
            new PromotionModel(3, "House Flipper", "Frozen District", "PlayWay", 89.99M, 25, new DateTime(2022, 11, 9))
        };
        static int counter = 3;
        public IActionResult Index()
        {
            return View(promotions);
        }

        [HttpGet]
        public IActionResult PromotionForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PromotionForm([FromForm] PromotionModel newPromotion)
        {
            if (!ModelState.IsValid)
                return View();
            if (newPromotion.Id != null)
                promotions[promotions.FindIndex(e => e.Id == newPromotion.Id)] = newPromotion;
            else
            {
                newPromotion.Id = ++counter;
                promotions.Add(newPromotion);
            }
            return View("Index", promotions);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PromotionModel promotion = promotions.FirstOrDefault(p => p.Id == id);
            if (promotion != null)
                return View("PromotionForm", promotion);
            return View("Index", promotions);
        }

        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            PromotionModel promotion = promotions.FirstOrDefault(p => p.Id == id);
            if (promotion != null)
                promotions.Remove(promotion);

            return View("Index", promotions);
        }
    }
}
