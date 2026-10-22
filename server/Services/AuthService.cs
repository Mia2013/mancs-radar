using mancs_radar_server.Data;
using mancs_radar_server.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mancs_radar_server.Services
{
    public class AuthService : IAuthService
    {
        readonly MancsRadarDbContext _context;
        readonly PasswordHasher<User> _passwordHasher;
        readonly IConfiguration _config;

        public AuthService(MancsRadarDbContext context, PasswordHasher<User> passwordHasher, IConfiguration config)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        public async Task<ServiceResult> RegisterAsync(RegisterDTO dto)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
            if (exists)
            {
                return ServiceResult.Fail(409, "Ez az email cím már foglalt!");
            }

            User newUser = new()
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = Models.Roles.User
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return ServiceResult.Ok("Sikeres regisztráció!");
        }

        public async Task<ServiceResult> LoginAsync(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return ServiceResult.Fail(401, "Hibás email cím vagy jelszó!");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return ServiceResult.Fail(401, "Hibás email cím vagy jelszó!");
            }

            return ServiceResult.Ok("Sikeres bejelentkezés!", TokenGenerate(user));
        }

        string TokenGenerate(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email),
                 new Claim("role", user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}