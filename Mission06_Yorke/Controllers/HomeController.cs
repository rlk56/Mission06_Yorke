using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Yorke.Models;
using System.Diagnostics;


namespace Mission06_Yorke.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext Instance) 
        { 
            _context = Instance;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();
           
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return RedirectToAction("Form");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();

                return View(response);
            }
        }

        public IActionResult Database()
        {
             var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(x => x.MovieID).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                 .OrderBy(x => x.CategoryID)
                 .ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            
            return RedirectToAction("Database");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedRecord)
        {
            _context.Movies.Remove(deletedRecord);
            _context.SaveChanges();

            return RedirectToAction("Database");
        }
    }
}
