using System;
using System.Threading.Tasks;
using JayCasino.Business.Entities;

namespace JayCasino.Business.Interfaces
{
    public interface IPlayerHandler
    {
        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="playerEntity">The player entity.</param>
        Task<Guid> AddPlayer(PlayerEntity playerEntity);

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<PlayerEntity> GetPlayer(Guid id);
    }
}
