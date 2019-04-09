using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using KreditMotorDomain.Model.User.ManageViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Interface.User
{
    public interface IUserService
    {
        #region User
        Task<List<ReadUserModel>> getListUserAdmin();
        ApplicationUser getUser(string Id);
        Task<bool> addUser(CreateUserModel model);
        Task<bool> deleteUser(string Id);
        EditUserModel getEditUser(string Id);
        Task<bool> editUser(CreateUserModel user);

        Task<List<ReadUserModel>> getListUserKasir();

        Task<List<ReadUserModel>> getListUserCso();
        Task<List<ReadUserModel>> getListUserSales();
        #endregion

        #region Role
        List<IdentityRole> getListRoles();
        String getRole(ApplicationUser users);
        Task<bool> setRole(EditUserRoleModel user);
        #endregion
    }
}
