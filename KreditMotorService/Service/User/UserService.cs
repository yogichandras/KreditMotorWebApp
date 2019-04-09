using KreditMotorDomain.Model.Petugas;
using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using KreditMotorDomain.Model.User.ManageViewModels;
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
        private readonly RoleManager<IdentityRole> _role;
        public UserService(DataContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;

        }


        #region User

        public async Task<List<ReadUserModel>> getListUserAdmin()
        {
            var model = await _user.GetUsersInRoleAsync("Admin");
            var parse = new List<ReadUserModel>();
           
            foreach (var item in model)
            {
                var newModel = new ReadUserModel
                {
                    Id = item.Id,
                    Email= item.Email,
                    Username = item.UserName
                };
                parse.Add(newModel);

            }
           
            return parse;
        }

       
        public ApplicationUser getUser(string Id)
        {
            var model = _context.users.Find(Id);

            return model;

        }

     
        public async Task<bool> addUser(CreateUserModel model)
        {
            var modelPetugas = new ModelPetugas()
            {
                nama = model.Nama,
                bagian = model.Bagian,
                keterangan = model.Keterangan
            };
            
            _context.petugas.Add(modelPetugas);
            _context.SaveChanges();

           
            var modelUser = new ApplicationUser()
            {
                UserName = model.Username,
                kd_petugas = modelPetugas.kd_petugas,
            };

            var result = await _user.CreateAsync(modelUser, model.Password);


            if (result.Succeeded)
            {
                var user = await _user.FindByNameAsync(model.Username);
                await _user.AddToRoleAsync(user, model.Status);
                return true;
            }
            else
                return false;
            
        }

        public async Task<bool> deleteUser(string Id)
        {
            var user = await _user.FindByIdAsync(Id);
            var delAccount = await _user.DeleteAsync(user);
            if (delAccount.Succeeded) {
                var petugas = _context.petugas.Find(user.kd_petugas);
                _context.petugas.Remove(petugas);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public EditUserModel getEditUser(string Id)
        {
            var model = _context.users.Find(Id);
            var modelPetugas = _context.petugas.Find(model.kd_petugas);
            var result = new EditUserModel
            {
                Id = Id,
                Bagian = modelPetugas.bagian,
                Keterangan = modelPetugas.keterangan,
                Nama = modelPetugas.nama,
                Username = model.UserName
            };

            return result;

        }

        public async Task<bool> editUser(CreateUserModel user)
        {
            var model = _context.users.Find(user.edituser.Id);
            var modelPetugas = _context.petugas.Find(model.kd_petugas);
            modelPetugas.nama = user.edituser.Nama;
            modelPetugas.bagian = user.edituser.Bagian;
            modelPetugas.keterangan = user.edituser.Keterangan;
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<List<ReadUserModel>> getListUserKasir()
        {
            var model = await _user.GetUsersInRoleAsync("Kasir");
            var parse = new List<ReadUserModel>();

            foreach (var item in model)
            {
                var newModel = new ReadUserModel
                {
                    Id = item.Id,
                    Email = item.Email,
                    Username = item.UserName
                };
                parse.Add(newModel);

            }

            return parse;
        }


        public async Task<List<ReadUserModel>> getListUserCso()
        {
            var model = await _user.GetUsersInRoleAsync("Cso");
            var parse = new List<ReadUserModel>();

            foreach (var item in model)
            {
                var newModel = new ReadUserModel
                {
                    Id = item.Id,
                    Email = item.Email,
                    Username = item.UserName
                };
                parse.Add(newModel);

            }

            return parse;
        }

        public async Task<List<ReadUserModel>> getListUserSales()
        {
            var model = await _user.GetUsersInRoleAsync("Sales");
            var parse = new List<ReadUserModel>();

            foreach (var item in model)
            {
                var newModel = new ReadUserModel
                {
                    Id = item.Id,
                    Email = item.Email,
                    Username = item.UserName
                };
                parse.Add(newModel);

            }

            return parse;
        }

        #endregion


        #region Role
        public String getRole(ApplicationUser users)
        {
            String result;
            var model = _user.GetRolesAsync(users);
            if (model.Result.Count != 0)
                result = model.Result.First();
            else
                result = null;


            return result;
        }

        public async Task<bool> setRole(EditUserRoleModel user)
        {
            var modelUser = getUser(user.UserId);
            var modelUserRole = getRole(modelUser);

            if (modelUserRole != null)
            {
                var delete = await _user.RemoveFromRoleAsync(modelUser, modelUserRole);
            }

            var result = await _user.AddToRoleAsync(modelUser, user.Roles);

            if (result.Succeeded)
                return true;
            else
                return false;
        }

        public List<IdentityRole> getListRoles()
        {
            var model = _context.Roles.ToList();
            return model;
        }

      

        #endregion
    }
}
