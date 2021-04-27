using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spark.Models.Project;

namespace SparkClientManager.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var model = new ProjectListItem[0];
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}