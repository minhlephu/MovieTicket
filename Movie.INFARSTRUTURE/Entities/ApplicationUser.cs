using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Movie.INFARSTRUTURE.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [MaxLength(255)]
        public string Address { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
    }
}
