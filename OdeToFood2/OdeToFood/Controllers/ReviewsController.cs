//using OdeToFood.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;S
//using System.Web.Mvc;

//namespace OdeToFood.Controllers
//{
//    public class ReviewsController : Controller
//    {

//        public ActionResult BestReview()
//        {
//            var bestReview= from r in _reviews
//                           orderby r.Rating descending
//                            select r;
//            return PartialView(bestReview.First());
//        }
//        // GET: Reviews
//        public ActionResult Index()
//        {
//            var model =
//                from r in _reviews
//                orderby r.Country
//                select r;

//            return View(model);
//        }

//        // GET: Reviews/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Re_reviews/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Reviews/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Reviews/Edit/5
//        public ActionResult Edit(int id)
//        {

//            var review = _reviews.Single(r => r.Id==id);

//            return View(review);
//        }

//        // POST: Reviews/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            var review = _reviews.Single(r => r.Id == id);
            
            
             

//                if (TryUpdateModel(review))
//                {
//                    return RedirectToAction("Index");
//                }
                
//            return View(review);
//        }

//        // GET: Reviews/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Reviews/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }


//        static List<ResturantReview> _reviews = new List<ResturantReview>
//    {
//        new ResturantReview
//        {
//            Id=1,
//            Name="Cinamon Club",
//            City="London",
//            Country="UK",
//            Rating=10
//        },


//        new ResturantReview
//        {
//            Id=2,
//            Name="Honacha Club",
//            City="Lalitpur",
//            Country="Nepal",
//            Rating=7
//        },

//        new ResturantReview
//        {
//            Id=1,
//            Name="Lahana",
//            City="Kathmandu",
//            Country="Nepal",
//            Rating=6
//        }
//    };
//    }


//}
