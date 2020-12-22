using AutoMapper;
using JayCasino.Business.Entities;
using JayCasino.Data.Domain;

namespace JayCasino.Business.Classes
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Authentication mapping
            CreateMap<PlayerEntity, Player>().ReverseMap();
        }
    }
}
