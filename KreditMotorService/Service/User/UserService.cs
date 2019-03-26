using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Service.User
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _user;
        public UserService(DataContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;

        }

      
        public List<ApplicationUser> getListUser()
        {
            var model = _context.users.ToList();
            return model;
        }

        public List<IdentityRole> getListRoles()
        {
            var model = _context.Roles.ToList();
            return model;
        }

        public ApplicationUser getUser(string Id)
        {
            var model = _context.users.Find(Id);
            return model;

        }

        public String getRole(ApplicationUser users)
        {
            String result;
            var model =  _user.GetRolesAsync(users);
            if (model.Result.Count != 0)
                result = model.Result.First();
            else
                result = null;


            return result;
        }
    }
}
