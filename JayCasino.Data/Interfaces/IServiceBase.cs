using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JayCasino.Data.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace JayCasino.Data.Interfaces
{
    /// <summary>
    /// Service base interface.
    /// </summary>
    public interface IServiceBase
    {
        /// <summary>
        /// Adds the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task AddAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Adds entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Updates the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task UpdateAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Updates the entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Removes the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="autoSave">If set to <c>true</c> the entity will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task RemoveAsync<TEntity>(TEntity entity, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Removes the entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities.</param>
        /// <param name="autoSave">If set to <c>true</c> the entities will automatically be saved.</param>
        /// <returns>Task.</returns>
        Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool autoSave = true) where TEntity : EntityBase, new();

        /// <summary>
        /// Checks whether or not the entity with the given identifier exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A boolean value that indicates whether or not the entity exists</returns>
        Task<bool> ExistsAsync<TEntity>(Guid id) where TEntity : EntityBase, new();

        /// <summary>
        /// Gets the entity asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity.</returns>
        Task<TEntity> GetAsync<TEntity>(Guid id) where TEntity : EntityBase, new();

        /// <summary>
        /// Gets all entities asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="ignoreQueryFilters">If set to <c>true</c> query filters will be ignored.</param>
        /// <returns>Collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(bool ignoreQueryFilters = false) where TEntity : EntityBase, new();

        /// <summary>
        /// Gets all entities deferred.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="ignoreQueryFilters">If set to <c>true</c> query filters will be ignored.</param>
        /// <returns>Queryable collection of entities.</returns>
        IQueryable<TEntity> GetAllDeferred<TEntity>(bool ignoreQueryFilters = false) where TEntity : EntityBase, new();

        /// <summary>
        /// Saves asynchronous.
        /// </summary>
        /// <returns>Number of affected rows</returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <returns>DbContext transaction.</returns>
        IDbContextTransaction BeginTransaction();
    }


}
