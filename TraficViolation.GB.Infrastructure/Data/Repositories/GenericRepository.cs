using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Repositories;
using TraficViolation.GB.Domain.Shared;
using TraficViolation.GB.Infrastructure.Data.Context;

namespace TraficViolation.GB.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly TraficViolationDbContext _context;

        public GenericRepository(TraficViolationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Tkey Id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}
