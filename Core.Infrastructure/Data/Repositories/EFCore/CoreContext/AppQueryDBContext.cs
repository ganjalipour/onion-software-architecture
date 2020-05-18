using Microsoft.EntityFrameworkCore;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class AppQueryDBContext : AppDBContext
    {
        public AppQueryDBContext(DbContextOptions options) : base(options)
        {

        }
     
    }
}
