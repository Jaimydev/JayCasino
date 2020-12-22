using System;

namespace JayCasino.Utilities.Extensions
{
    /// <summary>
    /// Class that contains extension methods for all Guids
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified unique identifier is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified unique identifier]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return (!guid.HasValue || guid == Guid.Empty);
        }
    }
}
