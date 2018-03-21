using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Core.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}