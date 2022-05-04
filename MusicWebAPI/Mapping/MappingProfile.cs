namespace MusicWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArtistForm, ArtistEntity>()
                .ReverseMap();
            CreateMap<ArtistEntity, Artist>()
                .ReverseMap();
            CreateMap<ArtistEntity, ArtistDto>()
                .ReverseMap();
        }
    }
}
