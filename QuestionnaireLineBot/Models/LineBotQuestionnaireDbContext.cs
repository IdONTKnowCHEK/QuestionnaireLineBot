using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireLineBot.Models;

public partial class LineBotQuestionnaireDbContext : DbContext
{
    public LineBotQuestionnaireDbContext()
    {
    }

    public LineBotQuestionnaireDbContext(DbContextOptions<LineBotQuestionnaireDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<Prize> Prizes { get; set; }

    public virtual DbSet<PrizeRedemption> PrizeRedemptions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<SatisfactionAnswer> SatisfactionAnswers { get; set; }

    public virtual DbSet<SatisfactionQuestion> SatisfactionQuestions { get; set; }

    public virtual DbSet<SatisfactionResponse> SatisfactionResponses { get; set; }

    public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA58621FA5590");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrizeRedemptionCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.SatisfactionAnswerCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.SurveyCount).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activity__45F4A7F18EB2029F");

            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Answer__D4825024E526CA8E");

            entity.ToTable("Answer");

            entity.Property(e => e.AnswerId)
                .ValueGeneratedNever()
                .HasColumnName("AnswerID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Options__92C7A1DFF94C919C");

            entity.Property(e => e.OptionId)
                .ValueGeneratedNever()
                .HasColumnName("OptionID");
            entity.Property(e => e.OptionContent)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
        });

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("PK__Particip__4EA27080AA8CE9F2");

            entity.ToTable("Participation");

            entity.Property(e => e.ParticipationId)
                .ValueGeneratedNever()
                .HasColumnName("ParticipationID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.JoinDate).HasColumnType("date");
        });

        modelBuilder.Entity<Prize>(entity =>
        {
            entity.HasKey(e => e.PrizeId).HasName("PK__Prize__5C36F4BB5A56C2D4");

            entity.ToTable("Prize");

            entity.Property(e => e.PrizeId)
                .ValueGeneratedNever()
                .HasColumnName("PrizeID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.Key1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Key2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Key3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.PrizeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PrizeRedemption>(entity =>
        {
            entity.HasKey(e => e.PrizeRedemptionId).HasName("PK__PrizeRed__E1212FF2D043C94A");

            entity.ToTable("PrizeRedemption");

            entity.Property(e => e.PrizeRedemptionId)
                .ValueGeneratedNever()
                .HasColumnName("PrizeRedemptionID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.PrizeId).HasColumnName("PrizeID");
            entity.Property(e => e.RedemptionDate).HasColumnType("datetime");
            entity.Property(e => e.RedemptionName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8CE603B5CB");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId)
                .ValueGeneratedNever()
                .HasColumnName("QuestionID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.QuestionContent)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatisfactionAnswer>(entity =>
        {
            entity.HasKey(e => e.SatisfactionAnswerId).HasName("PK__Satisfac__E4E2A32D65A2F999");

            entity.ToTable("SatisfactionAnswer");

            entity.Property(e => e.SatisfactionAnswerId)
                .ValueGeneratedNever()
                .HasColumnName("SatisfactionAnswerID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.SatisfactionQuestionId).HasColumnName("SatisfactionQuestionID");
        });

        modelBuilder.Entity<SatisfactionQuestion>(entity =>
        {
            entity.HasKey(e => e.SatisfactionQuestionId).HasName("PK__Satisfac__14B6CF113641F500");

            entity.ToTable("SatisfactionQuestion");

            entity.Property(e => e.SatisfactionQuestionId)
                .ValueGeneratedNever()
                .HasColumnName("SatisfactionQuestionID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.SatisfactionQuestionContent)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SatisfactionResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__Satisfac__1AAA640C243B63D4");

            entity.ToTable("SatisfactionResponse");

            entity.Property(e => e.ResponseId)
                .ValueGeneratedNever()
                .HasColumnName("ResponseID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.SubmissionTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<SurveyResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__SurveyRe__1AAA640C4A1F0CAE");

            entity.ToTable("SurveyResponse");

            entity.Property(e => e.ResponseId)
                .ValueGeneratedNever()
                .HasColumnName("ResponseID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.SubmissionTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
