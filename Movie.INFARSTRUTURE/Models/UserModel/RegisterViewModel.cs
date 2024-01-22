using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Models.UserModel
{
    public class RegisterViewModel
    {
        //public string? user_name { get; set; }
        //public string? password { get; set; }
        //public string? phone { get; set; }
        //public string? email { get; set; }
        //public string? address { get; set; }
        //public int gender { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? PasswordHash { get; set; }
    }
}
