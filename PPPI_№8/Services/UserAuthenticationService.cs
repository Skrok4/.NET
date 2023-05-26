using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fitness_Tracking.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly string _jwtSecretKey = "7upjytzg5792shf9lwbp";
        private readonly string _jwtIssuer = "fitness-tracking";
        private readonly List<UserModel> _userList;

        public UserAuthenticationService()
        {
            _userList = new List<UserModel>()
            {
                new UserModel
                {
                    UserId = 1,
                    FirstName = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Password = PasswordEncryptionService.EncryptPassword("password123"),
                    LastAuthorizationDate = DateTime.Now,
                    FailedAuthorizationAttempts = 0
                },
                new UserModel
                {
                    UserId = 2,
                    FirstName = "Jane",
                    Surname = "Smith",
                    Email = "jane.smith@example.com",
                    DateOfBirth = new DateTime(1985, 9, 23),
                    Password = PasswordEncryptionService.EncryptPassword("password456"),
                    LastAuthorizationDate = DateTime.Now,
                    FailedAuthorizationAttempts = 0
                },
                new UserModel
                {
                    UserId = 3,
                    FirstName = "Alice",
                    Surname = "Johnson",
                    Email = "alice@example.com",
                    DateOfBirth = new DateTime(1992, 3, 15),
                    Password = "password",
                    LastAuthorizationDate = DateTime.Now,
                    FailedAuthorizationAttempts = 3
                },
                new UserModel
                {
                    UserId = 4,
                    FirstName = "Bob",
                    Surname = "Smith",
                    Email = "bob@example.com",
                    DateOfBirth = new DateTime(1988, 9, 20),
                    Password = "password",
                    LastAuthorizationDate = DateTime.Now,
                    FailedAuthorizationAttempts = 0
                },
            };
        }
        public async Task<bool> Register(UserModel user)
        {
            // Check if the email is already registered
            if (_userList.Any(u => u.Email == user.Email))
            {
                return false;
            }

            user.Password = PasswordEncryptionService.EncryptPassword(user.Password);
            user.UserId = _userList.Max(u => u.UserId) + 1;
            _userList.Add(user);
            return await Task.FromResult(true); ;
        }

        public async Task<string> Login(UserModel user)
        {
            var existingUser = _userList.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null && PasswordEncryptionService.EncryptPassword(user.Password) == existingUser.Password)
            {
                var token = GenerateJwtToken(existingUser);
                return await Task.FromResult(token);
            }
            return await Task.FromResult<string>(null);
        }
        public async Task<UserModel> GetUserProfile(int userId)
        {
            // Get the user profile based on the userId
            return await Task.FromResult(_userList.FirstOrDefault(u => u.UserId == userId));
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            // Return all users
            return await Task.FromResult(_userList.ToList());
        }

        private string GenerateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _jwtIssuer,
                Audience = _jwtIssuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
