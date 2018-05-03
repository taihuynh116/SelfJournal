namespace Database.EF
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public partial class SelfJournalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "data source=103.252.252.163;initial catalog=SelfJournal;persist security info=True;user id=misery;password=Skarner116!;MultipleActiveResultSets=True;App=EntityFramework";
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        public virtual DbSet<Diary> Diaries { get; set; }
        public virtual DbSet<Emotion> Emotions { get; set; }
        public virtual DbSet<Expenditure> Expenditures { get; set; }
        public virtual DbSet<ExpenditureType> ExpenditureTypes { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<GoalOfDay> GoalOfDays { get; set; }
        public virtual DbSet<GoalOfMonth> GoalOfMonths { get; set; }
        public virtual DbSet<Habbit> Habbits { get; set; }
        public virtual DbSet<HabbitType> HabbitTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ExpenditureType>()
        //        .HasMany(e => e.Expenditures)
        //        .WithRequired(e => e.ExpenditureType)
        //        .HasForeignKey(e => e.IDExpenditure)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Goal>()
        //        .HasMany(e => e.GoalOfMonths)
        //        .WithRequired(e => e.Goal)
        //        .HasForeignKey(e => e.IDGoal)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<GoalOfMonth>()
        //        .HasMany(e => e.GoalOfDays)
        //        .WithRequired(e => e.GoalOfMonth)
        //        .HasForeignKey(e => e.IDGoalOfMonth)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<HabbitType>()
        //        .HasMany(e => e.Habbits)
        //        .WithRequired(e => e.HabbitType)
        //        .HasForeignKey(e => e.IDHabbitType)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
