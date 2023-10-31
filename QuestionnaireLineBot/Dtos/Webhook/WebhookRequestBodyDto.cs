﻿using QuestionnaireLineBot.Dtos;

namespace QuestionnaireLineBot.Dtos.Webhook
{
    public class WebhookRequestBodyDto
    {
        public string? Destination { get; set; }
        public List<WebhookEventsDto> Events { get; set; }
    }
}
