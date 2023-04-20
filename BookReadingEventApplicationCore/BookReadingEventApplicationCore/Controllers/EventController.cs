using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;



namespace BookReadingEventApplicationCore.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IUserService userService;

        public EventController(IEventService eventService , IUserService userService)
        {
            this.eventService = eventService;
            this.userService = userService;
        }

       

        // GET: EventController
        public ActionResult Index()
        {
            var userID = (int)HttpContext.Session.GetInt32("UserID");
            var @event = eventService.GetEvents(userID);
            return View(@event);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            var Type = eventService.EventType();
            var StartTime = eventService.StartTimelist();
            ViewBag.Type = Type;
            ViewBag.StartTime = StartTime;
            return View("Create");
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookReadingEventApplicationCore.Models.CreateEventViewModel createEventViewModel)
        {
            var Type = eventService.EventType();
            var StartTime = eventService.StartTimelist();
            ViewBag.Type = Type;
            ViewBag.StartTime = StartTime;
            var userId = (int)HttpContext.Session.GetInt32("UserID");
            if (!ModelState.IsValid)
            {
                return View();
            }
            // set type public as default
            if (string.IsNullOrEmpty(Convert.ToString(createEventViewModel.Type)))
            {
                createEventViewModel.Type = "Public";
            }
            Services.Models.Event @event = new Services.Models.Event()
            {
                Title = createEventViewModel.Title,
                Date = createEventViewModel.Date,
                Location = createEventViewModel.Location,
                StartTime = createEventViewModel.StartTime,
                DurationInHours = createEventViewModel.DurationInHours,
                Type = createEventViewModel.Type,
                Description = createEventViewModel.Description,
                OtherDetails = createEventViewModel.OtherDetails,
                InviteByEmail = createEventViewModel.InviteByEmail,
                UserID = userId

            };
            if (eventService.IsNotValidEvent(@event))
            {
                ModelState.AddModelError("", "Title AllReady Exist");
                return View();
            }
            else
            {
                eventService.Create(@event);
                ViewBag.Message = "Event created successfully...!";
                return View();

            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            var role = Convert.ToString(HttpContext.Session.GetString("Role"));
            var userID = (int)HttpContext.Session.GetInt32("UserID");

            List<string> Type = eventService.EventType();
            List<string> StartTime = eventService.StartTimelist();

            ViewBag.Type = Type;
            ViewBag.StartTime = StartTime;

            var @event = eventService.GetDetails(id);

            if (@event == null)
            {
                return BadRequest();
            }

            //Is event editable or not
            if (!(eventService.IsValidEdit(id, userID) || userService.IsValidRole(role)))
            {
                return Unauthorized();
            }

            return View(@event);
        }
    

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataAccessLayer.DatabaseModels.Event @event)
        {

            //raw data requred for furtur process or must be initialized
            @event.UserID = id;
            List<string> Type = eventService.EventType();
            List<string> StartTime = eventService.StartTimelist();
            ViewBag.Type = Type;
            ViewBag.StartTime = StartTime;
            var @oldevent = eventService.GetDetails(@event.EventID);


            //Set previous  type
            if (string.IsNullOrEmpty(Convert.ToString(@event.Type)))
            {
                @event.Type = @oldevent.Type;
            }
            //Set previous  Time
            if (string.IsNullOrEmpty(Convert.ToString(@event.StartTime)))
            {
                @event.StartTime = oldevent.StartTime;
            }
            // TODO: Add update logic here
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!eventService.Update(@event))
            {

                ModelState.AddModelError("Title", "Unable to save changes. Maybe event already exists...!");
                return View(@event);
            }
            else
            {

                ViewBag.Message = "Updated Successfully..!";
                return View(@event);
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            var @event = eventService.GetDetails(id);
            if (@event == null)
            {
                return BadRequest();
            }
            return View(@event);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id , BookReadingEventApplicationCore.Models.DisplayEventViewModel @event)
        {
            try
            {
                eventService.Delete(id);
                return RedirectToAction("AllEvents", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: All Event where user is invited
        public ActionResult EventsInvitedTo()
        {
            var userID = (int)HttpContext.Session.GetInt32("UserID");
            var @event = eventService.EventInvitedTo(userID);
            return View(@event);
        }
    }
}
