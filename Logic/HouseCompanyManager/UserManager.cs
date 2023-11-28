using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Logic.Abstract;
using _19070006008_midterm.Models;
using _19070006008_midterm.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _19070006008_midterm.Logic._19070006008_midtermManagers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LogicResponseDTO<CompanyUser>> SignUp(SignUpModel model)
        {
            var user = _userRepository.GetUserByUsername(model.Username);
            if (user == null)
            {
                var passwordSalt = PasswordHasherService.GenerateSalt();
                var passwordHash = PasswordHasherService.GenerateHash(model.Password, passwordSalt);
                var newUser = new CompanyUser
                {
                    Username = model.Username, 
                    Name = model.Name,
                    Surname = model.Surname,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                newUser = CreateToken(newUser);

                var createdUser = await _userRepository.Create(newUser);
                createdUser.PasswordHash = new byte[0];
                createdUser.PasswordSalt = new byte[0];
                return new LogicResponseDTO<CompanyUser> 
                { 
                    Data = createdUser, 
                    Success = true, 
                    Message = "Sign Up operation completed successfully." 
                };
            }
            else
            {
                return new LogicResponseDTO<CompanyUser> 
                { 
                    Data = null, 
                    Success = false, 
                    Message = "Username already exists. Please sign in." 
                };
            }
        }

        public LogicResponseDTO<CompanyUser> SignIn(SignInModel model)
        {
            var user = _userRepository.GetUserByUsername(model.Username);
            if (user != null)
            {
                var isPasswordValid = PasswordHasherService.VerifyPassword(model.Password, user.PasswordSalt, user.PasswordHash);
                user.PasswordHash = new byte[0];
                user.PasswordSalt = new byte[0];
                return new LogicResponseDTO<CompanyUser>
                {
                    Data = isPasswordValid ? user : null,
                    Success = isPasswordValid,
                    Message = isPasswordValid ? "Sign in successful."
                    :
                    "Invalid username or password."
                };
            }
            else
            {
                return new LogicResponseDTO<CompanyUser> 
                { 
                    Data = null, 
                    Success = false, 
                    Message = "User not found." 
                };
            }
        }

        private CompanyUser CreateToken(CompanyUser user)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = GetToken(authClaims);
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return user;
        }

        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMonths(12),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        public CompanyUser GetUserFromToken(string token)
        {
            return _userRepository.GetUserByToken(token);
        }
    }
}
