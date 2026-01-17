using CitrusMicroblog.Models;
using CitrusMicroblog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitrusMicroblog.Controllers
{
    public class AdminController : Controller
    {
        private IFormMessageRepository _repository;
        private readonly INewsRepository _repository1;
        private readonly IWebHostEnvironment _env;

        public AdminController(IFormMessageRepository repository, INewsRepository rep1, IWebHostEnvironment env)
        {
            _repository = repository;
            _repository1 = rep1;
            _env = env;
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

        [HttpGet]
        public ViewResult Edit(int topic)
        {
            return View(_repository1.NewsTopics.FirstOrDefault(t => t.NewsTopicID == topic));
        }

        [HttpPost]
        public IActionResult Edit(NewsTopic topic)
        {
            if (ModelState.IsValid)
            {
                _repository1.SaveTopic(topic);
                TempData["message"] = "saved";
                return RedirectToAction("NewsList");
            }
            return View(topic);
        }

        [HttpPost]
        public IActionResult Delete(int NewsTopicID)
        {
            NewsTopic deleted = _repository1.DeleteTopic(NewsTopicID);
            if(deleted != null)
            {
                TempData["message"] = "deleted";
            }
            return RedirectToAction("NewsList");
        }

        [HttpGet]
        public ViewResult NewNewsTopic()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewNewsTopic(NewsTopicEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string? imageName = null;

            if (model.ImageFile != null)
            {
                if (model.ImageFile.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Файл слишком большой");
                    return View(model);
                }
                var extension = Path.GetExtension(model.ImageFile.FileName).ToLower();
                var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowed.Contains(extension))
                {
                    ModelState.AddModelError("", "Недопустимый формат файла");
                    return View(model);
                }

                int nextId = (_repository1.NewsTopics.Any())
                    ? _repository1.NewsTopics.Max(n => n.NewsTopicID) + 1
                    : 1;

                imageName = $"Image{nextId}{extension}";


                string imagesPath = Path.Combine(_env.WebRootPath, "img", "NEWSIMG");
                string fullPath = Path.Combine(imagesPath, imageName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);
            }

            var topic = new NewsTopic
            {
                TopicText = model.TopicText,
                TopicButtonText = model.TopicButtonText,
                ButtonLink = model.ButtonLink,
                ImageName = imageName
            };
            _repository1.SaveTopic(topic);
            return RedirectToAction("Index");
        }
    }
}
