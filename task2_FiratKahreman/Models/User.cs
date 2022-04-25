using System.Collections.Generic;

namespace task2_FiratKahreman.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsOrganizer { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }

        public List<Activity> AttendedActivities { get; set; }
    }
}
