using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class Proveedore
{
    public int Proveedor_id { get; set; }
    public string Nombre { get; set; }
    public string CUIT { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Empresa { get; set; }
    public bool Estado { get; set; }
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
