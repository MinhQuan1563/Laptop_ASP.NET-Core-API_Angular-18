using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace WAAL.Application.DTOs
{
    public class UserCreateDTO
    {
        public Guid Id { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        [JsonIgnore]
        public IFormFile? HinhAnh { get; set; }
        public string? DiaChi { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string HinhAnh { get; set; }
        public string? DiaChi { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
