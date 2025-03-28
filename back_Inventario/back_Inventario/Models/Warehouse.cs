using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string? WhName { get; set; }

    public string? WhAddress { get; set; }
}
