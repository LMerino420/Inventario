using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back_Inventario.Models;

public partial class DbInventarioContext : DbContext
{
    public DbInventarioContext()
    {
    }

    public DbInventarioContext(DbContextOptions<DbInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryProd> CategoryProds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<UserAccess> UserAccesses { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryProd>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__category__79D361B6ED3E900D");

            entity.ToTable("categoryProd");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Category)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Descrip)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasColumnName("descrip");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__products__5EEC79D139AD89F7");

            entity.ToTable("products");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.ProdDescrip)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("prodDescrip");
            entity.Property(e => e.ProdName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("prodName");
            entity.Property(e => e.ProdPrice)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("prodPrice");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__prodPr__3F466844");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__3C872F76723BC32B");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stocks");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdWarehouse).HasColumnName("idWarehouse");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stocks__idProduc__412EB0B6");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany()
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stocks__idWareho__4222D4EF");
        });

        modelBuilder.Entity<UserAccess>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__userAcce__3717C982DEE0F325");

            entity.ToTable("userAccess");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.FrsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("frsName");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.LstName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("lstName");
            entity.Property(e => e.RefreshToken).HasColumnName("refreshToken");
            entity.Property(e => e.RefreshTokenExpireTime)
                .HasColumnType("datetime")
                .HasColumnName("refreshTokenExpireTime");
            entity.Property(e => e.UsrHash).HasColumnName("usrHash");
            entity.Property(e => e.UsrName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usrName");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserAccesses)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userAcces__refre__38996AB5");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("PK__warehous__4E557D38D46F0F17");

            entity.ToTable("warehouse");

            entity.Property(e => e.IdWarehouse).HasColumnName("idWarehouse");
            entity.Property(e => e.WhAddress)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("whAddress");
            entity.Property(e => e.WhName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("whName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
