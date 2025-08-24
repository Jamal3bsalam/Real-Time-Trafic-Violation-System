using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.UnitOfWork;
using TraficViolation.GB.Domain.Repositories;
using TraficViolation.GB.Domain.Shared;
using TraficViolation.GB.Infrastructure.Data.Context;
using TraficViolation.GB.Infrastructure.Data.Repositories;

namespace TraficViolation.GB.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TraficViolationDbContext _context;
        private readonly Hashtable _repositories;

        public UnitOfWork(TraficViolationDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repo = new GenericRepository<TEntity, Tkey>(_context);
                _repositories.Add(type, repo);
            }

            return _repositories[type] as IGenericRepository<TEntity, Tkey>;
        }
    }
}
