using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Role
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
        public List<User> user { get; set; }
    }
}
