using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Models.UserModel
{
    public class RegisterViewModel
    {
        public string? user_name { get; set; }
        public string? password { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public int gender { get; set; }
    }
}
