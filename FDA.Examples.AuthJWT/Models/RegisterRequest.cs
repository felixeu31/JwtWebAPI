using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA.Examples.AuthJWT.Models
{
    public class RegisterRequest
    { 
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
