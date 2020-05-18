using Consulting.Infrastructure.Core.Data.Repositories.EFCore.CoreContext;
using Microsoft.AspNetCore.SignalR;

namespace API.HandleRequest
{
    public class CustomUserIDProvider : IUserIdProvider
    {
        private UserResolverService _userResolverService;
        public CustomUserIDProvider(UserResolverService userResolverService)
        {
            _userResolverService = userResolverService;
        }
        public string GetUserId(HubConnectionContext connection)
        {
           // var x = connection.User.Identity.Name;
            var userID = connection.GetHttpContext().Request.Query["access_token"];
            //JwtSecurityToken jsonToken = new JwtSecurityToken();
            //var handler = new JwtSecurityTokenHandler();
            //jsonToken = handler.ReadJwtToken(kkoo);
            //var id = jsonToken.Claims.FirstOrDefault(p => p.Type == "jti");
            return userID;
        }

    }
}
