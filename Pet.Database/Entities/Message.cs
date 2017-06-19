using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Message:IEntity
    {
        public string Text { get; set; }

        public Guid ID { get; set; }

        public Guid From { get; set; }

        public Guid To { get; set; }

        public Guid PetID { get; set; }

        public DateTime SentDate { get; set; }

        public bool Read { get; set; }
    }
}


