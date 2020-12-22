using JayCasino.Business.Entities;
using JayCasino.Business.Interfaces;
using JayCasino.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JayCasino.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> logger;
        private readonly IPlayerHandler playerHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PlayerController(ILogger<PlayerController> logger, IPlayerHandler playerHandler)
        {
            this.logger = logger;
            this.playerHandler = playerHandler;
        }

        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPlayer([FromBody] PlayerEntity player)
        {
            IActionResult result;

            try
            {
                if (player == null)
                    result = BadRequest();
                else
                {
                    Guid returnId = await playerHandler.AddPlayer(player);

                    if (!returnId.IsEmpty())
                        result = CreatedAtAction(nameof(AddPlayer), returnId);
                    else
                        result = StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, StatusCodes.Status500InternalServerError.ToString());
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerEntity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayer(Guid playerId)
        {
            IActionResult result;

            try
            {
                if (playerId.IsEmpty())
                    result = BadRequest();
                else
                {
                    PlayerEntity player = await playerHandler.GetPlayer(playerId);

                    if (player != null)
                        result = Ok(player);
                    else
                        result = NotFound();
                }
            }
            catch (Exception exception)
            {
                logger.LogError(exception, StatusCodes.Status500InternalServerError.ToString());
                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
        }

    }
}
