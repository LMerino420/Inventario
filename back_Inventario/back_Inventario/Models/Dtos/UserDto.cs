namespace back_Inventario.Models.Dtos
{
    public class UserDto
    {
        public int IdRol { get; set; }

        public string? FrsName { get; set; } = string.Empty;

        public string? LstName { get; set; } = string.Empty;

        public string? UsrName { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;
    }
}
