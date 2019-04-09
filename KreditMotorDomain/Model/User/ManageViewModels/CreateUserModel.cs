using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorDomain.Model.User.ManageViewModels
{
   public class CreateUserModel
    {
        public string Nama { get; set; }
        public string Bagian { get; set; }
        public string Keterangan { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }


        public EditUserModel edituser { get; set; }
    }
}
