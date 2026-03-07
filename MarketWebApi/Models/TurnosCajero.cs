using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class TurnosCajero
{
    public int Turno_id { get; set; }

    public int id_Usuario { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? MontoRecaudado { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    public virtual Usuario id_UsuarioNavigation { get; set; } = null!;
}
