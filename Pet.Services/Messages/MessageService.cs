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


        public Message[] GetMesagesBetween(Guid user1, Guid user2)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetMessagesBetweenUsers(user1, user2);
            }
        }

        public void SendMessage(Message message)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.MessageRepository.Create(message);
            }
        }
    }
}
