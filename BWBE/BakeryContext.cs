using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BWBE;

public partial class BakeryContext : DbContext
{
    public BakeryContext()
    {
    }

    public BakeryContext(DbContextOptions<BakeryContext> options)
        : base(options)
    {
    }

    private readonly IConfiguration _config;

    public BakeryContext(IConfiguration config)
    {
        _config = config;
        
    }

    public virtual DbSet<TblEmail> TblEmails { get; set; }

    public virtual DbSet<TblEmailType> TblEmailTypes { get; set; }

    public virtual DbSet<TblIngredient> TblIngredients { get; set; }

    public virtual DbSet<TblInventory> TblInventories { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblPhoneNumber> TblPhoneNumbers { get; set; }

    public virtual DbSet<TblPhoneType> TblPhoneTypes { get; set; }

    public virtual DbSet<TblSession> TblSessions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblVendor> TblVendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_config["ConnectionString:DefaultConnection"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TblEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PRIMARY");

            entity.ToTable("tblEmail");

            entity.HasIndex(e => e.UserId, "fk_tblEmail_UserID");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EmailID");
            entity.Property(e => e.EmailAddress).HasMaxLength(320);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.Valid).HasColumnType("bit(1)");

            entity.HasOne(d => d.User).WithMany(p => p.TblEmails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblEmail_UserID");
        });

        modelBuilder.Entity<TblEmailType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("tblEmailTypes");

            entity.Property(e => e.TypeId)
                .HasMaxLength(50)
                .HasColumnName("TypeID");
            entity.Property(e => e.Active).HasColumnType("bit(1)");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<TblIngredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PRIMARY");

            entity.ToTable("tblIngredients");

            entity.Property(e => e.IngredientId)
                .HasMaxLength(50)
                .HasColumnName("IngredientID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.MaximumAmount).HasColumnType("float(6,2)");
            entity.Property(e => e.Measurement).HasMaxLength(50);
            entity.Property(e => e.MinimumAmount).HasColumnType("float(6,2)");
            entity.Property(e => e.ReorderAmount).HasColumnType("float(6,2)");
        });

        modelBuilder.Entity<TblInventory>(entity =>
        {
            entity.HasKey(e => e.EntryId).HasName("PRIMARY");

            entity.ToTable("tblInventory");

            entity.HasIndex(e => e.EmployeeId, "fk_tblInventory_EmployeeID");

            entity.Property(e => e.EntryId)
                .HasMaxLength(50)
                .HasColumnName("EntryID");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.ExpireDateTime).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(50);
            entity.Property(e => e.Ponumber).HasColumnName("PONumber");
            entity.Property(e => e.RecipeId)
                .HasMaxLength(50)
                .HasColumnName("RecipeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblInventories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblInventory_EmployeeID");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PRIMARY");

            entity.ToTable("tblOrders");

            entity.HasIndex(e => e.VendorId, "fk_tblOrders_vendorID");

            entity.Property(e => e.PurchaseId)
                .HasMaxLength(50)
                .HasColumnName("purchaseID");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.VendorId)
                .HasMaxLength(50)
                .HasColumnName("vendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblOrders_vendorID");
        });

        modelBuilder.Entity<TblPhoneNumber>(entity =>
        {
            entity.HasKey(e => e.PhoneNumberId).HasName("PRIMARY");

            entity.ToTable("tblPhoneNumbers");

            entity.HasIndex(e => e.UserId, "fk_tblPhoneNumbers_UserID");

            entity.Property(e => e.PhoneNumberId)
                .HasMaxLength(50)
                .HasColumnName("PhoneNumberID");
            entity.Property(e => e.AreaCode).HasMaxLength(3);
            entity.Property(e => e.Number).HasMaxLength(7);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.Valid).HasColumnType("bit(1)");

            entity.HasOne(d => d.User).WithMany(p => p.TblPhoneNumbers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPhoneNumbers_UserID");
        });

        modelBuilder.Entity<TblPhoneType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("tblPhoneTypes");

            entity.Property(e => e.TypeId)
                .HasMaxLength(50)
                .HasColumnName("TypeID");
            entity.Property(e => e.Active).HasColumnType("bit(1)");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PRIMARY");

            entity.ToTable("tblSessions");

            entity.HasIndex(e => e.EmployeeId, "fk_tblSessions_employeeID");

            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .HasColumnName("sessionID");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("employeeID");
            entity.Property(e => e.LastActivityDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblSessions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblSessions_employeeID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("tblUsers");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        modelBuilder.Entity<TblVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PRIMARY");

            entity.ToTable("tblVendors");

            entity.Property(e => e.VendorId)
                .HasMaxLength(50)
                .HasColumnName("vendorID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
