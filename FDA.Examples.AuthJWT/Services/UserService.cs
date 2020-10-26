using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FDA.Examples.AuthJWT.DbContext;
using FDA.Examples.AuthJWT.Entities;
using FDA.Examples.AuthJWT.Helpers;
using FDA.Examples.AuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FDA.Examples.AuthJWT.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Register(RegisterRequest model);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _dbContext;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _dbContext = new ApplicationDbContext();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var users = _dbContext.Users.AsNoTracking();

            //var user = users.SingleOrDefault(x => x.UserName == model.Username && x.PasswordHash == model.Password);
            var user = users.SingleOrDefault(x => x.UserName == model.UserName);

            // return null if user not found
            if (user == null || !VerifyPassword(model.Password, user.PasswordHash, user.Salt)) return null;


            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _dbContext.Users.AsNoTracking();
            return users;
        }

        public User GetById(int id)
        {
            var users = _dbContext.Users.AsNoTracking();
            return users.FirstOrDefault(x => x.Id == id);
        }

        public bool Register(RegisterRequest model)
        {
            HashSalt hashSalt = GenerateSaltedHash(16, model.Password);

            User newUser = new User
            {
                Email = model.Email,
                UserName = model.UserName,
                FullName = model.FullName,
                PasswordHash = hashSalt.Hash,
                Salt = hashSalt.Salt
            };

            _dbContext.Users.Add(newUser);

            return _dbContext.SaveChanges() > 0;
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string genneratePasswordHash(string password)
        {
            return password;
        }

        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}
