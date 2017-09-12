using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    using System.Web.Script.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index(string searchTerm)
        {
            var model =
                _db.Resturants.OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .Select(
                        r =>
                            new ResturantReviewModel
                                {
                                    Id = r.Id,
                                    Name = r.Name,
                                    City = r.City,
                                    Country = r.Country,
                                    CountOfReviews = r.Reviews.Count()
                                });

            var setting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            return View("Index",string.Empty,JsonConvert.SerializeObject(model,Formatting.None,setting));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null){
                _db.Dispose();
            }
        }
    }
}