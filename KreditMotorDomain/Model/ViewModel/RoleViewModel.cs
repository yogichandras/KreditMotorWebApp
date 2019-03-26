using KreditMotorDomain.Model.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorDomain.Model.ViewModel
{
   public class RoleViewModel
    {
       public List<IdentityRole> role { get; set; }
    }
}
