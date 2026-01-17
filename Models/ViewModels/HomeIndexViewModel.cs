namespace CitrusMicroblog.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public FormMessage message { get; set; }
        public IEnumerable<NewsTopic> topics { get; set; }
    }
}
