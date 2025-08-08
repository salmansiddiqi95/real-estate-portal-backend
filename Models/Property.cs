namespace RealEstate.API.Models
{
   public class Property
   {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string ListingType { get; set; } 
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }

        public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();
   }
}
