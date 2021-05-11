using Spark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkClientManager.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var service = new UserService();

            var model = service.GetUsers();

            return View(model);
        }

    }
}