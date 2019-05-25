using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoboSapiens.EF.Models
{
    public partial class SupportSapiensContext : DbContext
    {
        public SupportSapiensContext()
        {
        }

        public SupportSapiensContext(DbContextOptions<SupportSapiensContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgentIssueTag> AgentIssueTag { get; set; }
        public virtual DbSet<AgentUser> AgentUser { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<CustomerUser> CustomerUser { get; set; }
        public virtual DbSet<IssueTag> IssueTag { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SupportSapiens;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentIssueTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.AgentIssueTag)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgentIssueTag_Agent");

                entity.HasOne(d => d.IssueTag)
                    .WithMany(p => p.AgentIssueTag)
                    .HasForeignKey(d => d.IssueTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgentIssueTag_IssueTag");
            });

            modelBuilder.Entity<AgentUser>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [userUniqueId])");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("Conversation", "conv");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PrevalentEmotion).HasMaxLength(255);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Conversation)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversation_AgentUser");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Conversation)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversation_CustomerUser");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Conversation)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversation_IssueTag");
            });

            modelBuilder.Entity<CustomerUser>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [userUniqueId])");

                entity.Property(e => e.Attributes).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<IssueTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message", "conv");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsFromAgent).HasColumnName("isFromAgent");

                entity.Property(e => e.PrimaryEmotion).HasMaxLength(255);

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.HasSequence("userUniqueId");
        }
    }
}
