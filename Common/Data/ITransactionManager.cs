using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Common.Data
{
    public interface ITransactionManager
    {
        Task<int> SaveAllAsync();

    }
}
