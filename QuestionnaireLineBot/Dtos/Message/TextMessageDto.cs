using QuestionnaireLineBot.Enum;

namespace QuestionnaireLineBot.Dtos.Message
{
    public class TextMessageDto : BaseMessageDto
    {
        public TextMessageDto()
        {
            Type = MessageTypeEnum.Text;
        }
        public string Text { get; set; }
    }
}
