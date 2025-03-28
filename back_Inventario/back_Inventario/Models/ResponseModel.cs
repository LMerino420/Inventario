namespace back_Inventario.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Object { get; set; }
    }
}
