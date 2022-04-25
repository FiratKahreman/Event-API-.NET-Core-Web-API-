using System.Collections.Generic;

namespace task2_FiratKahreman.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Activity> CategoryActivities { get; set; }
    }
}
