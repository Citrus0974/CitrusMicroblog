using System.Diagnostics;
using CitrusMicroblog.Models;
using CitrusMicroblog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CitrusMicroblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsRepository _repository;
        private readonly IFormMessageRepository _repository2;

        public HomeController(INewsRepository repository, IFormMessageRepository repo2)
        {
            _repository = repository;
            _repository2 = repo2;
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

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            //TryValidateModel(model);
            if (ModelState.IsValid)
            {
                FormMessage msg = model.message;
                _repository2.SaveMessage(msg);
                TempData["message"] = "Сообщение отправлено!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult News()
        {
            return View(_repository.NewsTopics.Reverse());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
