using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnJohnAThing.Data
{
    public partial class GameDataContext : DbContext
    {
        public GameDataContext()
        {
        }

        public GameDataContext(DbContextOptions<GameDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Heroes> Heroes { get; set; }
        public virtual DbSet<Monsters> Monsters { get; set; }
        public virtual DbSet<SaveFile> SaveFile { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Heroes>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Health).HasDefaultValueSql("((10))");

                entity.Property(e => e.Mana).HasDefaultValueSql("((5))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SaveFile)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.SaveFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Heroes_SaveFile");

                entity.HasOne(d => d.Skill1Navigation)
                    .WithMany(p => p.HeroesSkill1Navigation)
                    .HasForeignKey(d => d.Skill1)
                    .HasConstraintName("FK_Heroes_Skill1");

                entity.HasOne(d => d.Skill2Navigation)
                    .WithMany(p => p.HeroesSkill2Navigation)
                    .HasForeignKey(d => d.Skill2)
                    .HasConstraintName("FK_Heroes_Skill2");

                entity.HasOne(d => d.Skill3Navigation)
                    .WithMany(p => p.HeroesSkill3Navigation)
                    .HasForeignKey(d => d.Skill3)
                    .HasConstraintName("FK_Heroes_Skill3");

                entity.HasOne(d => d.Skill4Navigation)
                    .WithMany(p => p.HeroesSkill4Navigation)
                    .HasForeignKey(d => d.Skill4)
                    .HasConstraintName("FK_Heroes_Skill4");
            });

            modelBuilder.Entity<Monsters>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Health).HasDefaultValueSql("((10))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Skill1Navigation)
                    .WithMany(p => p.MonstersSkill1Navigation)
                    .HasForeignKey(d => d.Skill1)
                    .HasConstraintName("FK_Monsters_Skill1");

                entity.HasOne(d => d.Skill2Navigation)
                    .WithMany(p => p.MonstersSkill2Navigation)
                    .HasForeignKey(d => d.Skill2)
                    .HasConstraintName("FK_Monsters_Skill2");

                entity.HasOne(d => d.Skill3Navigation)
                    .WithMany(p => p.MonstersSkill3Navigation)
                    .HasForeignKey(d => d.Skill3)
                    .HasConstraintName("FK_Monsters_Skill3");

                entity.HasOne(d => d.Skill4Navigation)
                    .WithMany(p => p.MonstersSkill4Navigation)
                    .HasForeignKey(d => d.Skill4)
                    .HasConstraintName("FK_Monsters_Skill4");
            });

            modelBuilder.Entity<SaveFile>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastSavedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Accuracy).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cost).HasDefaultValueSql("((2))");

                entity.Property(e => e.Damage).HasDefaultValueSql("((3))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SaveFile)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.SaveFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Skill_SaveFile");
            });
        }
    }
}
