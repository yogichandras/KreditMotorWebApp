using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.Pagination;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Interface.Motor
{
   public interface IMotorService
    {
        PaginatedList<ModelMotor> getMotor(int? pageIndex,string search);
        Task<bool> createMotor(ModelMotor motor, IFormFile picture);
        Task<bool> editMotor(ModelMotor motor, IFormFile picture);
        bool deleteMotor(string id);
        ModelMotor editMotor(string id);

        bool bookMotor(ViewModelMotor model);
    }
}
