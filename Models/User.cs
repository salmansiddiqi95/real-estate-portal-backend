﻿namespace RealEstate.API.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User";
        public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();
    }
}
