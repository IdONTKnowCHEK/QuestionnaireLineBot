using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? AccountId { get; set; }

    public int? QuestionId { get; set; }

    public int? AnswerContent { get; set; }
}
