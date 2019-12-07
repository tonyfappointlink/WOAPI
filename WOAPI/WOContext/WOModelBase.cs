using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WOAPI.WOContext
{
    public partial class WOModelBase : DbContext
    {
        public WOModelBase()
        {
        }

        public WOModelBase(DbContextOptions<WOModelBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CompetitionMedias> CompetitionMedias { get; set; }
        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual DbSet<CompetitorMedias> CompetitorMedias { get; set; }
        public virtual DbSet<Competitors> Competitors { get; set; }
        public virtual DbSet<JournalPrefs> JournalPrefs { get; set; }
        public virtual DbSet<Journals> Journals { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=dev-sql1.appointlink_dev.loc;Database=WO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.CompetitionId)
                    .HasName("IX_FK_CompetitionCategory");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_Id");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionCategory");
            });

            modelBuilder.Entity<CompetitionMedias>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_FK_CategoryCompetitionMedia");

                entity.HasIndex(e => e.CompetitionId)
                    .HasName("IX_FK_CompetitionCompetitionMedia");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_Id");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.MediaId).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CompetitionMedias)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryCompetitionMedia");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionMedias)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionCompetitionMedia");
            });

            modelBuilder.Entity<Competitions>(entity =>
            {
                entity.Property(e => e.GroupId).IsRequired();
            });

            modelBuilder.Entity<CompetitorMedias>(entity =>
            {
                entity.HasIndex(e => e.CompetitorId)
                    .HasName("IX_FK_CompetitorCompetitorMedia");

                entity.Property(e => e.CompetitorId).HasColumnName("Competitor_Id");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UploadTime).HasColumnType("datetime");

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.CompetitorMedias)
                    .HasForeignKey(d => d.CompetitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitorCompetitorMedia");
            });

            modelBuilder.Entity<Competitors>(entity =>
            {
                entity.HasIndex(e => e.CompetitionId)
                    .HasName("IX_FK_CompetitionEntity1");

                entity.Property(e => e.AcceptAgreement).IsRequired();

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_Id");

                entity.Property(e => e.ExamId).IsRequired();

                entity.Property(e => e.GoCard).IsRequired();

                entity.Property(e => e.Grade).IsRequired();

                entity.Property(e => e.MemberId).IsRequired();

                entity.Property(e => e.PacketId).IsRequired();

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionEntity1");
            });

            modelBuilder.Entity<JournalPrefs>(entity =>
            {
                entity.HasIndex(e => e.CompetitionMemberId)
                    .HasName("IX_FK_CompetitionMemberJournalPref");

                entity.HasIndex(e => e.JournalId)
                    .HasName("IX_FK_JournalJournalPref");

                entity.Property(e => e.CompetitionMemberId).HasColumnName("CompetitionMember_Id");

                entity.Property(e => e.JournalId).HasColumnName("Journal_Id");

                entity.Property(e => e.Rank).IsRequired();

                entity.HasOne(d => d.CompetitionMember)
                    .WithMany(p => p.JournalPrefs)
                    .HasForeignKey(d => d.CompetitionMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionMemberJournalPref");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.JournalPrefs)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JournalJournalPref");
            });

            modelBuilder.Entity<Journals>(entity =>
            {
                entity.HasIndex(e => e.CompetitionId)
                    .HasName("IX_FK_CompetitionJournal");

                entity.Property(e => e.Abbreviation).IsRequired();

                entity.Property(e => e.Bbweight).HasColumnName("BBWeight");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_Id");

                entity.Property(e => e.LetterText).IsRequired();

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitionJournal");
            });

            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasIndex(e => e.CompetitorMediaId)
                    .HasName("IX_FK_CompetitorMediaScore");

                entity.Property(e => e.CompetitorMediaId).HasColumnName("CompetitorMedia_Id");

                entity.Property(e => e.ScoreTs)
                    .HasColumnName("ScoreTS")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CompetitorMedia)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.CompetitorMediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitorMediaScore");
            });
        }
    }
}
