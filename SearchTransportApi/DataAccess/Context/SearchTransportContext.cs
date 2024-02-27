using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SearchTransportApi.Models.DataAccessModels;

namespace SearchTransportApi.DataAccess.Context;

public partial class SearchTransportContext : DbContext
{
    public SearchTransportContext()
    {
    }

    public SearchTransportContext(DbContextOptions<SearchTransportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SearchTranportDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A042D911FEA");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ClientName).HasMaxLength(50);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.Location).WithMany(p => p.Clients)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_LocationID");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477E5DC4FEE");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__476B54B2121EDDFA");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.VehicleName).HasMaxLength(50);

            entity.HasOne(d => d.Location).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_LocationID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
