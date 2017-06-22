using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public MessageService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Message[] GetAll()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAll();
            }
        }

        public Message[] GetAllMessages(Guid userId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAllMessagesForUser(userId);
            }
        }

        public List<Message[]> GetAllMessagesForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Message[] GetMesagesBetween(Guid user1, Guid user2)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetMessagesBetweenUsers(user1, user2);
            }
        }
        /////////
        public Message[] GetMesagesForConversation(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAllForConversation(id);
            }
        }
        /////////
        public Message[] GetMessegesBetwenForPet(Guid to, Guid from, Guid pet)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                Message[] m1=unitOfWork.MessageRepository.GetMessegesBetweenUsersForPet(to, from, pet);
                Message[] m2 = unitOfWork.MessageRepository.GetMessegesBetweenUsersForPet(from, to, pet);
                Message[] r = m1.Concat(m2).OrderBy(m => m.SentDate).ToArray();
                return r;
            }
        }

        public void SendMessage(Message message)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.MessageRepository.Create(message);
                unitOfWork.Save();
            }
        }
    }
}
