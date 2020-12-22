using JayCasino.Data.Domain;
using JayCasino.Data.Interfaces;
using JayCasino.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JayCasino.Data.Services
{
    /// <summary>
    /// Service base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IServiceBase" />
    public abstract class ServiceBase<T> : IServiceBase where T : DbContext
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly T DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected ServiceBase(T dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Adds the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task AddAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Add(entity);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Adds entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entities</exception>
        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbContext.AddRange(entities);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Updates the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task UpdateAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Update(entity);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Updates the entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entities</exception>
        public async Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbContext.UpdateRange(entities);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Removes the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task RemoveAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbContext.Remove(entity);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Removes the entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>
        /// Task.
        /// </returns>
        /// <exception cref="ArgumentNullException">entities</exception>
        public async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new()
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbContext.RemoveRange(entities);

            if (autoSave)
                await SaveAsync();
        }

        /// <summary>
        /// Gets the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Entity.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">id</exception>
        public async Task<TEntity> GetAsync<TEntity>(Guid id) where TEntity : EntityBase, new()
        {
            if (id.IsEmpty())
                throw new ArgumentNullException(nameof(id));

            TEntity entity = await DbContext.Set<TEntity>().SingleOrDefaultAsync(item => item.Id == id);

            return entity;
        }

        /// <summary>
        /// Gets all entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="ignoreQueryFilters">If set to <c>true</c> query filters will be ignored.</param>
        /// <returns>
        /// Collection of entities.
        /// </returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(bool ignoreQueryFilters = false) where TEntity : EntityBase, new()
        {
            IEnumerable<TEntity> result;

            DbSet<TEntity> entities = DbContext.Set<TEntity>();

            if (ignoreQueryFilters)
                result = await entities.IgnoreQueryFilters().ToListAsync();
            else
                result = await entities.ToListAsync();

            return result;
        }

        /// <summary>
        /// Gets all entities deferred.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="ignoreQueryFilters">If set to <c>true</c> query filters will be ignored.</param>
        /// <returns>
        /// Queryable collection of entities.
        /// </returns>
        public IQueryable<TEntity> GetAllDeferred<TEntity>(bool ignoreQueryFilters = false) where TEntity : EntityBase, new()
        {
            DbSet<TEntity> entities = DbContext.Set<TEntity>();

            IQueryable<TEntity> result = ignoreQueryFilters ? entities.IgnoreQueryFilters() : entities;

            return result;
        }

        /// <summary>
        /// Saves asynchronous.
        /// </summary>
        /// <returns>
        /// Number of affected rows
        /// </returns>
        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Checks whether or not the entity with the given identifier exists.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// A boolean value that indicates whether or not the entity exists
        /// </returns>
        /// <exception cref="ArgumentNullException">id</exception>
        public async Task<bool> ExistsAsync<TEntity>(Guid id) where TEntity : EntityBase, new()
        {
            if (id.IsEmpty())
                throw new ArgumentNullException(nameof(id));

            return await DbContext.Set<TEntity>().AnyAsync(item => item.Id == id);
        }

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <returns>
        /// DbContext transaction.
        /// </returns>
        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }
    }
}

