using Spark.Models.Message;
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
            var model = new MessageListItem[0];
            return View(model);
        }
    }
}