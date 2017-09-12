using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class OdeToFoodDb: DbContext
    {

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<ResturantReview> Reviews { get; set; }


    }
}