using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Employees.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        // Navigation property
        public Role Role { get; set; }

        // Navigation property
        public UserProfile UserProfile { get; set; }
    }

}
