using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Usuario
{
    public int Usuario_id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Usuario1 { get; set; } = null!;
    public string Contrasenia { get; set; } = null!;
    public int Rol { get; set; }
    public bool Estado { get; set; } = true;
    public virtual ICollection<TurnosCajero> TurnosCajeros { get; set; } = new List<TurnosCajero>();
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
