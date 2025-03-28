using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Rol1 { get; set; }

    public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}
