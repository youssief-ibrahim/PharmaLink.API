using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaLink.Application.Common;
using PharmaLink.Application.DTO_s.Auth.Sign_In_Up;
using PharmaLink.Application.DTO_s.Sign_In_Up;
using PharmaLink.Application.IServices;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Enums.UserRoleEnums;

namespace PharmaLink.Application.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        public AuthenticationServices(UserManager<ApplicationUser> _userManager, IConfiguration _config)
        {
            userManager = _userManager;
            config = _config;
        }
        public async Task<Result<AuthModelDto>> LoginAsync(LoginDto LoginDTO)
        {
            var user = await userManager.FindByEmailAsync(LoginDTO.Email);
            if (user == null)
            {
                return Error.InvalidCrendentials("User.InvalidCrendentials");
            }
            var IsPasswordValid = await userManager.CheckPasswordAsync(user, LoginDTO.Password);
            if (!IsPasswordValid)
            {
                return Error.InvalidCrendentials("User.InvalidCrendentials");
            }
            var userRoles = await userManager.GetRolesAsync(user);

            var tokenResult = await GenerateTokenAsync(user);

            return new AuthModelDto
            {
                IsAuthenticated = true,
                Token = tokenResult.Token,
                Email = user.Email!,
                Name = user.FullName,
                phoneNumber = user.PhoneNumber!,
                Roles = userRoles,
                ExpireOn= tokenResult.ExpireOn
            };
        }

        public async Task<Result<AuthModelDto>> RegisterAsync(RegisterDto RegisterDTO)
        {
            if (RegisterDTO.Role != UserRole.Patient && RegisterDTO.Role != UserRole.PharmacyOwner)
            {
                return Error.Validation("InvalidRole","Invalid user role selected.");
            }
            var user = new ApplicationUser
            {
                Email = RegisterDTO.Email,
                FullName = RegisterDTO.DisplayName,
                UserName = RegisterDTO.Email.ToUpper(),
                PhoneNumber = RegisterDTO.PhoneNumber,
                Role = RegisterDTO.Role
            };

            var IdentityResult = await userManager.CreateAsync(user, RegisterDTO.Password);
            if (!IdentityResult.Succeeded)
            {
                return IdentityResult.Errors.Select(e => Error.Validation(e.Code, e.Description)).ToList();
            }
            var roleName = RegisterDTO.Role.ToString();

            var roleResult = await userManager.AddToRoleAsync(user, roleName);
            if (!roleResult.Succeeded)
            {
                return roleResult.Errors.Select(e => Error.Validation(e.Code, e.Description)).ToList();
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var tokenResult = await GenerateTokenAsync(user);

            return new AuthModelDto
            {
                    IsAuthenticated = true,
                    Token = tokenResult.Token,
                    Email = user.Email!,
                    Name = user.FullName,
                    phoneNumber = user.PhoneNumber!,
                    Roles = userRoles,
                    ExpireOn = tokenResult.ExpireOn
            };
        }

        private async Task<AuthTokenResult> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName!)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretKey = config["Jwt:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT SecretKey is not configured in appsettings.");
            }

            var expireOn = DateTime.UtcNow.AddHours(1);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expireOn,
                signingCredentials: creds,
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"]
            );

            return new AuthTokenResult {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireOn = expireOn
            };
        }
    }
}
