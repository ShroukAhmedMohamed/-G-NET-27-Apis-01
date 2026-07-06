using E_Commerce.G02.Domain.Common;
using E_Commerce.G02.Domain.contracts;
using E_Commerce.G02.Domain.Repositories;
using E_Commerce.G02.Infrastructure.Data;
using E_Commerce.G02.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Infrastructure
{
    public class UnitOfWork(StoreDbContext context) : IUnitOfWork
    {


        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {

            var typeName = typeof(TEntity).Name;

            if (_repositories.TryGetValue(typeName, out object? value))

                return (IGenericRepository<TEntity, TKey>)value;

            var repo = new GenericRepository<TEntity, TKey>(context);

            _repositories.Add(typeName, repo);

            return repo;



        }

        public async Task<int> SaveChanagesAsync(CancellationToken ct = default)
     => await context.SaveChangesAsync(ct);
    }
}
