using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoForm.DataAccess;
using AdoForm.Models;

namespace AdoForm.Controllers
{
    //[Route("Home/{action}")]
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        // Can't test due to sql connection
        [HttpGet]
        public ActionResult GetUsers()
        {
            DataAccessLayer objDB = new DataAccessLayer(); //calling data layer

            List<User> userList = objDB.GetAllUsers();
            if (userList == null | userList.Count < 1) return RedirectToAction("Index");
            return View("Index", userList);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewData["Title"] = "CreateUser";
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User userObj)
        {
            if (ModelState.IsValid) // Checking model is valid or not

            {

                DataAccessLayer objDB = new DataAccessLayer();

                string result = objDB.InsertUser(userObj);

                ViewData["result"] = result;

                ModelState.Clear(); // Clearing model

                return View();
                //return RedirectToAction("Index");

            }

            else

            {

                ModelState.AddModelError("", "Error in saving data");

                return View();
            }
        }
    }
}