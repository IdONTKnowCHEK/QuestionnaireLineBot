using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Option
{
    public int OptionId { get; set; }

    public int? QuestionId { get; set; }

    public int? OptionOrder { get; set; }

    public string? OptionContent { get; set; }

    public virtual Question? Question { get; set; }
}
