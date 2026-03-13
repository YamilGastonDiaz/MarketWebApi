using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Compra
{
    public int Compra_id { get; set; }
    public int id_Proveedor { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total_importe { get; set; }
    public bool Estado { get; set; } = true;
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
    public virtual Proveedore id_ProveedorNavigation { get; set; }
}
