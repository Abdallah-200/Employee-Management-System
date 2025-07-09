using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class RoleVM
    {
        
        public string Id { get; set; }

        [Required(ErrorMessage ="Enter Role Name ")]
        public string RoleName { get; set; }
    }
}
