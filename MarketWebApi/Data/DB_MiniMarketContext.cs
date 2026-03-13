using System;
using System.Collections.Generic;
using MarketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Data;

public partial class DB_MiniMarketContext : DbContext
{
    public DB_MiniMarketContext(DbContextOptions<DB_MiniMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    public virtual DbSet<StockProducto> StockProductos { get; set; }

    public virtual DbSet<TiposEmpaque> TiposEmpaques { get; set; }

    public virtual DbSet<TurnosCajero> TurnosCajeros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Categoria_id).HasName("PK__Categori__C928AD526ADCF355");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Compra_id).HasName("PK__Compras__BAF07573EA0D4CFA");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Total_importe).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_ProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.id_Proveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compras__id_Prov__4222D4EF");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Detalle_id).HasName("PK__DetalleC__CED7B6173080EDD4");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_CompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.id_Compra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__id_Co__45F365D3");

            entity.HasOne(d => d.id_MarcaNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.id_Marca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__id_Ma__47DBAE45");

            entity.HasOne(d => d.id_ProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.id_Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCo__id_Pr__46E78A0C");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.DetalleVenta_id).HasName("PK__DetalleV__EBD496ABF10533E0");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_MarcaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.id_Marca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__id_Ma__5629CD9C");

            entity.HasOne(d => d.id_ProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.id_Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__id_Pr__5535A963");

            entity.HasOne(d => d.id_VentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.id_Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__id_Ve__5441852A");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Marca_id).HasName("PK__Marcas__5546B22C5B05ADE7");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Producto_id).HasName("PK__Producto__9F1818A53B37D17E");

            entity.HasIndex(e => e.CodigoBarras, "UQ__Producto__F61589C8E2DA2AFB").IsUnique();

            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Stock_min)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_CategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.id_Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__id_Ca__36B12243");

            entity.HasOne(d => d.id_EmpaqueNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.id_Empaque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__id_Em__38996AB5");

            entity.HasOne(d => d.id_MarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.id_Marca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__id_Ma__37A5467C");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Proveedor_id).HasName("PK__Proveedo__0791AFE3460AD615");

            entity.Property(e => e.CUIT)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Empresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StockProducto>(entity =>
        {
            entity.HasKey(e => e.Stock_id).HasName("PK__StockPro__EF9B7AD04404B8D6");

            entity.Property(e => e.PrecioDia)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioNoche)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Stock_actual)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_ProductoNavigation).WithMany(p => p.StockProductos)
                .HasForeignKey(d => d.id_Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockProd__id_Pr__3E52440B");
        });

        modelBuilder.Entity<TiposEmpaque>(entity =>
        {
            entity.HasKey(e => e.Empaque_id).HasName("PK__TiposEmp__52A58DE0FC768245");

            entity.Property(e => e.CantidadUnidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<TurnosCajero>(entity =>
        {
            entity.HasKey(e => e.Turno_id).HasName("PK__TurnosCa__6613A964B4DC787F");

            entity.ToTable("TurnosCajero");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.MontoRecaudado).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_UsuarioNavigation).WithMany(p => p.TurnosCajeros)
                .HasForeignKey(d => d.id_Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TurnosCaj__id_Us__4BAC3F29");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuario_id).HasName("PK__Usuarios__77101CFD02118836");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuarios__E3237CF7242534EB").IsUnique();

            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Venta_id).HasName("PK__Ventas__24B4433804E22624");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Total_importe).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_TurnoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.id_Turno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__id_Turno__5070F446");

            entity.HasOne(d => d.id_UsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.id_Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__id_Usuar__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
