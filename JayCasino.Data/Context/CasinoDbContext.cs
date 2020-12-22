using JayCasino.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace JayCasino.Data.Context
{
    /// <summary>
    /// CasinoDbContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CasinoDbContext : DbContext
    {
        public CasinoDbContext(DbContextOptions<CasinoDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public DbSet<Player> Players { get; set; }

    }
}
