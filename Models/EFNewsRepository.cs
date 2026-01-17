
namespace CitrusMicroblog.Models
{
    public class EFNewsRepository : INewsRepository
    {
        private AppDbContext context;

        public EFNewsRepository(AppDbContext ctx)
        {
            this.context = ctx;
        }
        public IEnumerable<NewsTopic> NewsTopics => context.topics;

        public NewsTopic DeleteTopic(int topicID)
        {
            NewsTopic dbEntry = context.topics.FirstOrDefault(t => t.NewsTopicID == topicID);
            if (dbEntry != null)
            {
                context.topics.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveTopic(NewsTopic topic)
        {
            if(topic.NewsTopicID == 0)
            {
                context.topics.Add(topic);
            }
            else
            {
                NewsTopic dbEntry = context.topics.FirstOrDefault(t => t.NewsTopicID == topic.NewsTopicID);
                if(dbEntry != null)
                {
                    dbEntry.TopicText = topic.TopicText;
                    dbEntry.TopicButtonText = topic.TopicButtonText;
                    dbEntry.ButtonLink = topic.ButtonLink;
                    dbEntry.ImageName = topic.ImageName;
                }
            }
            context.SaveChanges();
        }
    }
}
