using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkStart.Core.ViewModels
{
    public class RoleViewModel
    {
        public IdentityRole Role { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}