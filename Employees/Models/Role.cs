using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation property
        public List<User> Users { get; set; }
    }
}
