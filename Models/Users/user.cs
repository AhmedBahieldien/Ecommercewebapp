using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYAPP.Models.Users
{
    public class user
    {
        public int ID { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
