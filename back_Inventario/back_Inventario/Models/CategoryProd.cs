using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class CategoryProd
{
    public int IdCategory { get; set; }

    public string? Category { get; set; }

    public string? Descrip { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
