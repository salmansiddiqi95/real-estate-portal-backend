namespace RealEstate.API.Models
{
    public class Favourite
    {
         public int UserId { get; set; }
         public int PropertyId { get; set; }
         public User User { get; set; }
         public Property Property { get; set; }
    }
}
