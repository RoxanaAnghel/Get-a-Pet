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
            Guid current = new Guid(User.Identity.GetUserId());
            return Ok(conversationService.GetById_(id,current));
        }


        [Route("{petId}")]
        [HttpGet]
        public IHttpActionResult GetConversationBetween(Guid petId)
        {
            return Ok(conversationService.GetConversationBeetwen(new Guid(User.Identity.GetUserId()),petId));
        }

        [Route("user")]
        [HttpGet]
        public IHttpActionResult GetConversationsFor()
        {
            return Ok(conversationService.GetAllForUser(new Guid(User.Identity.GetUserId())));
        }
    }
}
