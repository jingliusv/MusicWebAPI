using MusicWebAPI.Data;

namespace MusicWebAPI.Services
{
    public interface ISongService
    {
        Task<Song> CreateAsync(SongForm song);
        Task<SongDto> GetByIdAsync(int id);
        Task<IEnumerable<SongDto>> GetAllAsync();
        Task<Song> UpdateAsync(int id, SongForm song);
        Task<Song> DeleteAsync(int id);
    }

    public class SongService : ISongService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IAlbumService _albumService;

        public SongService(DataContext context, IMapper mapper, IAlbumService albumService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _albumService = albumService ?? throw new ArgumentNullException(nameof(albumService));
        }


        public async Task<Song> CreateAsync(SongForm song)
        {
            // kolla om albumet som finns
            var album = await _albumService.GetByIdAsync(song.AlbumId);
            // kolla om sång finns
            var songEntity = await _context.Songs.FirstOrDefaultAsync(s => s.Name == song.Name);
            if(songEntity == null && album != null)
            {
                var songCreate = _mapper.Map<SongEntity>(song);
                songCreate.ArtistId = (await _albumService.GetByIdAsync(song.AlbumId)).ArtistId;
                _context.Songs.Add(songCreate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Song>(songCreate);
            }
            return null!;
        }

        public async Task<IEnumerable<SongDto>> GetAllAsync()
        {
            var songs = await _context.Songs.Include(s => s.Artist).Include(s => s.Album).ToListAsync();
            return _mapper.Map<IEnumerable<SongDto>>(songs);
        }

        public async Task<SongDto> GetByIdAsync(int id)
        {
            var song = await _context.Songs
                .Include(s => s.Artist)
                .Include(s => s.Album).FirstOrDefaultAsync(s => s.Id == id);
            if(song != null) 
                return _mapper.Map<SongDto>(song);

            return null!;
        }

        public async Task<Song> UpdateAsync(int id, SongForm song)
        {
            // kolla om albumet som finns
            var album = await _albumService.GetByIdAsync(song.AlbumId);
            // kolla om sång finns
            var songEntity = await _context.Songs.FirstOrDefaultAsync(s => s.Name == song.Name);
            if (songEntity != null && album != null)
            {
                _mapper.Map(song, songEntity);
                songEntity.ArtistId = (await _albumService.GetByIdAsync(song.AlbumId)).ArtistId;
                await _context.SaveChangesAsync();
                return _mapper.Map<Song>(songEntity);
            }
            return null!;
        }


        public async Task<Song> DeleteAsync(int id)
        {
            var songDelete = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);
            if( songDelete != null)
            {
                _context.Songs.Remove(songDelete);
                await _context.SaveChangesAsync();
                return _mapper.Map<Song>(songDelete);
            }
                

            return null!;
        }
    }
}
