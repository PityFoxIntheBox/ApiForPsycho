using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiForPsycho.Models;

public partial class PsychoTestsContext : DbContext
{
    public PsychoTestsContext()
    {
    }

    public PsychoTestsContext(DbContextOptions<PsychoTestsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersTest> UsersTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ngknn.ru; Database=PsychoTests; User ID=43П; Password=444444; Trusted_Connection=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.Property(e => e.AnswerId).HasColumnName("Answer_id");
            entity.Property(e => e.AnswerName)
                .IsUnicode(false)
                .HasColumnName("Answer_name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("Category_name");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.QuestionId).HasColumnName("Question_id");
            entity.Property(e => e.Content).IsUnicode(false);
            entity.Property(e => e.IdAnswer).HasColumnName("Id_answer");
            entity.Property(e => e.IdTest).HasColumnName("Id_test");

            entity.HasOne(d => d.IdAnswerNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdAnswer)
                .HasConstraintName("FK_Questions_Answers");

            entity.HasOne(d => d.IdTestNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdTest)
                .HasConstraintName("FK_Questions_Tests");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(e => e.ResultId).HasColumnName("Result_id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.IdTest).HasColumnName("Id_test");
            entity.Property(e => e.ResultName)
                .IsUnicode(false)
                .HasColumnName("Result_name");
            entity.Property(e => e.ScoreCount).HasColumnName("Score_count");

            entity.HasOne(d => d.IdTestNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.IdTest)
                .HasConstraintName("FK_Results_Tests");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.TestId).HasColumnName("Test_id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.IdCategory).HasColumnName("Id_category");
            entity.Property(e => e.QuestionsCount).HasColumnName("Questions_count");
            entity.Property(e => e.TestName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Test_name");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_Tests_Categories");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.IdDoctor).HasColumnName("Id_doctor");
            entity.Property(e => e.IdRole).HasColumnName("Id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UsersTest>(entity =>
        {
            entity.ToTable("Users_Tests");

            entity.Property(e => e.IdResult).HasColumnName("Id_result");
            entity.Property(e => e.IdUser).HasColumnName("Id_user");

            entity.HasOne(d => d.IdResultNavigation).WithMany(p => p.UsersTests)
                .HasForeignKey(d => d.IdResult)
                .HasConstraintName("FK_Users_Tests_Results");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UsersTests)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Users_Tests_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
