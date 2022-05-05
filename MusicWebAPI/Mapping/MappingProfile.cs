namespace MusicWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping för Artist
            CreateMap<ArtistForm, ArtistEntity>()
                .ReverseMap();
            CreateMap<ArtistEntity, Artist>()
                .ReverseMap();
            CreateMap<ArtistEntity, ArtistDto>()              
                .ReverseMap();

            // mapping för Album
            CreateMap<AlbumForm, AlbumEntity>()
                .ReverseMap();
            CreateMap<AlbumEntity, Album>()
                .ReverseMap();
            CreateMap<AlbumEntity, AlbumDto>()
                .ForMember(des => des.ArtistName, source => source.MapFrom(a => a.Artist.Name))
                .ReverseMap();
        }
    }
}
