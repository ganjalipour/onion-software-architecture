using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Consulting.Infrastructure.Data;
using Consulting.Infrastructure.Core.ContextFactory;

namespace Consulting.Infrastructure.Data.Factories
{
   public class ContextFactory : IContextProviderFactory
    {
        private  IServiceProvider Provider;

        public bool IsGetMethode { get; set; }
        public AppDBContext dbContext { get; set ; }

        public ContextFactory(IServiceProvider provider)
        {
            Provider = provider;
            dbContext = provider.GetServices<AppCommandDBContext>().FirstOrDefault();
        }

        //public AppDBContext Create()
        //{
        //    if (IsGetMethode)
        //    {
        //        // var ser = ((AppDBContext) provider.GetServices<IPostDBContext>().FirstOrDefault());
        //        // var d = provider.GetServices<DbContext>();
        //        var res = provider.GetServices<AppQueryDBContext>().FirstOrDefault();
        //      //  res.Database.GetDbConnection().ConnectionString = "Server=.\\SQL2017;Database=MicroFunds; User Id='sa'; Password='123456'";
              
        //      //  res.Database.GetDbConnection().ConnectionString = "Server=192.168.101.78;Database=MicroFundsTest; User ID=sa;Password=microfunds";
        //        return res;
        //    }
        //    var postContext = provider.GetServices<AppCommandDBContext>().FirstOrDefault();
        //    return postContext;
        //}
    }
}
