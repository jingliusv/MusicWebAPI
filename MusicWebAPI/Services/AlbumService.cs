using MusicWebAPI.Data;

namespace MusicWebAPI.Services
{
    public interface IAlbumService
    {
        Task<Album> CreateAsync(AlbumForm album);
        Task<AlbumDto> GetByIdAsync(int id);
        Task<IEnumerable<AlbumDto>> GetAllAsync();
        Task<AlbumDto> UpdateAsync(int id, AlbumForm album);
        Task<Album> DeleteAsync(int id);    
    }


    public class AlbumService : IAlbumService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;

        public AlbumService(DataContext context, IMapper mapper, IArtistService artistService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService)); ;
        }

        public async Task<Album> CreateAsync(AlbumForm album)
        {
            var artistExist = await _artistService.GetByIdAsync(album.ArtistId);
            var albumEntity = await _context.Albums.FirstOrDefaultAsync(a => a.Name.ToLower() == album.Name.ToLower());
            // om det inte finns album med samma namn och det finns artist
            if(albumEntity == null && artistExist != null)
            {
                var albumCreate = _mapper.Map<AlbumEntity>(album);
                _context.Albums.Add(albumCreate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Album>(albumCreate);
            }
            return null!;
        }

        public async Task<Album> DeleteAsync(int id)
        {
            var albumDelete = await _context.Albums.FindAsync(id);
            if(albumDelete != null)
            {
                _context.Albums.Remove(albumDelete);
                await _context.SaveChangesAsync();
                return _mapper.Map<Album>(albumDelete);
            }
            return null!;
        }

        public async Task<IEnumerable<AlbumDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AlbumDto>>(await _context.Albums.Include(a => a.Artist).ToListAsync());
        }

        public async Task<AlbumDto> GetByIdAsync(int id)
        {
            var albumEntity = await _context.Albums.Include(a => a.Artist)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            if(albumEntity != null)
                return _mapper.Map<AlbumDto>(albumEntity);             

            return null!;
        }

        public async Task<AlbumDto> UpdateAsync(int id, AlbumForm album)
        {
            var albumUpdate = await _context.Albums.Include(a => a.Artist).Where(a => a.Id == id).FirstOrDefaultAsync(a => a.Id == id);
            if(albumUpdate != null)
            {
                _mapper.Map(album, albumUpdate);
                await _context.SaveChangesAsync();
                return _mapper.Map<AlbumDto>(albumUpdate);
            }
            return null!;
        }
    }
}
