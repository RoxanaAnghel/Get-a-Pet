using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Pet:IEntity
    {
        public Guid ID { get; set; }

        //[ForeignKey]
        //For the user that owns the pet post
        public Guid OwnerID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

    }
}
