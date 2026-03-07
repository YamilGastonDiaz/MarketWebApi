using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Producto
{
    public int Producto_id { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public int id_Categoria { get; set; }

    public int id_Marca { get; set; }

    public int id_Empaque { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal? Stock_min { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual ICollection<StockProducto> StockProductos { get; set; } = new List<StockProducto>();

    public virtual Categoria id_CategoriaNavigation { get; set; } = null!;

    public virtual TiposEmpaque id_EmpaqueNavigation { get; set; } = null!;

    public virtual Marca id_MarcaNavigation { get; set; } = null!;
}
