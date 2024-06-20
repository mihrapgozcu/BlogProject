using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Base;
using BlogProject.DAL.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _db;

        public UnitOfWork(BlogContext db)
        {
            _db = db;
        }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        
        public int Save()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
