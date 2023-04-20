using BookReadingEventApplicationCore.Models;
using DataAccessLayer.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookReadingEventApplicationCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly Logger logger;
        public LoginController(IUserService userService )
        {
            this.userService = userService;
            this.logger = Logger.getInstance();
        }




        // GET: LoginController
        public ActionResult Index()
        {
            logger.LogException("Application Started ... !");
            return View();
        }

        // GET: LoginController/Create
        public IActionResult Login()
        {
            logger.LogException("Loggin Page Loaded...!");
            return View("Login");
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel login)
        {
            string logMessage = string.Format("User Want To login Using details:- {0}", JsonSerializer.Serialize(login));
            logger.LogException(logMessage);
            if (!ModelState.IsValid)
            {
                return View();
            }
            Services.Models.User user = new Services.Models.User()
            {
                Email = login.Email,
                Password = login.Password
            };
            if (userService.Login(user))
            {
                var userID = userService.GetUserID(user.Email);
                var roles = userService.GetRole(user.Email);
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetInt32("UserID", userID);
                HttpContext.Session.SetString("Role", roles);
                if (roles.Equals("Admin"))
                {
                    return RedirectToAction("AllEvents", "Home");

                }
                return RedirectToAction("Index","Home");
            }
            else
            {

                ModelState.AddModelError("Password", "Invalid Email address or Password....!!");
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsLoggedIn");
            return RedirectToAction("Index" , "Home");

        }

        
    }
}
