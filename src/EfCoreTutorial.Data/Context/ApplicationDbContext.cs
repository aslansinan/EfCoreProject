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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
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
                entity.Property(i => i.AddressId).HasColumnName("address_id");

                entity.HasMany(i => i.Books)//hedef table
                .WithOne(İ => İ.Student) //student tablosunda oto artan id
                .HasForeignKey(i => i.StudentId) //book tablosundaki alan
                .HasConstraintName("student_book_id_fk");

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
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");
                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").IsRequired().UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Author).HasColumnName("author").HasMaxLength(100); ;
            });
            modelBuilder.Entity<StudentAdress>(entity =>
            {
                entity.ToTable("student_adresses");
                entity.Property(i => i.Id).HasColumnName("id").IsRequired().UseIdentityColumn();
                entity.Property(i => i.City).HasColumnName("city").HasMaxLength(50);
                entity.Property(i => i.District).HasColumnName("district").HasMaxLength(150);
                entity.Property(i => i.Country).HasColumnName("country").HasMaxLength(150);
                entity.Property(i => i.FullAdress).HasColumnName("full_adress").HasMaxLength(150);

                entity.HasOne(i => i.Student).WithOne(i => i.Adress)
                .HasForeignKey<Student>(i => i.AddressId)
                .HasConstraintName("student_address_student_id_fk");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
