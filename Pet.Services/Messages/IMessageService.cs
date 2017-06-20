using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Services.Messages
{
    public interface IMessageService
    {
        Message[] GetMesagesBetween(Guid user1, Guid user2);
        void SendMessage(Message message);
        Message[] GetAll();
        Message[] GetMessegesBetwenForPet(Guid to, Guid from, Guid pet);
        List<Message[]> GetAllMessagesForUser(Guid userId);
        Message[] GetAllMessages(Guid userId);
    }
}
