using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.Conversations;
using System;
using System.Web.Http;

namespace Pet.Web.Controllers.Api
{
    [RoutePrefix("api/conversations")]
    public class ConversationsController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IConversationService conversationService;

        public ConversationsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            conversationService = new ConversationService(unitOfWorkFactory);
        }

        [HttpGet]
        public IHttpActionResult GetConversation(Guid id)
        {
            return Ok(conversationService.GetById(id));
        }


        [Route("userpet")]
        [HttpGet]
        public IHttpActionResult GetConversationBetween(Guid userId,Guid petId)
        {
            return Ok(conversationService.GetConversationBeetwen(userId, petId));
        }

        [Route("user")]
        [HttpGet]
        public IHttpActionResult GetConversationsFor()
        {
            return Ok(conversationService.GetAllForUser(new Guid(User.Identity.GetUserId())));
        }
    }
}
