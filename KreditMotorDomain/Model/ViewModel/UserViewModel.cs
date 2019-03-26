using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorDomain.Model.ViewModel
{
    public class UserViewModel
    {
        public List<ApplicationUser> listUser { get; set; }
        public ApplicationUser getUser { get; set; }
        public List<IdentityRole> listRole { get; set; }
        public String getUserRole { get; set; }
       
    }
}
