﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Shared.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);
        bool Delete(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> Filter();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);
        void SaveChanges();
        Task CreateAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}