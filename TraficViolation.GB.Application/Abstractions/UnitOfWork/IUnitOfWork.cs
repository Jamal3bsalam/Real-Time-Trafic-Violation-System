using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Domain.Repositories;
using TraficViolation.GB.Domain.Shared;

namespace TraficViolation.GB.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
         Task<int> CompleteAsync();
        IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
