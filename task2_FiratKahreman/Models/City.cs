using System.Collections.Generic;

namespace task2_FiratKahreman.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<Activity> CityActivities { get; set; }
    }
}
