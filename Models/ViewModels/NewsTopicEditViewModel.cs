using System.ComponentModel.DataAnnotations;

namespace CitrusMicroblog.Models.ViewModels
{
    public class NewsTopicEditViewModel
    {
        public int TopicID { get; set; }

        [Required]
        public string? TopicText { get; set; }

        public string? TopicButtonText { get; set; }
        public string? ButtonLink { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
