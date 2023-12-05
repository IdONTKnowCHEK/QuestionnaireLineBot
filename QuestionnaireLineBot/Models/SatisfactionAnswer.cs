using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class SatisfactionAnswer
{
    public int SatisfactionAnswerId { get; set; }

    public string? AccountId { get; set; }

    public int? SatisfactionQuestionId { get; set; }

    public int? AnswerContent { get; set; }
}
