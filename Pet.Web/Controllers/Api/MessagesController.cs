using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet.Web.Controllers.Api
{
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IMessageService messageService;

        public MessagesController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            messageService = new MessageService(unitOfWorkFactory);
        }

        [Route("{conversationId}")]
        [HttpGet]
        public IHttpActionResult GetMessages(Guid conversationId)
        {
            Message[] m = messageService.GetMesagesForConversation(conversationId);
            return Ok(messageService.GetMesagesForConversation(conversationId));
        }

        [HttpPost]
        public IHttpActionResult PostSendMessage(Models.Message message)
        {
            Database.Entities.Message dbMessage = new Database.Entities.Message()
            {
                ID = Guid.NewGuid(),
                Text = message.Text,
                ConversationId = message.ConversationId,
                Read = false,
                SentBy=new Guid(User.Identity.GetUserId())
            };
            messageService.SendMessage(dbMessage);
            return Ok(message);
        }
    }
}
