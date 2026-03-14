using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Venta
{
    public int Venta_id { get; set; }
    public int id_Usuario { get; set; }
    public int id_Turno { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total_importe { get; set; }
    public bool Estado { get; set; } = true;
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    public virtual TurnosCajero id_TurnoNavigation { get; set; } = null!;
    public virtual Usuario id_UsuarioNavigation { get; set; } = null!;
}
