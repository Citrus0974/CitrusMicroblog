
namespace CitrusMicroblog.Models
{
    public class FakeNewsRepository : INewsRepository
    {
        public IEnumerable<NewsTopic> NewsTopics => new List<NewsTopic>
        {
            new NewsTopic {TopicText = @"Plants vs Zombies: Replanted - эти полтора не самых желанных видео побили все рекорды по просмотрам. Несмотря на это, я хочу продолжать работать над техническими видео, ну или по крайней мере над видео по PvZ: BfN и PvZ: GW2. Так что стоит посмотреть плейлист по BfN!",
            ImageName = "pvzrpl_capsule_616x353.jpg",
            TopicButtonText = "Плейлист",
            ButtonLink = @"#"},
            new NewsTopic {TopicText = @"Тестовые публикации фоток с помощью страниц, автоматически сгенерированных лайтрумом, находятся в разделе ""фотографирование"". Все же полноразмерные версии попадают в виде исходных jpg-файлов в отдельный Telegram-канал.",
            ImageName = "2025-05-17 (13).png",
            TopicButtonText = "Фото ТГК",
            ButtonLink = @"#"},
            new NewsTopic {TopicText = @"Пока что на этом IP/DNS почти ничего не хостится, но это только пока. Надеюсь, я дождусь того дня, когда серверная часть кастомных серверов GW2 станет общедоступной. Ну а пока что время от времени на порту 666 работает сервер Minecraft, подробнее о котором можно узнать ниже.",
            ImageName = "photo_2025-07-01_22-17-31.jpg",
            TopicButtonText = "MC Server",
            ButtonLink = @"#"}
        };

        public NewsTopic DeleteTopic(int topicID)
        {
            return new NewsTopic { TopicText = "null" };
        }

        public void SaveTopic(NewsTopic topic)
        {
           
        }
    }
}
