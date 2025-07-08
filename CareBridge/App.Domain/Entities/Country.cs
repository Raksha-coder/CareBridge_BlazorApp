namespace App.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int PhoneCode { get; set; }
    }
}
