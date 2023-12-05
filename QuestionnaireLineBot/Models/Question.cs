using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string? ActivityId { get; set; }

    public string? QuestionContent { get; set; }

    public int? Answer { get; set; }
}
