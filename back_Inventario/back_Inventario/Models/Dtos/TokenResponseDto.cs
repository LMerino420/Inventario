namespace back_Inventario.Models.Dtos
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public required DateTime ExpireToken { get; set; }
    }
}
