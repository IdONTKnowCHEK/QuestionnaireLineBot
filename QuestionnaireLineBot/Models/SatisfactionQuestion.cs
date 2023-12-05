using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class SatisfactionQuestion
{
    public int SatisfactionQuestionId { get; set; }

    public string? ActivityId { get; set; }

    public string? SatisfactionQuestionContent { get; set; }
}
