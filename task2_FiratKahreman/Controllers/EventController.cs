using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using task2_FiratKahreman.DTOs;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetEvents()
        {
            using (var context = new EventContext())
            {
                List<ActivityDTO> activities = context.Activities
                    .Where(a => a.IsActive == true)
                    .Select(c => new ActivityDTO()
                    {
                        ActivityId = c.ActivityId,
                        ActivityDate = c.ActivityDate,
                        ActivityName = c.ActivityName,
                        Description = c.Description,
                        Adress = c.Adress,
                        Limit = c.Limit,
                        NeedTicket = c.NeedTicket,
                        TicketPrice = c.TicketPrice
                    }).ToList();
                return Ok(activities);
            }
        }        

        [HttpGet]
        [Route("~/api/events/filter/city/{cityName}")]
        [Authorize(Roles = "User")]
        public IActionResult GetEventsByCity(string cityName)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CityName == cityName select c).ToList();
                return Ok(query);
            }
        }

        [HttpGet]
        [Route("~/api/events/filter/category/{categoryName}")]  //deneysel
        [Authorize(Roles = "User")]
        public IActionResult GetEventsByCategory(string categoryName)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CategoryName == categoryName select c).ToList();
                return Ok(query);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public IActionResult AddEvent(Activity activity)
        {
            using (var context = new EventContext())
            {
                context.Activities.Add(activity);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public IActionResult CancelEvent(int eventId, bool isActive)
        {
            using (var context = new EventContext())
            {
                var query = context.Activities
                    .Where(q => q.ActivityId == eventId && q.ActivityDate >= DateTime.Now.AddDays(5))
                    .FirstOrDefault();
                if (query != null)
                {
                    Activity activity = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);
                    activity.IsActive = isActive;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Bu id değerine sahip bir etkinlik yok veya etkinliğin başlamasına 5 günden az kaldı.");
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public IActionResult EditLimit(int eventId, int newLimit)
        {
            using (var context = new EventContext())
            {
                var query = context.Activities
                    .Where(q => q.ActivityId == eventId && q.ActivityDate >= DateTime.Now.AddDays(5))
                    .FirstOrDefault();
                if (query != null)
                {
                    Activity activity = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);
                    activity.Limit = newLimit;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Bu id değerine sahip bir etkinlik yok veya etkinliğin başlamasına 5 günden az kaldı.");
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public IActionResult EditAdress(int eventId, string newAdress)
        {
            using (var context = new EventContext())
            {
                var query = context.Activities
                    .Where(q => q.ActivityId == eventId && q.ActivityDate >= DateTime.Now.AddDays(5))
                    .FirstOrDefault();
                if (query != null)
                {
                    Activity activity = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);
                    activity.Adress = newAdress;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Bu id değerine sahip bir etkinlik yok veya etkinliğin başlamasına 5 günden az kaldı.");
                }
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Company")]
        public IActionResult GetEventsByCompanyId(int id)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CompanyId == id select c).ToList();
                return Ok(query);
            }
        }

        [HttpGet("output.{format}"),FormatFilter]
        [Authorize(Roles = "Company")]
        public IActionResult EventFormat()
        {
            using (var context = new EventContext())
            {
                List<ActivityOutputDTO> events = context.Activities
                    .Select(c => new ActivityOutputDTO()
                    {
                        ActivityName = c.ActivityName,
                        Description = c.Description,
                        ActivityDate = c.ActivityDate,
                        Adress = c.Adress,
                        Limit = c.Limit,
                        NeedTicket = c.NeedTicket,
                        CategoryName = c.CategoryName,
                        CityName = c.CityName
                    }).ToList();
                return Ok(events);

            }
        }

        
    }
}
