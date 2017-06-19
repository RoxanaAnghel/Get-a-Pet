using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Message:IEntity
    {
        public Guid ID { get; set; }

        public Guid From { get; set; }

        public Guid To { get; set; }

        public DateTime Sent { get; set; }

        public bool Read { get; set; }
    }
}
