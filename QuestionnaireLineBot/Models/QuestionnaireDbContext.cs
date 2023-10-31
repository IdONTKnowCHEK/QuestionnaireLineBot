using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireLineBot.Models;

public partial class QuestionnaireDbContext : DbContext
{
    public QuestionnaireDbContext()
    {
    }

    public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDatum> AccountData { get; set; }

    public virtual DbSet<AccountPerson> AccountPeople { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<PrizeDetail> PrizeDetails { get; set; }

    public virtual DbSet<PrizeMenu> PrizeMenus { get; set; }

    public virtual DbSet<QuestionBank> QuestionBanks { get; set; }

    public virtual DbSet<Reply> Replies { get; set; }

    public virtual DbSet<ReplyContent> ReplyContents { get; set; }

    public virtual DbSet<Satisfaction> Satisfactions { get; set; }

    public virtual DbSet<SatisfactionAnswer> SatisfactionAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountDatum>(entity =>
        {
            entity.HasKey(e => new { e.Account, e.ActivityId }).HasName("PK_accountData_1");

            entity.ToTable("accountData");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("帳號")
                .HasColumnName("account");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.AnswerTime)
                .HasComment("問卷填寫次數")
                .HasColumnName("answerTime");
            entity.Property(e => e.Prize)
                .HasComment("兌獎次數")
                .HasColumnName("prize");
            entity.Property(e => e.Satisfaction)
                .HasComment("滿意度填寫次數")
                .HasColumnName("satisfaction");
        });

        modelBuilder.Entity<AccountPerson>(entity =>
        {
            entity.HasKey(e => e.Account);

            entity.ToTable("accountPerson");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("使用者帳號(LOGIN_ID)")
                .HasColumnName("account");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("使用者所屬單位")
                .HasColumnName("department");
            entity.Property(e => e.DepartmentId)
                .HasComment("單位代碼")
                .HasColumnName("departmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("使用者電子信箱");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("使用者名稱")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("activity");

            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動名稱")
                .HasColumnName("activityName");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("建立日期")
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Enable)
                .HasComment("是否啟用")
                .HasColumnName("enable");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("活動結束日期")
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("活動起始日期")
                .HasColumnType("date")
                .HasColumnName("startDate");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => new { e.QuestionId, e.OptionOrder });

            entity.ToTable("options");

            entity.Property(e => e.QuestionId)
                .HasComment("題目編號")
                .HasColumnName("questionID");
            entity.Property(e => e.OptionOrder)
                .HasComment("選項順序")
                .HasColumnName("optionOrder");
            entity.Property(e => e.Item)
                .IsUnicode(false)
                .HasComment("選項")
                .HasColumnName("item");
        });

        modelBuilder.Entity<PrizeDetail>(entity =>
        {
            entity.ToTable("prizeDetails");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("獎品編號")
                .HasColumnName("ID");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("兌獎帳號")
                .HasColumnName("account");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.GetType)
                .HasComment("兌換方式類型(1:7-11、2:)")
                .HasColumnName("getType");
            entity.Property(e => e.Key1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("咖啡:短網址")
                .HasColumnName("key1");
            entity.Property(e => e.Key2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("咖啡:驗證碼")
                .HasColumnName("key2");
            entity.Property(e => e.Key3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("咖啡:序號")
                .HasColumnName("key3");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("兌獎人名字")
                .HasColumnName("name");
            entity.Property(e => e.PrizeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("獎品型號")
                .HasColumnName("prizeID");
            entity.Property(e => e.PrizeSendTime)
                .HasComment("兌獎時間")
                .HasColumnType("datetime")
                .HasColumnName("prizeSendTime");
        });

        modelBuilder.Entity<PrizeMenu>(entity =>
        {
            entity.HasKey(e => e.PrizeId);

            entity.ToTable("prizeMenu");

            entity.Property(e => e.PrizeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("獎品型號")
                .HasColumnName("prizeID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.Picture)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("獎品圖片")
                .HasColumnName("picture");
            entity.Property(e => e.PrizeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("獎品名")
                .HasColumnName("prizeName");
            entity.Property(e => e.Quantity)
                .HasComment("獎品總數")
                .HasColumnName("quantity");
            entity.Property(e => e.Receivedquantity)
                .HasComment("獎品已兌數量")
                .HasColumnName("receivedquantity");
        });

        modelBuilder.Entity<QuestionBank>(entity =>
        {
            entity.HasKey(e => e.QuestionId);

            entity.ToTable("questionBank");

            entity.Property(e => e.QuestionId)
                .HasComment("題目編號")
                .HasColumnName("questionID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.Answer)
                .HasComment("解答")
                .HasColumnName("answer");
            entity.Property(e => e.Question)
                .IsUnicode(false)
                .HasComment("題目")
                .HasColumnName("question");
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK_reply_1");

            entity.ToTable("reply");

            entity.Property(e => e.TestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("答卷流水號")
                .HasColumnName("testID");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("帳號")
                .HasColumnName("account");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.Score)
                .HasComment("分數")
                .HasColumnName("score");
            entity.Property(e => e.TestSendTime)
                .HasComment("考卷回答送出時間")
                .HasColumnType("datetime")
                .HasColumnName("testSendTime");
        });

        modelBuilder.Entity<ReplyContent>(entity =>
        {
            entity.HasKey(e => new { e.TestId, e.QuestionId });

            entity.ToTable("replyContent");

            entity.Property(e => e.TestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("testID");
            entity.Property(e => e.QuestionId).HasColumnName("questionID");
            entity.Property(e => e.ReplyOption).HasColumnName("replyOption");
        });

        modelBuilder.Entity<Satisfaction>(entity =>
        {
            entity.HasKey(e => e.SatisfactionQuestion).HasName("PK_satisfaction_1");

            entity.ToTable("satisfaction");

            entity.Property(e => e.SatisfactionQuestion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("滿意度問題")
                .HasColumnName("satisfactionQuestion");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
        });

        modelBuilder.Entity<SatisfactionAnswer>(entity =>
        {
            entity.HasKey(e => new { e.Account, e.ActivityId });

            entity.ToTable("satisfactionAnswer");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("帳號")
                .HasColumnName("account");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("活動編號")
                .HasColumnName("activityID");
            entity.Property(e => e.SatisfactionQuestionFive)
                .HasComment("滿意度第5題回答")
                .HasColumnName("satisfactionQuestionFive");
            entity.Property(e => e.SatisfactionQuestionFour)
                .HasComment("滿意度第4題回答")
                .HasColumnName("satisfactionQuestionFour");
            entity.Property(e => e.SatisfactionQuestionOne)
                .HasComment("滿意度第1題回答")
                .HasColumnName("satisfactionQuestionOne");
            entity.Property(e => e.SatisfactionQuestionThree)
                .HasComment("滿意度第3題回答")
                .HasColumnName("satisfactionQuestionThree");
            entity.Property(e => e.SatisfactionQuestionTwo)
                .HasComment("滿意度第2題回答")
                .HasColumnName("satisfactionQuestionTwo");
            entity.Property(e => e.SatisfactionSendTime)
                .HasComment("滿意度填答送出時間")
                .HasColumnType("datetime")
                .HasColumnName("satisfactionSendTime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
