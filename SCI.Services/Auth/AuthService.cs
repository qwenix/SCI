using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services.Auth {
    public class AuthService : IAuthService {

        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;

        private readonly ITokenGenerator tokenGenerator;
        private readonly IRefreshTokenFactory refreshTokenFactory;
        private readonly IPasswordGenerator passwordGenerator;

        private readonly IEmailService emailService;

        public AuthService(
            IUserRepository userRepository,
            ITokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory,
            IPasswordGenerator passwordGenerator,
            IEmailService emailService,
            ICompanyRepository companyRepository) {
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenFactory = refreshTokenFactory;
            this.userRepository = userRepository;
            this.passwordGenerator = passwordGenerator;
            this.emailService = emailService;
            this.companyRepository = companyRepository;
        }

        public async Task RegisterAdminAsync(User user) {
            string password = passwordGenerator.GeneratePassword();
            await RegisterUserAsync(user, Roles.ADMIN, password);
            await emailService.SendEmailAsync(user.Email, password);
        }

        public async Task RegisterUserAsync(User user, string roleName, string password) {
            var result = await userRepository.AddUserAsync(user, password);
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }
            await userRepository.AddUserToRoleAsync(user, roleName);
        }

        public async Task RegisterCompanyAsync(Company company, User companyAdmin) {
            string password = passwordGenerator.GeneratePassword();
            await RegisterUserAsync(companyAdmin, Roles.COMPANY_ADMIN, password);
            company.UserId = companyAdmin.Id;

            await companyRepository.AddAsync(company);
            await companyRepository.SaveChangesAsync();

            await emailService.SendEmailAsync(companyAdmin.Email, password);
        }

        public async Task CreateRoleAsync(IdentityRole role) {
            var result = await userRepository.AddRoleAsync(role);
            if (!result.Succeeded) {
                throw new Exception(result.Errors.First().Description);
            }
        }

        public async Task<TokensInfo> LoginAsync(string username, string password) {
            User user = await userRepository.FindByUsernameAsync(username);
            if (user == null) {
                throw new Exception("User does not exist!");
            }

            bool passwordCorrect = await userRepository.CheckPasswordAsync(user, password);
            if (!passwordCorrect) {
                throw new Exception("Password is incorrect!");
            }

            Claim[] userClaims = await GetAuthTokenClaimsForUserAsync(user);

            var accessToken = tokenGenerator.GenerateTokenForClaims(userClaims);
            var refreshToken = refreshTokenFactory.GenerateRefreshToken();

            return new TokensInfo(accessToken, refreshToken);
        }

        private async Task<Claim[]> GetAuthTokenClaimsForUserAsync(User user) {
            IList<string> userRoles = await userRepository.GetRolesAsync(user);
            var userClaims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.First())
            };
            return userClaims;
        }

        //public async Task<TokenRefreshResponseDTO> RefreshTokenAsync(TokenRefreshRequestDTO request) {
        //    string userEmail = GetEmailOfAuthorizationToken(request);
        //    User user = await userRepository.FindByEmailAsync(userEmail);
        //    if (user == null) {
        //        throw new BadRequestException("User does not exist!");
        //    }

        //    RefreshToken token = userRepository.GetRefreshToken(user, request.RefreshToken);
        //    if (token == null) {
        //        throw new ForbiddenException("Refresh token is not valid!");
        //    }

        //    var newRefreshToken = refreshTokenFactory.GenerateRefreshToken();
        //    await userRepository.DeleteRefreshTokenAsync(token);
        //    await userRepository.CreateRefreshTokenAsync(user, newRefreshToken);

        //    Claim[] tokenClaims = await GetAuthTokenClaimsForUserAsync(user);
        //    string newAccessToken = tokenGenerator.GenerateTokenForClaims(tokenClaims);

        //    return new TokenRefreshResponseDTO {
        //        Token = newAccessToken,
        //        RefreshToken = newRefreshToken
        //    };
        //}

        //private static string GetEmailOfAuthorizationToken(TokenRefreshRequestDTO request) {
        //    return new JwtSecurityTokenHandler()
        //        .ReadJwtToken(request.AuthToken)
        //        .Claims
        //        .FirstOrDefault(claim => claim.Type == ClaimsIdentity.DefaultNameClaimType)
        //        .Value;
        //}

        //public async Task RevokeTokenAsync(TokenRevokeDTO request) {
        //    User user = await userRepository.FindByEmailAsync(request.Email);
        //    if (user == null) {
        //        throw new BadRequestException("User does not exist!");
        //    }

        //    RefreshToken refreshToken = userRepository.GetRefreshToken(user, request.RefreshToken);
        //    if (refreshToken == null) {
        //        throw new ForbiddenException("Refresh token is not valid!");
        //    }

        //    await userRepository.DeleteRefreshTokenAsync(refreshToken);
        //}

        //public async Task<UserInfoResponseDTO> GetUserInfoAsync(string email) {
        //    var user = await userRepository.FindByEmailAsync(email);
        //    if (user == null) {
        //        throw new NotFoundException("User not found!");
        //    }

        //    IList<string> userRoles = await userRepository.GetRolesAsync(user);
        //    return new UserInfoResponseDTO {
        //        Email = user.Email,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Role = userRoles.FirstOrDefault()
        //    };
        //}
    }
}
