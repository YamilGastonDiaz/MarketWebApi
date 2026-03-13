using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class TiposEmpaque
{
    public int Empaque_id { get; set; }
    public string Descripcion { get; set; }
    public decimal CantidadUnidad { get; set; }
    public bool Estado { get; set; } = true;
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
