using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spark.Models.Note;

namespace SparkClientManager.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var model = new NoteListItem[0];
            return View(model);
        }
    }
}