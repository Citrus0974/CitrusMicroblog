using CitrusMicroblog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitrusMicroblog.Controllers
{
    public class AdminController : Controller
    {
        private IFormMessageRepository _repository;
        private readonly INewsRepository _repository1;

        public AdminController(IFormMessageRepository repository, INewsRepository rep1)
        {
            _repository = repository;
            _repository1 = rep1;
        }
        public ViewResult FormMessagesList()
        {
            return View(_repository.messages);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult NewsList()
        {
            return View(_repository1.NewsTopics.Reverse());
        }
    }
}
