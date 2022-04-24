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
        public string Role { get; set; } //!!!

        public List<Activity> Activities { get; set; }
    }
}
