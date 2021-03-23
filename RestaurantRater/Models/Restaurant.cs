using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {

        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }

        public class RestaurantDbContext: DbContext //we are set up to inherit from the DbContext class
        {
            //the collection of all entities in the context.(//entity is an objecte stored into the database).
            public DbSet<Restaurant> Restaurants { get; set; }
        }
    }
}