namespace back_Inventario.Models.Dtos
{
    public class JwtDto
    {
        public required string Token { get; set; }
        public required DateTime ExpireToken { get; set; }
    }
}
