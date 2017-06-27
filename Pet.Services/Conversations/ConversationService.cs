using Pet.Database;
using Pet.Database.Entities;
using System;
using System.Linq;

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
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ConversationRepository.GetAllFor(userId).Select(x => new Conversation()
                {
                    FromID = x.FromID,
                    FromUserImagineUrl = x.FromUserImagineUrl,
                    ID = x.ID,
                    PetID = x.PetID,
                    PetImagineUrl = x.PetImagineUrl,
                    PetOwnerId = x.PetOwnerId,
                    PetOwnerImagineUrl = x.PetOwnerImagineUrl,
                    Status = x.Status
                }).ToArray();
            }
        }

        public Database.Entities.Conversation GetById(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.ConversationRepository.GetByID(id);
            }
        }

        public Database.Entities.Conversation GetConversationBeetwen(Guid userId, Guid petId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                if (!unitOfWork.ConversationRepository.ExistsBetween(userId, petId))
                {
                    Database.Entities.Pet pet = unitOfWork.PetRepository.GetByID(petId);
                    UserDetails petOwner = unitOfWork.UserDetailsRepository.GetByID(pet.OwnerID);
                    UserDetails user = unitOfWork.UserDetailsRepository.GetByID(userId);
                    Database.Entities.Conversation conversation = new Database.Entities.Conversation() { ID = Guid.NewGuid(), PetID = petId, PetOwnerId = pet.OwnerID, PetImagineUrl = pet.ImageUrl, FromID = userId };
                    unitOfWork.ConversationRepository.Create(conversation);
                    unitOfWork.Save();
                    return conversation;
                }
                return unitOfWork.ConversationRepository.GetConversationBetween(userId, petId);
            }
        }
    }
}