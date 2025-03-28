using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int IdCategory { get; set; }

    public string? ProdName { get; set; }

    public string? ProdDescrip { get; set; }

    public decimal? ProdPrice { get; set; }

    public virtual CategoryProd IdCategoryNavigation { get; set; } = null!;
}
