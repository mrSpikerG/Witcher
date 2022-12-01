using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Witcher.Model.DBModel;

namespace Witcher.Model;

public partial class WitcherContext : DbContext
{
    public WitcherContext()
    {
    }

    public WitcherContext(DbContextOptions<WitcherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avatar> Avatars { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharactersChapter> CharactersChapters { get; set; }

    public virtual DbSet<PageCategory> PageCategories { get; set; }

    public virtual DbSet<PageContext> PageContexts { get; set; }



    public virtual DbSet<PageTableVariable> PageTableVariables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2I5L44I\\SQLEXPRESS;Database=Witcher;Encrypt=false;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avatar>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.PageImage).HasColumnType("ntext");
            entity.Property(e => e.PreviewImage).HasColumnType("ntext");
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CharactersChapter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CharactersChapter");
        });

        modelBuilder.Entity<PageCategory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CategoryName).HasMaxLength(300);
        });

        modelBuilder.Entity<PageContext>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PageContext");

            entity.Property(e => e.CategoryName).HasMaxLength(300);
            entity.Property(e => e.VariableContext).HasColumnType("ntext");
        });

       

        modelBuilder.Entity<PageTableVariable>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.VariableContext).HasMaxLength(100);
            entity.Property(e => e.VariableName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
