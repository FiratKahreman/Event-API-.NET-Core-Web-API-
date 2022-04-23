using System;

namespace task2_FiratKahreman.Models
{
    public class Activity
    {
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Adress { get; set; }
        public int Limit { get; set; }
        public bool NeedTicket { get; set; }
        public int? TicketPrice { get; set; }
        public string City { get; set; } //!!!!

    }
}
