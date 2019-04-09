using KreditMotorDomain.Model.Pelanggan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Interface.Pelanggan
{
   public interface IPelangganService
    {
        Task<List<ModelPelanggan>> getListPelanggan();
        Task<bool> createPelanggan(ModelPelanggan model);
        Task<bool> editPelanggan(EditPelanggan model);
        Task<bool> deletePelanggan(int id);
        Task<ModelPelanggan> getEditPelanggan(int id);
    }
}
