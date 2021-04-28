using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Spark.Models.Note;
using Spark.Services;

namespace SparkClientManager.Controllers
{
    public class NoteController : Controller
    {
        //// GET: Note
        //public ActionResult Index()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var service = new NoteService(userId);
        //    var model = service.GetNotes();

        //    return View(model);
        //}

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        private NoteService CreateNoteService()
        {
            var userId = User.Identity.GetUserId();
            var service = new NoteService(userId);
            return service;
        }
    }
}