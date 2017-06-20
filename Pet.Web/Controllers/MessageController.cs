using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Database.Entities;
using Pet.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class MessageController : Controller
    {

        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IMessageService messageService;

        public MessageController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            messageService = new MessageService(unitOfWorkFactory);
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllMessages()
        {
            /*
             * currently shows all messages as one chat
             */
            Message[] allMessages = messageService.GetAllMessages(new Guid(User.Identity.GetUserId()));
            return View(allMessages);
        }

        public ActionResult List(Guid ownerId,Guid petId)
        {
            Message[] messeges = messageService.GetMessegesBetwenForPet(ownerId, new Guid(User.Identity.GetUserId()), petId);
            return View(messeges);
        }
        
        // GET: Message/Create
        public ActionResult Create(Guid ownerId,Guid petId)
        {
            Message message = new Message();
            //message.ID = Guid.NewGuid();
            message.PetId = petId;
            message.ToId = ownerId;
            message.FromId = new Guid(User.Identity.GetUserId());
            return View(message);
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Message message)
        {
            try
            {
                message.ID = Guid.NewGuid();
                message.SentDate = DateTime.Now;
                message.FromId = new Guid(User.Identity.GetUserId());
                
                messageService.SendMessage(message);
                
                return RedirectToAction("List",new { ownerId=message.ToId, petID=message.PetId });
            }
            catch
            {
                return View();
            }
        }
    }
}
