using Consulting.Infrastructure.Core.Data.Repositories.EFCore;


namespace  Consulting.Infrastructure.Core.ContextFactory
{ 
    public interface IContextProviderFactory
    {
        bool IsGetMethode { get; set; }

        AppDBContext dbContext { get; set; }


    }
}
