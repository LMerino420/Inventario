using System;
using System.Collections.Generic;

namespace back_Inventario.Models;

public partial class UserAccess
{
    public int IdUser { get; set; }

    public int IdRol { get; set; }

    public string? FrsName { get; set; }

    public string? LstName { get; set; }

    public string? UsrName { get; set; }

    public string? UsrHash { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpireTime { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
