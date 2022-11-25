using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<EquipmentPhoto> equipmentPhotos => Set<EquipmentPhoto>();


    //public virtual DbSet<EquipmentPhoto> Equipments { get; set; }
    //public virtual DbSet<EquipmentPhoto> EquipmentPhotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(x=>x.MigrationsAssembly("QR_API"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentTableId).HasName("equipment_pk");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentTableId)
                .ValueGeneratedOnAdd()
                .HasColumnName("equipment_table_id");
            entity.Property(e => e.ResponsibleName)
                .HasColumnType("character varying")
                .HasColumnName("responsible_name");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<EquipmentPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoTableId).HasName("equipment_photos_pk");

            entity.ToTable("equipment_photos");

            entity.Property(e => e.PhotoTableId)
                .ValueGeneratedOnAdd()
                .HasColumnName("photo_table_id");
            entity.Property(e => e.EquipmentFkId)
                .ValueGeneratedOnAdd()
                .HasColumnName("equipment_fk_id");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");

            entity.HasOne(d => d.EquipmentFk).WithMany(p => p.EquipmentPhotos)
                .HasForeignKey(d => d.EquipmentFkId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("equipment_photos_fk");
        });

    }
}
