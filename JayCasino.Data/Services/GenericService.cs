using JayCasino.Data.Context;
using JayCasino.Data.Interfaces;

namespace JayCasino.Data.Services
{
    /// <summary>
    /// GenericService
    /// </summary>
    /// <seealso cref="JayCasino.Data.Services.ServiceBase{JayCasino.Data.Context.CasinoDbContext}" />
    /// <seealso cref="JayCasino.Data.Interfaces.IGenericService" />
    public class GenericService : ServiceBase<CasinoDbContext>, IGenericService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GenericService(CasinoDbContext dbContext) : base(dbContext)
        { }
    }
}
