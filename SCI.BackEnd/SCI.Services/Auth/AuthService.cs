using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Extensions;
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
        private readonly IDriverRepository driverRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ICompanyRepository companyRepository;

        private readonly ITokenGenerator tokenGenerator;
        private readonly IRefreshTokenFactory refreshTokenFactory;
        private readonly IPasswordGenerator passwordGenerator;

        private readonly IEmailService emailService;

        public AuthService(
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IApplicationUserRepository applicationUserRepository,
            IDriverRepository driverRepository,
            ITokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory,
            IPasswordGenerator passwordGenerator,
            IEmailService emailService) {
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenFactory = refreshTokenFactory;
            this.userRepository = userRepository;
            this.passwordGenerator = passwordGenerator;
            this.emailService = emailService;
            this.companyRepository = companyRepository;
            this.driverRepository = driverRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task RegisterUserAsync(User user, string roleName, string password) {
            await AddUserAsync(user, password);
            await AddUserToRoleAsync(user, roleName);
        }

        public async Task RegisterAdminAsync(ApplicationUser applicationUser) {
            await applicationUserRepository.AddAsync(applicationUser);
            await applicationUserRepository.SaveChangesAsync();

            string password = passwordGenerator.GeneratePassword();
            await AddUserPasswordAsync(applicationUser.User, password);
            await AddUserToRoleAsync(applicationUser.User, Roles.ADMIN);

            await emailService.SendEmailAsync(applicationUser.User.Email, password);
        }

        public async Task RegisterDriverAsync(Driver driver, string password) {
            await driverRepository.AddAsync(driver);
            await driverRepository.SaveChangesAsync();

            await AddUserPasswordAsync(driver.ApplicationUser.User, password);
            await AddUserToRoleAsync(driver.ApplicationUser.User, Roles.DRIVER);
        }

        public async Task RegisterCompanyAsync(Company company) {
            string password = passwordGenerator.GeneratePassword();

            await companyRepository.AddAsync(company);
            await companyRepository.SaveChangesAsync();

            await AddUserPasswordAsync(company.User, password);
            await AddUserToRoleAsync(company.User, Roles.COMPANY);

            await emailService.SendEmailAsync(company.User.Email, password);
        }

        public async Task CreateRoleAsync(IdentityRole<int> role) {
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.First())
            };
            return userClaims;
        }

        private async Task AddUserPasswordAsync(User user, string password) {
            IdentityResult identityResult = await userRepository.AddUserPasswordAsync(user, password);
            if (!identityResult.Succeeded) {
                throw new Exception(identityResult.Errors.First().Description);
            }
        }

        private async Task AddUserAsync(User user, string password) {
            IdentityResult identityResult = await userRepository.AddUserAsync(user, password);
            if (!identityResult.Succeeded) {
                throw new Exception(identityResult.Errors.First().Description);
            }
        }

        private async Task AddUserToRoleAsync(User user, string roleName) {
            IdentityResult identityResult = await userRepository.AddUserToRoleAsync(user, roleName);
            if (!identityResult.Succeeded) {
                throw new Exception(identityResult.Errors.First().Description);
            }
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
