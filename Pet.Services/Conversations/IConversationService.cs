using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Services.Conversations
{
    public interface IConversationService
    {
        Conversation GetConversationBeetwen(Guid userId, Guid petId);
        Conversation GetById(Guid id);
        Conversation[] GetAllForUser(Guid userId);
    }
}
