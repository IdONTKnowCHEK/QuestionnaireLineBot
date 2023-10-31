﻿using QuestionnaireLineBot.Enum;

namespace QuestionnaireLineBot.Dtos.Message
{
    public class ImageMessageDto : BaseMessageDto
    {
        public ImageMessageDto()
        {
            Type = MessageTypeEnum.Image;
        }

        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
    }
}