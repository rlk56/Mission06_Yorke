using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return RedirectToAction("Form");
        }
    }
}
