using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GPSPOIpontok.Models;

public partial class Adatok : DbContext
{
    public Adatok()
    {
    }

    public Adatok(DbContextOptions<Adatok> options)
        : base(options)
    {
    }

    public virtual DbSet<Dbmap> Dbmaps { get; set; }

    public virtual DbSet<Dbpoi> Dbpois { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()}\\Adatok.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dbmap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DBMaps__3214EC07E23E8585");

            entity.ToTable("DBMaps");

            entity.Property(e => e.Direction)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Image).HasColumnType("image");
        });

        modelBuilder.Entity<Dbpoi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DBPOIs__3214EC070B940B20");

            entity.ToTable("DBPOIs");

            entity.Property(e => e.Image).HasColumnType("image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
