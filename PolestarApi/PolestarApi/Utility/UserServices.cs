using ApplicationApi.DataAccess.Data;
using ApplicationApi.SecureWebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PolestarApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PolestarApi.Utility
{
    public interface IUserService
    {
        UserAccounts Authenticate(string userName,string password);

    }
    public class UserServices : IUserService
    {
        private readonly AppSetting _appsettings;
        public readonly ApplicationDbContext _db;
        public UserServices(IOptions<AppSetting> appSettings)
        {
            _appsettings = appSettings.Value;
        }

        public UserAccounts Authenticate(string userName,string password)
        {
            var user = _db.UserAccount.FirstOrDefault(u => u.UserName == userName);
            // return null if user not found
            if (user == null)
                return null;
            if (decodeHashPassword(user.Password, password))
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var RoleName = _db.Role.FirstOrDefault(u=>u.RoleId== user.RoleId).Name;
                var key = Encoding.ASCII.GetBytes(_appsettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, RoleName)

                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }
            else
            {
                return null;
            }
        }
        public bool decodeHashPassword(string existingPassword, string enteredPassword)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(existingPassword);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string hashPassword(string enteredPassword)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

    }
}
