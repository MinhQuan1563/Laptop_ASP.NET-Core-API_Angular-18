namespace WAAL.Application.DTOs
{
    public class AuthResponseDTO
    {
        public string? Token { get; set; } = string.Empty;
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
