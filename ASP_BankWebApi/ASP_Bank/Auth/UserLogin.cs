using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP_Bank.Auth
{
    public class UserLogin
    {
        [Required, MaxLength(20)]
        public string LoginProp { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
