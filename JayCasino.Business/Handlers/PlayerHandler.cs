using System;
using JayCasino.Business.Entities;
using JayCasino.Business.Interfaces;
using JayCasino.Data.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using JayCasino.Data.Domain;

namespace JayCasino.Business.Handlers
{
    public class PlayerHandler : IPlayerHandler
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public PlayerHandler(IPlayerService playerService, IMapper mapper)
        {
            this.playerService = playerService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="playerEntity">The player entity.</param>
        public async Task<Guid> AddPlayer(PlayerEntity playerEntity)
        {
            // TODO: add validation

            Player player = mapper.Map<Player>(playerEntity);

            Guid playerId = Guid.Empty;

            await playerService.AddAsync(player, autoSave: false);

            if (await playerService.SaveAsync() > 0)
                playerId = player.Id;

            return playerId;
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<PlayerEntity> GetPlayer(Guid id)
        {
            Player player = await playerService.GetPlayer(id);

            return mapper.Map<PlayerEntity>(player); ;
        }
    }
}
