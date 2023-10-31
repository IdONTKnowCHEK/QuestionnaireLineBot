using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class PrizeMenu
{
    /// <summary>
    /// 獎品型號
    /// </summary>
    public string PrizeId { get; set; } = null!;

    /// <summary>
    /// 獎品名
    /// </summary>
    public string? PrizeName { get; set; }

    /// <summary>
    /// 活動編號
    /// </summary>
    public string? ActivityId { get; set; }

    /// <summary>
    /// 獎品總數
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// 獎品已兌數量
    /// </summary>
    public int? Receivedquantity { get; set; }

    /// <summary>
    /// 獎品圖片
    /// </summary>
    public string? Picture { get; set; }
}
