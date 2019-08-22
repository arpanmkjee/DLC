using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartEssentials.WebApi.Auth
{
    //https://www.codeproject.com/Articles/5160941/ASP-NET-CORE-Token-Authentication-and-Authorizatio

    public interface ITokenProvider
    {
        (string token, User user) LoginUser(string username, string password);

    }

    public class TokenProvider : ITokenProvider
    {
        private IUserRepository _userRepository { get; set; }
        private IPasswordHasher _passwordHasher { get; set; }
        private JwtAuthConfig _jwtAuthConfig { get; set; }
        public TokenProvider(IUserRepository userRepository, 
                            IPasswordHasher passwordHasher, 
                            IOptions<JwtAuthConfig> jwtAuthConfig)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtAuthConfig = jwtAuthConfig.Value;
        }
        public (string token, User user) LoginUser(string username, string password)
        {
            //Get user details for the user who is trying to login - JRozario
            User user = _userRepository.GetByUsername(username);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return (null,null);

            //If its registered user, check user password stored in DB - JRozario
            //For demo, password is not hashed. Its just a string comparison - JRozario
            //In reality, password would be hashed and stored in DB. Before comparing, hash the password - JRozario
            (bool passVerified, bool needsUpgrade) = _passwordHasher.Check(user.Password, password);
            if (passVerified)
            {
                //Authentication successful, Issue Token with user credentials - JRozario
                //Provide the security key which was given in the JWToken configuration in Startup.cs - JRozario
                var key = Encoding.ASCII.GetBytes(_jwtAuthConfig.SecurityKey);
                //Generate Token for user - JRozario
                var JWToken = new JwtSecurityToken(
                    issuer: _jwtAuthConfig.Issuer,
                    audience: _jwtAuthConfig.Audience,
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token - JRozario
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return (token,user);
            }
            else
            {
                return (null,null);
            }
        }

        private IEnumerable<Claim> GetUserClaims(User user)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            };
            return claims;
        }
    }
}
