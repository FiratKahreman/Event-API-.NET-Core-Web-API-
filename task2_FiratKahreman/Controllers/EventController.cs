﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            EventContext context = new EventContext();
            List<ActivityDTO> activities = context.Activities
                .Select(c => new ActivityDTO()
                {
                    ActivityId = c.ActivityId,
                    ActivityDate = c.ActivityDate,
                    ActivityName = c.ActivityName,
                    Description = c.Description,
                    LastDate = c.LastDate,
                    Adress = c.Adress,
                    Limit = c.Limit,
                    NeedTicket = c.NeedTicket,
                    TicketPrice = c.TicketPrice
                }).ToList();
            return Ok(activities);
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
       
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult GetListByCity(int cityId)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CityId == cityId select c).ToList();
                return Ok(query);
            }
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult GetListByCategory(int categoryId)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CategoryId == categoryId select c).ToList();
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
        public IActionResult CancelEvent(int eventId)
        {
            using (var context = new EventContext())
            {                
                var query = (from c in context.Activities where c.ActivityId == eventId && c.ActivityDate >= DateTime.Now.AddDays(5) select c);
                
                if (query != null)
                {
                    Activity activity = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);
                    context.Activities.Remove(activity);
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
        public IActionResult EditLimit(int eventId, Activity activity)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.ActivityId == eventId && c.ActivityDate >= DateTime.Now.AddDays(5) select c);
                if (query != null)
                {
                    Activity original = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);                    
                    original.Limit = activity.Limit;
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
        public IActionResult EditAdress(int eventId, Activity activity)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.ActivityId == eventId && c.ActivityDate <= DateTime.Now.AddDays(-5) select c);
                if (query != null)
                {
                    Activity original = context.Activities.SingleOrDefault(a => a.ActivityId == eventId);
                    original.Adress = activity.Adress;
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Bu id değerine sahip bir etkinlik yok veya etkinliğin başlamasına 5 günden az kaldı.");
                }
            }
        }

        //Firmalar xml json çekebilir (log kaydı al)


    }
}