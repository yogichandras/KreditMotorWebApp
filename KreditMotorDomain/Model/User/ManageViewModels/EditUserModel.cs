using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorDomain.Model.User.ManageViewModels
{
    public class EditUserModel
    {
        
        public string Id { get; set; }
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Bagian { get; set; }
        public string Keterangan { get; set; }
    }
}
