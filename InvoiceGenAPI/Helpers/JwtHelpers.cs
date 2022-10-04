using InvoiceGenAPI.Models.JwtModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this User userAccount, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userAccount.UserId.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.UserEmail),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
            };

            if (userAccount.UserRole == Role.Administrator)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            else if (userAccount.UserRole == Role.User)
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this User userAccount, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccount, Id);
        }

        public static UserToken GenTokenKey(User user, JwtSettings jwtSettings)
        {
            try
            {
                Guid Id;

                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                JwtSecurityToken jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudicence,
                    claims: GetClaims(user, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey)),
                        SecurityAlgorithms.HmacSha256));

                string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwToken);

                return new UserToken
                {
                    Token = jwtToken,
                    UserName = user.UserName,
                    UserId = user.UserId,
                    GuidId = Id,
                    UserRole = user.UserRole,
                    Validity = expireTime.TimeOfDay
                };
            }
            catch (Exception exception)
            {
                throw new Exception("Error Generating the JWT", exception);
            }
        }
    }
}