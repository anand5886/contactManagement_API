using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMS.Data.Models
{
    public partial class HRMSContext : DbContext
    {
        public HRMSContext()
        {
        }

        public HRMSContext(DbContextOptions<HRMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblContacts> TblContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblContacts>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("TBL_CONTACTS");

                entity.HasIndex(e => e.Email)
                    .HasName("ind_238")
                    .IsUnique();

                entity.Property(e => e.ContactId).HasColumnName("CONTACT_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
