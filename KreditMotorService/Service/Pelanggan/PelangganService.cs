using KreditMotorDomain.Model.Pelanggan;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Pelanggan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KreditMotorService.Service.Pelanggan
{
    public class PelangganService : IPelangganService
    {
        private readonly DataContext _context;
        public PelangganService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> createPelanggan(ModelPelanggan model)
        {
            await _context.AddAsync(model);
            var result = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deletePelanggan(int id)
        {
            var pelanggan = await _context.pelanggan.FindAsync(id);
             _context.pelanggan.Remove(pelanggan);
             _context.SaveChanges();
            return true;
        }

        public async Task<bool> editPelanggan(EditPelanggan model)
        {
            var pelanggan = await _context.pelanggan.FindAsync(model.edit_kd_pelanggan);
            pelanggan.alamat = model.edit_alamat;
            pelanggan.nama_pelanggan = model.edit_nama_pelanggan;
            pelanggan.no_ktp = model.edit_no_ktp;
            pelanggan.pekerjaan = model.edit_pekerjaan;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ModelPelanggan> getEditPelanggan(int id)
        {
            var model = await _context.pelanggan.FindAsync(id);
            return model;
        }

        public async Task<List<ModelPelanggan>> getListPelanggan()
        {
            var model = await _context.pelanggan.ToListAsync();
            return model;
        }
    }
}
