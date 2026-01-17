using System.Linq;
namespace CitrusMicroblog.Models
{
    public class EFFormMessageRepository : IFormMessageRepository
    {
        private AppDbContext DbContext;
        public EFFormMessageRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IEnumerable<FormMessage> messages
        {
            get
            {
                return DbContext.messages;
                //return DbContext.messages.Reverse().Take(100);
            }
        }

        public void SaveMessage(FormMessage message)
        {
            if(message.FormMessageID == 0)
            {
                DbContext.messages.Add(message);
                DbContext.SaveChanges();
            }
        }
    }
}
