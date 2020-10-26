using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDA.Examples.AuthJWT.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

    }
}
