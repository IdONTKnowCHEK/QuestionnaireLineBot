using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Prize
{
    public int PrizeId { get; set; }

    public string? ActivityId { get; set; }

    public string? PrizeName { get; set; }

    public int? TotalQuantity { get; set; }

    public int? RedeemedQuantity { get; set; }

    public string? PhotoUrl { get; set; }

    public int? GetType { get; set; }

    public string? Key1 { get; set; }

    public string? Key2 { get; set; }

    public string? Key3 { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual ICollection<PrizeRedemption> PrizeRedemptions { get; set; } = new List<PrizeRedemption>();
}
