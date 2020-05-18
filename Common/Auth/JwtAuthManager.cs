using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace Consulting.Common.Auth
{
    public static class JwtAuthManager
    {
        public const string SecretKey = "JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ==";
        //public const string SecretKey = "karafarinkey";
        public static string GenerateJWTToken(string username,int userID, int expire_in_Minutes = 30)
        {
            //var symmetric_Key = Convert.FromBase64String(SecretKey);
            //var token_Handler = new JwtSecurityTokenHandler();

            //var now = DateTime.UtcNow;
            //var securitytokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //            {
            //                new Claim(ClaimTypes.Name, username)
            //            }),
            //    Issuer= "karafarinomid",
            //    Audience= "karafarinomid",
            //    Expires = now.AddMinutes(Convert.ToInt32(expire_in_Minutes)),

            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetric_Key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var stoken = token_Handler.CreateToken(securitytokenDescriptor);
            //var token = token_Handler.WriteToken(stoken);

            //return token;

            try
            {         
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti,Convert.ToString(userID))
            };

            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
      
                var token = new JwtSecurityToken(                  
                    //expires: DateTime.Now.AddMinutes(expire_in_Minutes),
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signKey, SecurityAlgorithms.HmacSha256),
                    claims: claims
                    );

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenstring;
            }
            catch (Exception ex)
            {                
                return ex.Message;
            }
            
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtTokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(SecretKey);

                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JIOBLi6eVjBpvGtWBgJzjWd2QH0sOn5tI8rIFXSHKijXWEt/3J2jFYL79DQ1vKu+EtTYgYkwTluFRDdtF41yAQ=="))
                };

                var principal = jwtTokenHandler.ValidateToken(token, validationParameters, out var rawValidatedToken);

                return principal;
            }


           catch (SecurityTokenValidationException stvex)
            {
                //throw new Exception($"Token failed validation: {stvex.Message}");
                return null;
            }

            catch (ArgumentException argex)
            {
                //throw new Exception($"Token was invalid: {argex.Message}");
                return null;
            }

          catch
            {
                return null;
            }



        }
    }
}