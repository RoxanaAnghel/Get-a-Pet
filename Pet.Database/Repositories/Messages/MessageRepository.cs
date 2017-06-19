using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pet.Database.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(PetDataContext context, UnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public Message[] GetMessagesBetweenUsers(Guid user1, Guid user2)
        {
            return dbSet.Where(m => (m.From == user1 && m.To==user2)).OrderBy(m => m.SentDate).ToArray();
        }

        public Message[] GetMessagesForUser(Guid ForUser)
        {
            return dbSet.Where(m => m.To == ForUser).OrderBy(m=>m.SentDate).ToArray();
        }
    }
}
