using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet.Web.Models
{
    public class Pet
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }
    }
}