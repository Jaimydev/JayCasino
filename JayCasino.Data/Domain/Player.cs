namespace JayCasino.Data.Domain
{
    /// <summary>
    /// Player
    /// </summary>
    /// <seealso cref="JayCasino.Data.Domain.EntityBase" />
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public long Money { get; set; }

    }
}
