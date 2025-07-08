namespace App.Application.DTOs
{
    public class FilterDto
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string sortColumn { get; set; } = string.Empty;
        public string sortOrder { get; set; } = string.Empty;
        public string SearchKey { get; set; } = string.Empty;
    }
}
