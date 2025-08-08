namespace RealEstate.API.DTOs
{
    public class PropertyFilterDto
    {
        public string? Suburb { get; set; }
        public int Bedrooms { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
}
