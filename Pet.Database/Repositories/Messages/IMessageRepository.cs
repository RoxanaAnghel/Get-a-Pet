using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories.Messages
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
        Message[] GetMessagesForUser(Guid ForUser);
    }
}
