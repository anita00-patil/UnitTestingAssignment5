using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnitTestingAssignment5.Models;

public partial class UnitDbContext : DbContext
{
   

    public UnitDbContext(DbContextOptions<UnitDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07723468A5");

            entity.ToTable("Student");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
