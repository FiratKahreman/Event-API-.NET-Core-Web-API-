using System;

namespace task2_FiratKahreman.DTOs
{
    public class ActivityOutputDTO
    {
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Adress { get; set; }
        public int Limit { get; set; }
        public bool NeedTicket { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
    }
}
