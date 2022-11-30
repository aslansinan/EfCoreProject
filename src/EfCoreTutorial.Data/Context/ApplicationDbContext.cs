using EfCoreTutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTutorial.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options ) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Database=EfCoreTutorial;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");
                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").IsRequired().UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
                entity.Property(i => i.Number).HasColumnName("nuber");
            });
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");
                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");
                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").IsRequired().UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.isActive).HasColumnName("is_active");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
