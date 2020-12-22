using System;
using System.Threading.Tasks;
using JayCasino.Data.Domain;

namespace JayCasino.Data.Interfaces
{
    public interface IPlayerService : IGenericService
    {
        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task<Player> GetPlayer(Guid id);

        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="player">The player.</param>
        Task AddPlayer(Player player);

        /// <summary>
        /// Updates the player.
        /// </summary>
        /// <param name="player">The player.</param>
        Task UpdatePlayer(Player player);
    }
}
