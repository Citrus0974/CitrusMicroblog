namespace CitrusMicroblog.Models
{
    public interface IFormMessageRepository
    {
        IEnumerable<FormMessage> messages { get; }
        void SaveMessage(FormMessage message);
    }
}
