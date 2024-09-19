using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext() { }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options) { }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }

        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StudentSystem;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                .IsRequired()
                .HasColumnName("StudentID");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

                entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength(true)
                .IsRequired(false)
                .IsUnicode(false)
                .IsConcurrencyToken(false);

                entity.Property(e => e.RegisteredOn)
                .IsRequired(false);

                entity.Property(e => e.Birthday)
                .IsRequired(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);
                entity.Property(e => e.Content)
                .IsUnicode(false);

                entity.HasOne(homework => homework.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId);

                entity.HasOne(homework => homework.Course)
                .WithMany(course => course.Homeworks)
                .HasForeignKey(homework => homework.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(resource => resource.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

                entity.Property(resource => resource.Url)
                .IsUnicode(false);

                entity.HasOne(resource => resource.Course)
                .WithMany()
                .HasForeignKey(resource => resource.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new {sc.StudentId, sc.CourseId});

                entity.HasOne(sc => sc.Student)
                .WithMany()
                .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                .WithMany()
                .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
