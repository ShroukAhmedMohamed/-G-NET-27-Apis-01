using E_Commerce.G02.Domain.Common;
using E_Commerce.G02.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.G02.Domain.contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanagesAsync(CancellationToken ct = default);
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }














}
