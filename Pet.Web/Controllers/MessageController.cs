using Microsoft.AspNet.Identity;
using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class MessageController : Controller
    {

        public MessageController()
        {

        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: Message/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Message/Create
        public ActionResult Create(Guid ownerId,Guid petId)
        {
            return View();
        }

        // POST: Message/Create
        //[HttpPost]
        //public ActionResult Create(Message message)
        //{
        //    try
        //    {
        //        message.ID = new Guid();
        //        message.From=new Guid(User.Identity.GetUserId());
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Message/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Message/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Message/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Message/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
