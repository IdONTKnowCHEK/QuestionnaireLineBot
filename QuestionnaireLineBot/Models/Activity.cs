using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Activity
{
    public string ActivityId { get; set; } = null!;

    public string? ActivityName { get; set; }

    public bool? ActivityOpen { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreateTime { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual ICollection<Prize> Prizes { get; set; } = new List<Prize>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<SatisfactionQuestion> SatisfactionQuestions { get; set; } = new List<SatisfactionQuestion>();

    public virtual ICollection<SatisfactionResponse> SatisfactionResponses { get; set; } = new List<SatisfactionResponse>();

    public virtual ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}
