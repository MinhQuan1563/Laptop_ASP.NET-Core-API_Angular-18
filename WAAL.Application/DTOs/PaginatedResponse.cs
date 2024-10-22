namespace WAAL.Application.DTOs
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
