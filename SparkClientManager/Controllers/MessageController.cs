using Microsoft.AspNet.Identity;
using Spark.Models.Message;
using Spark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkClientManager.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            MessageService service = CreateMessageService();

            var model = service.GetMessages();

            return View(model);
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Message could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateMessageService();
            var model = service.GetMessageById(id);

            return View(model);
        }

        private MessageService CreateMessageService()
        {
            var userId = User.Identity.GetUserId();
            var service = new MessageService(userId);
            return service;
        }
    }
}