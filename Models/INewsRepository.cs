namespace CitrusMicroblog.Models
{
    public interface INewsRepository
    {
        IEnumerable<NewsTopic> NewsTopics { get; }

        void SaveTopic(NewsTopic topic);

        NewsTopic DeleteTopic(int topicID);
    }
}
