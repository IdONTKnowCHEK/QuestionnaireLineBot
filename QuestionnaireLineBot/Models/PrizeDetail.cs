using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class PrizeDetail
{
    /// <summary>
    /// 獎品編號
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 獎品型號
    /// </summary>
    public string? PrizeId { get; set; }

    /// <summary>
    /// 活動編號
    /// </summary>
    public string? ActivityId { get; set; }

    /// <summary>
    /// 兌換方式類型(1:7-11、2:)
    /// </summary>
    public int? GetType { get; set; }

    /// <summary>
    /// 兌獎帳號
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 兌獎人名字
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 咖啡:短網址
    /// </summary>
    public string? Key1 { get; set; }

    /// <summary>
    /// 咖啡:驗證碼
    /// </summary>
    public string? Key2 { get; set; }

    /// <summary>
    /// 咖啡:序號
    /// </summary>
    public string? Key3 { get; set; }

    /// <summary>
    /// 兌獎時間
    /// </summary>
    public DateTime? PrizeSendTime { get; set; }
}
