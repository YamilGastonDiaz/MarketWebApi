using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class DetalleCompra
{
    public int Detalle_id { get; set; }

    public int id_Compra { get; set; }

    public int id_Producto { get; set; }

    public int id_Marca { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal Subtotal { get; set; }

    public bool Estado { get; set; }

    public virtual Compra id_CompraNavigation { get; set; } = null!;

    public virtual Marca id_MarcaNavigation { get; set; } = null!;

    public virtual Producto id_ProductoNavigation { get; set; } = null!;
}
