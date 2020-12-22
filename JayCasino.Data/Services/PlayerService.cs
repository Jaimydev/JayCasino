using System;
using System.Threading.Tasks;
using JayCasino.Data.Context;
using JayCasino.Data.Domain;
using JayCasino.Data.Interfaces;

namespace JayCasino.Data.Services
{
    /// <summary>
    /// PlayerService
    /// </summary>
    /// <seealso cref="JayCasino.Data.Services.GenericService" />
    public class PlayerService : ServiceBase<CasinoDbContext>, IPlayerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PlayerService(CasinoDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<Player> GetPlayer(Guid id)
        {
            Player player = await this.GetAsync<Player>(id);

            return player;
        }

        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public async Task AddPlayer(Player player)
        {
            await this.AddAsync(player, autoSave: true);
        }

        /// <summary>
        /// Updates the player.
        /// </summary>
        /// <param name="player">The player.</param>
        public async Task UpdatePlayer(Player player)
        {
            await this.UpdateAsync(player, autoSave: true);
        }

    }
}
