using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Interface.User
{
    public interface IUserService
    {
       List<ApplicationUser> getListUser();
       ApplicationUser getUser(string Id);
       List<IdentityRole> getListRoles();
       String getRole(ApplicationUser users);
       
    }
}
