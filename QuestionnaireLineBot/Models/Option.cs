using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Option
{
    /// <summary>
    /// 題目編號
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// 選項順序
    /// </summary>
    public int OptionOrder { get; set; }

    /// <summary>
    /// 選項
    /// </summary>
    public string? Item { get; set; }
}
