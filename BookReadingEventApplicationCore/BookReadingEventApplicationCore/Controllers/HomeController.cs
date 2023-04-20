using BookReadingEventApplicationCore.Models;
using DataAccessLayer.DatabaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventApplicationCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventDataContext db;
       

        public HomeController(ILogger<HomeController> logger , EventDataContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var @events = from e in db.Event
                          where e.Type == "Public"
                          select e;
            return View(@events);
        }
        public ActionResult AllEvents()
        {
            var @event = from e in db.Event
                        select e;
            //var students = _unitofWork.EventService.GetEvents();
            return View(@event);
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Book Reading Event Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var @event = db.Event.Find(id);
            var @comment = (from c in db.Comment
                           where c.EventID == @event.EventID
                           select c).ToList();
           /* Collection<Comment> collection = new Collection<Comment>();

            for (int i = 0; i < @comment.Length; i++)
            {
                collection.Add(@comment[i]);
            }
           */
          

            if (@event == null)
            {
                return NotFound();
            }
            
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session.GetString("IsLoggedIn"))))
            {
                if (@event.Type.ToString().Equals("Private"))
                {
                    return Unauthorized();
                }
            }
            else
            {
                var userId = (int)HttpContext.Session.GetInt32("UserID");
                var role = Convert.ToString(HttpContext.Session.GetString("Role"));
                if (!role.Equals("Admin") && @event.Type.ToString().Equals("Private") && !@event.UserID.ToString().Equals(userId))
                {
                    return Unauthorized();
                }
            }

            var countOfEmail = 0;
            var invitedByEmail = @event.InviteByEmail;
            if (invitedByEmail != null)
            {
                countOfEmail = invitedByEmail.Split(',').Length;
            }
            DisplayEventViewModel displayEventViewModel = new DisplayEventViewModel()
            {
                EventID = @event.EventID,
                Title = @event.Title,
                Date = @event.Date,
                Description = @event.Description,
                DurationInHours = @event.DurationInHours,
                Location = @event.Location,
                OtherDetails = @event.OtherDetails,
                StartTime = @event.StartTime,
                TotalInvitedToEvent = countOfEmail,
                Comments = @comment,

            };
            return View("Details", displayEventViewModel);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
