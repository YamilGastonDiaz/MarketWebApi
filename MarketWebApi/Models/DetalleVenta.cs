using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class DetalleVenta
{
    public int DetalleVenta_id { get; set; }

    public int id_Venta { get; set; }

    public int id_Producto { get; set; }

    public int id_Marca { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public bool Estado { get; set; }

    public virtual Marca id_MarcaNavigation { get; set; } = null!;

    public virtual Producto id_ProductoNavigation { get; set; } = null!;

    public virtual Venta id_VentaNavigation { get; set; } = null!;
}
