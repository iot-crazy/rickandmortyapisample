using AutoMapper;
using ViewModels;

namespace Mapping
{
    public sealed class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<DTO.Character, Data.Character>()
                .ForMember(c => c.LocationName, opt => opt.MapFrom(d => d.Location.Name))
                .ForMember(c => c.LocationURL, opt => opt.MapFrom(d => d.Location.URL));

            CreateMap<Data.Character, CharacterViewModel>();

        }
    }
}
