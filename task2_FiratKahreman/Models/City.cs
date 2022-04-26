using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task2_FiratKahreman.Models
{
    public class City
    {
        [Key]
        public string CityName { get; set; }

        public List<Activity> CityActivities { get; set; }
    }
}
