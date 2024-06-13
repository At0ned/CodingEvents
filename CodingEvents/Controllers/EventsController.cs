using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEventsDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
    
    private EventDbContext context; 

    public EventsController(EventDbContext dbContext)
    {
        context = dbContext;
    }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> Events = context.Events.ToList();
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }


        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            context.Events.Add(newEvent);
            context.SaveChanges();

            return Redirect("/Events");
        }

        public IActionResult Delete()
         {
            ViewBag.events = context.Events.ToList();

            return View();
         }

        [HttpPost]
          public IActionResult Delete(int[] eventIds)
         {
            foreach (int eventId in eventIds)
            {
                Event? theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }
                context.SaveChanges();

            return Redirect("/Events");
        }
    }
}