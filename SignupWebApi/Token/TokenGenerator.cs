using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SignupWebApi.Modals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignupWebApi.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(UserModel user)
        {
            try
            {
                // 1. Create the claims
                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT Id (unique identifier)
            new Claim(ClaimTypes.Name, user.MobileNo), // Use mobileNo as the Name claim
            new Claim(ClaimTypes.Role, "User"), // User role claim
        };

                // 2. Create your secret key and define the signing credentials (HMAC SHA256)
                var secret = "MoinuddinshaikhmainprojectUserDetails"; // Store this securely
                var key = Encoding.UTF8.GetBytes(secret);

                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                // 3. Create the token
                var token = new JwtSecurityToken(
                    issuer: "authapiMoinuddin", // Your issuer
                    audience: "userapi", // Your audience
                    claims: claims, // Claims (payload)
                    signingCredentials: credentials, // Signing credentials
                    expires: DateTime.UtcNow.AddMinutes(30) // Use UtcNow to avoid timezone issues
                );

                // 4. Return the token as a string (serialized to JSON format)
                var response = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token) // Generate the JWT token
                };

                return JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., logging)
                return JsonConvert.SerializeObject(new { error = ex.Message });
            }
        }

    }

    public interface ITokenGenerator
    {
        string GenerateToken(UserModel user);
    }
}
