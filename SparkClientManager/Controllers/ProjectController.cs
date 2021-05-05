using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Spark.Models.Project;
using Spark.Services;

namespace SparkClientManager.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            ProjectService service = CreateProjectService();

            var model = service.GetProjects();

            return View(model);
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateProjectService();
            var model = service.GetProjectById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    Title = detail.Title,
                    UserIds = detail.UserIds
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project could not be updated.");
            return View(model);
        }

        private ProjectService CreateProjectService()
        {
            var userId = User.Identity.GetUserId();
            var service = new ProjectService(userId);
            return service;
        }
    }
}