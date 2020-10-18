using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.WebAPI_JWT.Entities;

namespace Exercise.WebAPI_JWT.Models
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FullName = user.FullName;
            UserName = user.UserName;
            Token = token;
        }
    }
}
