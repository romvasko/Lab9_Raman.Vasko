using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab9_CodeFirst.Models
{
    public partial class Lab9_Context : DbContext
    {
        public Lab9_Context()
        {
        }

        public Lab9_Context(DbContextOptions<Lab9_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coachs { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-DCCMJU7B;Database=Lab9_;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.CoachName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerSalary).HasColumnType("money");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Players_Team");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_Coachs");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
