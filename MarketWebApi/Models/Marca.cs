using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Marca
{
    public int Marca_id { get; set; }
    public string Descripcion { get; set; }
    public bool Estado { get; set; }
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
