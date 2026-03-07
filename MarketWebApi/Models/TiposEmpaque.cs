using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class TiposEmpaque
{
    public int Empaque_id { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal CantidadUnidad { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
