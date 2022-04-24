using System.Collections.Generic;

namespace task2_FiratKahreman.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWeb { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyPassword { get; set; }
        public string CompanyRePassword { get; set; }

        public List<Activity> CompanyActivities { get; set; }
    }
}
