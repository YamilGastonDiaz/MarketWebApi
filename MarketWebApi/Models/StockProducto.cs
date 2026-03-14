using System;
using System.Collections.Generic;

namespace MarketWebApi.Models;

public partial class StockProducto
{
    public int Stock_id { get; set; }
    public int id_Producto { get; set; }
    public decimal Stock_actual { get; set; }
    public decimal PrecioDia { get; set; }
    public decimal PrecioNoche { get; set; }
    public virtual Producto id_ProductoNavigation { get; set; } = null!;
}
