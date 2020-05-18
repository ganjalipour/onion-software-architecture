using Microsoft.EntityFrameworkCore;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class AppCommandDBContext : AppDBContext
    {
        public AppCommandDBContext(DbContextOptions options) : base(options)
        {

        }

     
    }
}
