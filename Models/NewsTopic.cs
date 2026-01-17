namespace CitrusMicroblog.Models
{
    public class NewsTopic
    {
        public int TopicID { get; set; }
        public string? TopicText { get; set; }
        public string? TopicButtonText { get; set; } 
        public string? ButtonLink { get; set; }
        public string? ImageName { get; set; }
    }
}
