using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Concrete.Repositories.BlogRepository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
       
        Task<int> SaveAsync();

        int Save();
    }
}
