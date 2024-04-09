using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class UserDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UserDb;Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(u =>
        {
            u.ToTable("Users").HasKey(u => u.Id);
            u.Property(u => u.Id).HasColumnName("Id");
            u.Property(u => u.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            u.Property(u => u.LastName).HasColumnName("LastName").HasMaxLength(50);
            u.Property(u => u.Email).HasColumnName("Email").HasMaxLength(250);
            u.Property(u => u.Phone).HasColumnName("Phone").HasMaxLength(25);
            u.Property(u => u.Password).HasColumnName("Password").HasMaxLength(50);
            u.Property(u => u.ProfileImageUrl).HasColumnName("ProfileImageUrl");
        });
    }

    public DbSet<User> Users { get; set; }
}
