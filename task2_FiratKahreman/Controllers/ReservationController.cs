using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2_FiratKahreman.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using task2_FiratKahreman.DTOs;
using System;
using Microsoft.AspNetCore.Authorization;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Attend(int eventId, int userId)
        {
            using (var context = new EventContext())
            {
                var activity = context.Activities.Where(q => q.ActivityId == eventId).Include(b => b.AttendedUsers).First();

                if (activity.AttendedUsers.Count() < activity.Limit)
                {
                    User attendedUser = context.Users.First(a => a.UserId == userId);
                    activity.AttendedUsers.Add(attendedUser);

                    if (activity.NeedTicket)
                    {
                        List<TicketSellerDTO> ticketSellers = (from a in context.Activities
                                                               join b in context.Companies on a.CompanyId equals b.CompanyId
                                                               where a.ActivityId == eventId

                                                               select new TicketSellerDTO
                                                               {
                                                                   ActivityId = a.ActivityId,
                                                                   TicketSeller = b.CompanyName,
                                                                   TicketSellerWeb = b.CompanyWeb
                                                               }).ToList();
                        context.SaveChanges();
                        return Ok(ticketSellers);
                    }
                    else
                    {
                        context.SaveChanges();
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest("Maalesef etkinlik kontenjanı dolmuştur.");
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CancelAttend(int eventId, int userId)
        {
            using (var context = new EventContext())
            {
                var activity = context.Activities
                    .Where(q => q.ActivityId == eventId && q.ActivityDate >= DateTime.Now.AddDays(2))
                    .Include(b => b.AttendedUsers)
                    .FirstOrDefault();
                User attendedUser = context.Users.First(a => a.UserId == userId);

                if(activity == null)
                {
                    return BadRequest("Etkinliğin başlamasına 2 günden az süre kalmış veya bu kullanıcı bu etkinliğe kaydolmamış.");
                }

                if (activity.NeedTicket && activity != null)
                {
                    activity.AttendedUsers.Remove(attendedUser);
                    context.SaveChanges();
                    List<TicketSellerDTO> ticketSellers = (from a in context.Activities
                                                           join b in context.Companies on a.CompanyId equals b.CompanyId
                                                           where a.ActivityId == eventId

                                                           select new TicketSellerDTO
                                                           {
                                                               ActivityId = a.ActivityId,
                                                               TicketSeller = b.CompanyName,
                                                               TicketSellerWeb = b.CompanyWeb
                                                           }).ToList();
                    return Ok(ticketSellers);
                }
                else
                {
                    activity.AttendedUsers.Remove(attendedUser);
                    context.SaveChanges();
                    return Ok();
                }
                
            }         
        }

        

        //Katıldıklarını, katılmadıklarını, iptal edilenleri gör


    }
}
