using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore.CoreContext
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetCurrentUser()
        {
            int userID = 0;
            var accessToken = _context.HttpContext.Request.Headers["Authorization"];
            JwtSecurityToken jsonToken = new JwtSecurityToken();
            if (accessToken.Count > 0)
            {
                string jwt = accessToken[0].Replace("Bearer ", string.Empty);
                var handler = new JwtSecurityTokenHandler();
                jsonToken = handler.ReadJwtToken(jwt);
            }

            var user = jsonToken.Claims.FirstOrDefault(p => p.Type == "jti");
            userID = user == null ? 0 : int.Parse(user.Value);
            return userID;
        }
    }
}
