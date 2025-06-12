using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudyPlatform.Models;

public partial class StudyPlatformContext : DbContext
{
    public StudyPlatformContext(DbContextOptions<StudyPlatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accomplishment> Accomplishments { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<BoughtSubject> BoughtSubjects { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Follower> Followers { get; set; }

    public virtual DbSet<Following> Followings { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<TopicProgress> TopicProgresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accomplishment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accompli__3214EC0783EDE1BD");

            entity.ToTable("Accomplishment");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Achievement).WithMany(p => p.Accomplishments)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__Accomplis__Achie__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Accomplishments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Accomplis__UserI__5535A963");
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Achievem__3214EC076085A0AA");

            entity.ToTable("Achievement");

            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Achieveme__UserI__5165187F");
        });

        modelBuilder.Entity<BoughtSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoughtSu__3214EC073A809151");

            entity.ToTable("BoughtSubject");

            entity.Property(e => e.Feedback)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Subject).WithMany(p => p.BoughtSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__BoughtSub__Subje__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.BoughtSubjects)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__BoughtSub__UserI__47DBAE45");
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chapter__3214EC0731DA6D08");

            entity.ToTable("Chapter");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Subject).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Chapter__Subject__398D8EEE");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC074116085F");

            entity.ToTable("Comment");

            entity.Property(e => e.Answer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Question).WithMany(p => p.Comments)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Comment__Questio__4222D4EF");
        });

        modelBuilder.Entity<Follower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Follower__3214EC0706FF7141");

            entity.ToTable("Follower");

            entity.HasOne(d => d.Following).WithMany(p => p.Followers)
                .HasForeignKey(d => d.FollowingId)
                .HasConstraintName("FK__Follower__Follow__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.Followers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Follower__UserId__5BE2A6F2");
        });

        modelBuilder.Entity<Following>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Followin__3214EC077082B321");

            entity.ToTable("Following");

            entity.Property(e => e.Chapter)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Topic)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Followings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Following__UserI__5812160E");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Progress__3214EC07B0A86A24");

            entity.ToTable("Progress");

            entity.Property(e => e.Chapter)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Topic)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Progress__UserId__4AB81AF0");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC0717AFFA24");

            entity.ToTable("Question");

            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Explanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.OtherAnswer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.QuestionText)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Question__TopicI__3F466844");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC07A89654B2");

            entity.ToTable("Subject");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Topic__3214EC078F0BF24B");

            entity.ToTable("Topic");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Chapter).WithMany(p => p.Topics)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__Topic__ChapterId__3C69FB99");
        });

        modelBuilder.Entity<TopicProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TopicPro__3214EC078E4565AC");

            entity.ToTable("TopicProgress");

            entity.HasOne(d => d.Progress).WithMany(p => p.TopicProgresses)
                .HasForeignKey(d => d.ProgressId)
                .HasConstraintName("FK__TopicProg__Progr__4D94879B");

            entity.HasOne(d => d.Topic).WithMany(p => p.TopicProgresses)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__TopicProg__Topic__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC070CD5BB06");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
