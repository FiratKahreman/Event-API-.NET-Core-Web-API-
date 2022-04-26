using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task2_FiratKahreman.Models
{
    public class Category
    {
        [Key]
        public string CategoryName { get; set; }

        public List<Activity> CategoryActivities { get; set; }
    }
}
