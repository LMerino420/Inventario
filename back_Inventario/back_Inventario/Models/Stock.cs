using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class Stock
{
    public int IdProduct { get; set; }

    public int IdWarehouse { get; set; }

    public int? Qty { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;
}
