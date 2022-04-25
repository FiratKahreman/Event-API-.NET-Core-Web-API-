using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task2_FiratKahreman.Models
{
    public class Role
    {        
        public string RoleId { get; set; }

        public List<User> RoleUsers { get; set; }
    }
}
