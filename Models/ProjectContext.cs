using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OCM2.Models
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OcmAdmin> OcmAdmins { get; set; }
        public virtual DbSet<OcmConsignment> OcmConsignments { get; set; }
        public virtual DbSet<OcmDeliveryExecutive> OcmDeliveryExecutives { get; set; }
        public virtual DbSet<OcmTracking> OcmTrackings { get; set; }
        public virtual DbSet<OcmUser> OcmUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JKRISHNA-JK;Database=Project;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<OcmAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("pk_admin");

                entity.ToTable("OCM_Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("Admin_id");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Admin_email");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Admin_name");
            });

            modelBuilder.Entity<OcmConsignment>(entity =>
            {
                entity.HasKey(e => e.ConsignmentId)
                    .HasName("pk_Consignment");

                entity.ToTable("OCM_Consignment");

                entity.Property(e => e.ConsignmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Consignment_id");

                entity.Property(e => e.ConsigneName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Consigne_name");

                entity.Property(e => e.ConsignerName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Consigner_name");

                entity.Property(e => e.ConsignmentType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Consignment_type");

                entity.Property(e => e.DateOfBooking)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_booking");

                entity.Property(e => e.DelId).HasColumnName("Del_id");

                entity.Property(e => e.DestinationCity)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Destination_city");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("Expected_delivery_date");

                entity.Property(e => e.SourceCity)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Source_city");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Del)
                    .WithMany(p => p.OcmConsignments)
                    .HasForeignKey(d => d.DelId)
                    .HasConstraintName("fk_Del_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OcmConsignments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_fk");
            });

            modelBuilder.Entity<OcmDeliveryExecutive>(entity =>
            {
                entity.HasKey(e => e.DelId)
                    .HasName("pk_Del");

                entity.ToTable("OCM_Delivery_Executive");

                entity.Property(e => e.DelId)
                    .ValueGeneratedNever()
                    .HasColumnName("Del_id");

                entity.Property(e => e.DelName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Del_name");

                entity.Property(e => e.DelNumber).HasColumnName("Del_number");
            });

            modelBuilder.Entity<OcmTracking>(entity =>
            {
                entity.HasKey(e => e.TrackingId)
                    .HasName("pk_Tracking");

                entity.ToTable("OCM_Tracking");

                entity.Property(e => e.TrackingId)
                    .ValueGeneratedNever()
                    .HasColumnName("Tracking_id");

                entity.Property(e => e.ConsignmentId).HasColumnName("Consignment_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Consignment)
                    .WithMany(p => p.OcmTrackings)
                    .HasForeignKey(d => d.ConsignmentId)
                    .HasConstraintName("fk_consignment_id");
            });

            modelBuilder.Entity<OcmUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_User");

                entity.ToTable("OCM_User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_id");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_address");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
