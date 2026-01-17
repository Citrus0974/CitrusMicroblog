using CitrusMicroblog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitrusMicroblog.Controllers
{
    public class AdminController : Controller
    {
        private IFormMessageRepository _repository;

        public AdminController(IFormMessageRepository repository)
        {
            _repository = repository;
        }
        public ViewResult FormMessagesList()
        {
            return View(_repository.messages);
        }
    }
}
