using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class ResturantReview
    {

        public int Id { get; set; }
        public int  Rating { get; set; }
        public string  Body { get; set; }
        public string ReviewerName { get; set; }
        public int ResturantId { get; set; }


    }
}