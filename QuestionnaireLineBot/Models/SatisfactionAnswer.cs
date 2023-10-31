using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class SatisfactionAnswer
{
    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 活動編號
    /// </summary>
    public string ActivityId { get; set; } = null!;

    /// <summary>
    /// 滿意度第1題回答
    /// </summary>
    public int? SatisfactionQuestionOne { get; set; }

    /// <summary>
    /// 滿意度第2題回答
    /// </summary>
    public int? SatisfactionQuestionTwo { get; set; }

    /// <summary>
    /// 滿意度第3題回答
    /// </summary>
    public int? SatisfactionQuestionThree { get; set; }

    /// <summary>
    /// 滿意度第4題回答
    /// </summary>
    public int? SatisfactionQuestionFour { get; set; }

    /// <summary>
    /// 滿意度第5題回答
    /// </summary>
    public int? SatisfactionQuestionFive { get; set; }

    /// <summary>
    /// 滿意度填答送出時間
    /// </summary>
    public DateTime? SatisfactionSendTime { get; set; }
}
