using System;
using System.Collections.Generic;

namespace task2_FiratKahreman.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Adress { get; set; }
        public int Limit { get; set; }
        public int Booked { get; set; }
        public bool NeedTicket { get; set; }
        public int CompanyId { get; set; }
        public int? TicketPrice { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public Category Category { get; set; }
        public List<User> AttendedUsers { get; set; }
        public List<Company> SellerCompanies { get; set; }
        
    }
}
