using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Questions
{
    /// <summary>
    /// 題目編號
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// 題目
    /// </summary>
    public string? Question { get; set; }

    /// <summary>
    /// 選項
    /// </summary>
    public List<string>? Options { get; set; }

    /// <summary>
    /// 解答
    /// </summary>
    public int? Answer { get; set; }
}
