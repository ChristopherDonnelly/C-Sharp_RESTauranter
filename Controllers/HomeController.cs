using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{

    public class HomeController : Controller
    {
        private RESTauranterContext _context;

        public HomeController(RESTauranterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        [Route("Home")]
        public IActionResult Index()
        {

            return View(new Review());
        }

        [HttpPost]
        [Route("AddReview")]
        public IActionResult AddReview(Review review)
        {
            if(ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();

                return RedirectToAction("Reviews");
            }
            
            return View("Index");
        }

        [HttpGet]
        [Route("AddHelpful/{id}")]
        public IActionResult AddHelpful(int id)
        {
            Review review = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);
            review.Helpful += 1;
            _context.SaveChanges();
            
            return RedirectToAction("Reviews");
        }

        [HttpGet]
        [Route("AddUnhelpful/{id}")]
        public IActionResult AddUnhelpful(int id)
        {
            Review review = _context.Reviews.SingleOrDefault(r => r.ReviewId == id);
            review.Unhelpful += 1;
            _context.SaveChanges();
            
            return RedirectToAction("Reviews");
        }
        
        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Reviews.OrderByDescending(review => review.CreatedAt).ToList();

            return View(AllReviews);
        }

    }
}
