using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class ReplyContent
{
    public string TestId { get; set; } = null!;

    public int QuestionId { get; set; }

    public int? ReplyOption { get; set; }
}
