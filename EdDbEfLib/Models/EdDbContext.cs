using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EdDbEfLib.Models
{
    public partial class EdDbContext : DbContext
    {
        public EdDbContext()
        {
        }

        public EdDbContext(DbContextOptions<EdDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassGrade> ClassGrade { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MajorClass> MajorClass { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentClass> StudentClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=EdDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Class__46E78A0C");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK__Class__Instructo__440B1D61");
            });

            modelBuilder.Entity<ClassGrade>(entity =>
            {
                entity.HasKey(e => e.Grade)
                    .HasName("PK__ClassGra__DF0ADB7BD56D814D");

                entity.Property(e => e.Grade)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MinSat).HasColumnName("MinSAT");
            });

            modelBuilder.Entity<MajorClass>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.MajorClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MajorClas__Class__4AB81AF0");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.MajorClass)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MajorClas__Major__49C3F6B7");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sat).HasColumnName("SAT");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OH')");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Student__MajorId__3D5E1FD2");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.Property(e => e.ClassGradeValue)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClassGradeValueNavigation)
                    .WithMany(p => p.StudentClass)
                    .HasForeignKey(d => d.ClassGradeValue)
                    .HasConstraintName("FK__StudentCl__Class__4F7CD00D");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCl__Class__4E88ABD4");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentClass)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentCl__Stude__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
