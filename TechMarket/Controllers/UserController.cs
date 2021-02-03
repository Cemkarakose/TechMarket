using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechMarket.DAL;
using TechMarket.Models;

namespace TechMarket.Controllers
{
    
    public class UserController : Controller
    {
        private StoreContext db = new StoreContext();
        // GET: User
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            var users = db.Users;
            return View(users);
        }
    }
}