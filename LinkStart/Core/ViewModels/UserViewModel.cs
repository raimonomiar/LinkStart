using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using LinkStart.Core.Models;

namespace LinkStart.Core.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}