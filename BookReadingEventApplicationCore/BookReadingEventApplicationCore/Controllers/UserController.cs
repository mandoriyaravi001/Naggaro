using BookReadingEventApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventApplicationCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
      
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Services.Models.User user = new Services.Models.User()
            {
                Email = createUserViewModel.Email,
                FullName = createUserViewModel.FullName,
                Password = createUserViewModel.Password,

            };
            if (userService.Exist(user))
            {
                ModelState.AddModelError("", "Email AllReady Exist");
                return View();
            }
            else
            {
                userService.RegisterUser(user);
                return RedirectToAction("Login", "Login");
            }

        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
