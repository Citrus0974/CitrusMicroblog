using System.Diagnostics;
using CitrusMicroblog.Models;
using CitrusMicroblog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CitrusMicroblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsRepository _repository;

        public HomeController(INewsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomeIndexViewModel
            {
                message = new FormMessage { },
                topics = _repository.NewsTopics.TakeLast(3)
            });
        }

        public IActionResult News()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
