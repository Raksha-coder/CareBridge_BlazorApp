namespace App.Application.DTOs
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int PhoneCode { get; set; }
    }
}
