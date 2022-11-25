using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database;

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
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Repos\\GPSPOIpontok\\Domain\\Adatok.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dbmap>(entity =>
        {
            entity.HasKey(e => e.MapId).HasName("PK__tmp_ms_x__3265E21BF73F4A15");

            entity.ToTable("DBMaps");

            entity.Property(e => e.Direction)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Image).HasColumnType("image");
        });

        modelBuilder.Entity<Dbpoi>(entity =>
        {
            entity.HasKey(e => e.Poiid).HasName("PK__tmp_ms_x__5229E0DF0C354374");

            entity.ToTable("DBPOIs");

            entity.Property(e => e.Poiid).HasColumnName("POIId");
            entity.Property(e => e.Image).HasColumnType("image");

            entity.HasOne(d => d.Map).WithMany(p => p.Dbpois)
                .HasForeignKey(d => d.MapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DBPOIs__MapId__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
