using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.Conversations
{
    public class ConversationService : IConversationService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ConversationService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Conversation[] GetAllForUser(Guid userId)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ConversationRepository.GetAllFor(userId);
            }
        }

        public Conversation GetById(Guid id)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ConversationRepository.GetByID(id);
            }
        }

        public Conversation GetConversationBeetwen(Guid userId, Guid petId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if (!unitOfWork.ConversationRepository.ExistsBetween(userId, petId))
                {
                    Database.Entities.Pet pet = unitOfWork.PetRepository.GetByID(petId);
                    UserDetails petOwner = unitOfWork.UserDetailsRepository.GetByID(pet.OwnerID);
                    UserDetails user = unitOfWork.UserDetailsRepository.GetByID(userId);
                    Conversation conversation = new Conversation() { ID = Guid.NewGuid(), PetID = petId, PetOwnerId = pet.OwnerID, PetImagineUrl = pet.ImageUrl ,FromID=userId};
                    unitOfWork.ConversationRepository.Create(conversation);
                    unitOfWork.Save();
                    return conversation;
                }
                return unitOfWork.ConversationRepository.GetConversationBetween(userId, petId);
            }
        }
    }
}
