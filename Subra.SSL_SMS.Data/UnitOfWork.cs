using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;
        
        public void Save() => _dbContext?.SaveChanges();
        public void Dispose() => _dbContext?.Dispose();
    }
}
